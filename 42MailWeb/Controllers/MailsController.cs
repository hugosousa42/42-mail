﻿using _42MailLibray.Entities;
using _42MailWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _42MailWeb.Controllers
{
    public class MailsController : Controller
    {
        private readonly AppDbContext _context;

        public MailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Mails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mails.ToListAsync());
        }

        // GET: Mails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mail == null)
            {
                return NotFound();
            }

            return View(mail);
        }

        // GET: Mails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Body,SentDate")] Mail mail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mail);
        }

        // GET: Mails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }
            return View(mail);
        }

        // POST: Mails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Body,SentDate")] Mail mail)
        {
            if (id != mail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MailExists(mail.Id))
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
            return View(mail);
        }

        // GET: Mails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mail == null)
            {
                return NotFound();
            }

            return View(mail);
        }

        // POST: Mails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            if (mail != null)
            {
                _context.Mails.Remove(mail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailExists(int id)
        {
            return _context.Mails.Any(e => e.Id == id);
        }
    }
}
