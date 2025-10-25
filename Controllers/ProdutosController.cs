using Microsoft.AspNetCore.Mvc;
using ExemploSQLite.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace ExemploSQLite.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: /Produtos/Criar
        public IActionResult Criar() => View();

        // POST: /Produtos/Criar
        [HttpPost]
        public async Task<IActionResult> Criar(Produto produto)
        {
            if (!ModelState.IsValid) return View(produto);

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Editar (GET)
        public async Task<IActionResult> Edit (int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                return View(produto);
            }
        }

        //EDITAR (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(produto);
            }

            _context.Update(produto);
            await _context.SaveChangesAsync();

            TempData["Mensagem"] = $"Produto '{produto.Nome}' atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        // EXCLUIR (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        // EXCLUIR (POST)
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            TempData["Mensagem"] = $"Produto '{produto.Nome}' excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}