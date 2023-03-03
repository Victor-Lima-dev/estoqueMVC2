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


        // GET: ItensEstoque/Editar/5, assincrono
        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Editar(int id)
        {
            var itemEstoque = await _context.ItensEstoque.FindAsync(id);
            //adicionar o produto ao item de estoque
            itemEstoque.Produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == itemEstoque.ProdutoId);
            if (itemEstoque == null)
            {
                return NotFound();
            }
            return View(itemEstoque);
        }

        // POST: ItensEstoque/Editar/5, assincrono
        [HttpPost("Editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarT(int id, ItemEstoque itemEstoque)
        {
            if (id != itemEstoque.ItemEstoqueId)
            {
                return NotFound();
            }

            
                _context.Update(itemEstoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: ItensEstoque/Detalhes/5, assincrono
        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Detalhes(int id)
        {
            var itemEstoque = await _context.ItensEstoque.FindAsync(id);
            //adicionar o produto ao item de estoque
            itemEstoque.Produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == itemEstoque.ProdutoId);
            if (itemEstoque == null)
            {
                return NotFound();
            }

            return View(itemEstoque);
        }

        //POST: ItensEstoque/Deletar/5, assincrono
        [HttpPost("Deletar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            var itemEstoque = await _context.ItensEstoque.FindAsync(id);
            _context.ItensEstoque.Remove(itemEstoque);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}