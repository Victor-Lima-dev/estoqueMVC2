using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using estoqueMVC2.context;
using estoqueMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace estoqueMVC2.Controllers
{
    [Route("[controller]")]
    public class ItensEstoqueController : Controller
    {
        private readonly ILogger<ItensEstoqueController> _logger;
        private readonly AppDbContext _context;

        public ItensEstoqueController(ILogger<ItensEstoqueController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // POST: ItensEstoque/CriarEstoque, assincrono
        [HttpPost("CriarEstoque")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GerarEstoque()
        {
            var estoque = new Estoque();
            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        //GET ItensEstoque, assincrono
        [HttpGet("Index")]

        public async Task<IActionResult> Index()
        {
            var produtos = await _context.Produtos.ToListAsync();
            var ItensEstoque = await _context.ItensEstoque.ToListAsync();
            //vincular o produto ao item de estoque
            foreach (var item in ItensEstoque)
            {
                item.Produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == item.ProdutoId);
            }

            return View(ItensEstoque);
        }

        // GET: ItensEstoque/Cadastrar, assincrono
        [HttpGet("Cadastrar")]
        public async Task<IActionResult> Cadastrar()
        {
           var produtos = await _context.Produtos.ToListAsync();
            return View(produtos);
        }

        // POST: ItensEstoque/Cadastrar, assincrono
        [HttpPost]        
        [ValidateAntiForgeryToken]
        //vamos passar o id do produto e a quantidade
        public async Task<IActionResult> CadastrarT(int produtoId, int quantidade)
        {
            //verifica se ja existe um item de estoque com o mesmo produto, se nao existir, cria um novo, se existir, atualiza a quantidade, verificando se a quantidade é maior que zero
            if (ModelState.IsValid)
            {
                   var estoque = await _context.Estoques.FirstOrDefaultAsync(c => c.EstoqueId == 1);

                var itemEstoqueExiste = await _context.ItensEstoque.FirstOrDefaultAsync(p => p.ProdutoId == produtoId);

                if (itemEstoqueExiste == null && quantidade > 0)
                {
                    var itemEstoque = new ItemEstoque();
                    itemEstoque.ProdutoId = produtoId;
                    itemEstoque.Quantidade = quantidade;
                    itemEstoque.EstoqueId = estoque.EstoqueId;
                    _context.Add(itemEstoque);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else if (itemEstoqueExiste != null && quantidade > 0)
                {
                    itemEstoqueExiste.Quantidade = quantidade;
                    _context.Update(itemEstoqueExiste);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Quantidade", "Quantidade inválida!");
                }
            }
            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}