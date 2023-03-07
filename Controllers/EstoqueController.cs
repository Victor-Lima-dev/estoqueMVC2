using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using estoqueMVC2.context;
using estoqueMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace estoqueMVC2.Controllers
{
    [Route("[controller]")]
    public class EstoqueController : Controller
    {
        private readonly ILogger<EstoqueController> _logger;
        private readonly AppDbContext _context;

        public EstoqueController(ILogger<EstoqueController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //route
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var ItensEstoque = _context.ItensEstoque.ToList();
            //vincular o produto ao item de estoque
            foreach (var item in ItensEstoque)
            {
                item.Produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
            }
            var produtos = _context.Produtos.ToList();
            var estoque = new ProdutoItemEstoqueViewModel
            {
                Produtos = produtos,
                ItensEstoque = ItensEstoque
            };

            var totalItensEstoque = ItensEstoque.Sum(item => item.Quantidade);
            ViewBag.TotalItensEstoque = totalItensEstoque;
            return View(estoque);
        }

        //route pesquisa
        [HttpGet("Pesquisar")]
        public IActionResult Pesquisar(string nome)
        {
            var produtos = _context.Produtos.Where(p => p.Nome.Contains(nome)).ToList();
            var ItensEstoque = _context.ItensEstoque.ToList();
            //vincular o produto ao item de estoque
            foreach (var item in ItensEstoque)
            {
                item.Produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
            }
            var estoque = new ProdutoItemEstoqueViewModel
            {
                Produtos = produtos,
                ItensEstoque = ItensEstoque
            };

            var totalItensEstoque = ItensEstoque.Sum(item => item.Quantidade);
            ViewBag.TotalItensEstoque = totalItensEstoque;
            return View("Index", estoque);
        }

        //pesquisar por categoria
        [HttpGet("PesquisarPorCategoria")]
        public IActionResult PesquisarPorCategoria(string categoria)
        {
            var produtos = _context.Produtos.Where(p => p.Categoria == categoria).ToList();
            var ItensEstoque = _context.ItensEstoque.ToList();
            //vincular o produto ao item de estoque
            foreach (var item in ItensEstoque)
            {
                item.Produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
            }
            var estoque = new ProdutoItemEstoqueViewModel
            {
                Produtos = produtos,
                ItensEstoque = ItensEstoque
            };

            var totalItensEstoque = ItensEstoque.Sum(item => item.Quantidade);
            ViewBag.TotalItensEstoque = totalItensEstoque;
            return View("Index", estoque);
        }


        //retira de itens do estoque
        [HttpPost]
        public IActionResult Retirar(int produtoId, int quantidade)
        {
            var itemEstoque = _context.ItensEstoque.FirstOrDefault(item => item.ProdutoId == produtoId);
            if (itemEstoque != null && itemEstoque.Quantidade >= quantidade)
            {
                itemEstoque.Quantidade -= quantidade;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}