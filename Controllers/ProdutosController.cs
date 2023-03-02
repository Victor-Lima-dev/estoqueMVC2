using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using estoqueMVC2.context;
using estoqueMVC2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace estoqueMVC2.Controllers
{
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly ILogger<ProdutosController> _logger;
        private readonly AppDbContext _context;
        public ProdutosController(ILogger<ProdutosController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Produtos, assincrono
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Cadastrar, assincrono
        [HttpGet("Cadastrar")]
        public async Task<IActionResult> Cadastrar()
        {
            ViewData["Categorias"] = new List<string> { "Alimento", "Bebida", "Higiene", "Limpeza", "Teste" };
            return View();
        }

        // POST: Produtos/Cadastrar, assincrono
        [HttpPost("Cadastrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Produto produto)
        {
            //verifica se o produto é ja existe
            if (ModelState.IsValid)
            {
                var produtoExiste = await _context.Produtos.FirstOrDefaultAsync(p => p.Nome == produto.Nome);


                if (produtoExiste == null && produto.Preco >= 0)
                {
                    _context.Add(produto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Nome", "Produto já existe ou preço inválido!");
                }
            }

            return View(produto);
        }


        // GET: Produtos/Detalhes/{id}, assincrono
        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


        // GET: Produtos/Editar/{id}, assincrono
        [HttpGet("Editar/{id}")]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

               var categorias = new List<string> { "Alimento", "Bebida", "Higiene", "Limpeza", "Teste" };
    ViewData["Categorias"] = categorias;
            return View("Editar",produto);
        }

        // POST: Produtos/Editar/{id}, assincrono
        [HttpPost("Editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            _context.Update(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


        // POST: Produtos/Excluir/{id}, assincrono
        [HttpPost("Excluir/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
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