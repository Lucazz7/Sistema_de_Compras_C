using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteLucas.Models;

namespace TesteLucas.Controllers
{
    public class CartaoController : Controller
    {
        private readonly Context _context;

        public CartaoController(Context context)
        {
            _context = context;
        }

        // GET: Cartao
        public async Task<IActionResult> Index()
        {
            var context = _context.Cartaos.Include(c => c.Cliente);
            return View(await context.ToListAsync());
        }

        // GET: Cartao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartao = await _context.Cartaos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartao == null)
            {
                return NotFound();
            }

            return View(cartao);
        }

        // GET: Cartao/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Cartao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,N_Cartao,Nome_Titular,Cpf_Titular,Cod_seguranca,Validade_Cartao,N_parcelas,ClienteId")] Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", cartao.ClienteId);
            return View(cartao);
        }

        // GET: Cartao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartao = await _context.Cartaos.FindAsync(id);
            if (cartao == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", cartao.ClienteId);
            return View(cartao);
        }

        // POST: Cartao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,N_Cartao,Nome_Titular,Cpf_Titular,Cod_seguranca,Validade_Cartao,N_parcelas,ClienteId")] Cartao cartao)
        {
            if (id != cartao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoExists(cartao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", cartao.ClienteId);
            return View(cartao);
        }

        // GET: Cartao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartao = await _context.Cartaos
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartao == null)
            {
                return NotFound();
            }

            return View(cartao);
        }

        // POST: Cartao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartao = await _context.Cartaos.FindAsync(id);
            _context.Cartaos.Remove(cartao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaoExists(int id)
        {
            return _context.Cartaos.Any(e => e.Id == id);
        }
    }
}
