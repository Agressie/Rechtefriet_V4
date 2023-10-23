using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rechtefriet;
using Rechtefriet_V4.Data;

namespace Rechtefriet_V4.Controllers
{
    public class OrdersController : Controller
    {
        private readonly RechtefrietDB_V2 _context;

        public OrdersController(RechtefrietDB_V2 context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var rechtefrietDB_V2 = _context.Orders.Include(o => o.Klant);
            return View(await rechtefrietDB_V2.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Klant)
                .FirstOrDefaultAsync(m => m.Orderid == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["Klantid"] = new SelectList(_context.Klants, "Klantid", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Orderid,Price,Discount,Klantid,Totalprice,Paydate")] Order order)
        {
            if (!ModelState.IsValid)
            {
                Order neworder = new Order();
                neworder.Klant = _context.Klants.Find(order.Klantid);
                neworder.Klant.Orders.Add(order);
                neworder.Orderid = order.Orderid;
                neworder.Price = order.Price;
                neworder.Discount = order.Discount;
                neworder.Totalprice = order.Totalprice;
                neworder.Paydate = order.Paydate;
                _context.Orders.Add(neworder);

                return RedirectToAction(nameof(Index));
            }
            ViewData["Klantid"] = new SelectList(_context.Klants, "Klantid", "Klantid", order.Klantid);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Items(Order order)
        {
            if (_context.Items != null)
            {
                List<Item> items = new List<Item>();
                foreach (Item product in _context.Items)
                {
                    items.Add(product);
                }
                ViewData["Items"] = items;
            }
            return View(order);
        }

        public async void AddItem(int itemid, int orderid)
        {
            Order order = _context.Orders.Find(orderid);
            Item item = _context.Items.Find(itemid);
            OrderItem orderitem = new OrderItem();
            orderitem.Orderid = orderid;
            orderitem.Order = order;
            orderitem.Itemid = itemid;
            orderitem.Item = item;
            _context.OrderItems.Add(orderitem);
            // Ik weet dat de applicatie niet werkt vanaf deze lijn hierboven. Ik heb een aantal dingen geprobeerd om dit probleem op te lossen,
            // echter is het me bij alle 4 de opties niet gelukt.
            // Ivm problemen bij de start van de applicatie ben ik in week 6 volledig opnieuw moeten beginnen. Vanwege tijd te kort in de 2 weken heb ik nu 
            // de beslissing gemaakt de CRUD zo verder te laten zoals het is en bootstrap te gaan toevoegen en een API te gaan toevoegen aangezien ik anders
            // te veel tijd kwijt ben om dit probleem op te lossen terwijl ik deze tijd dus niet heb.

            // Tijdens mondelinge uitleg kan ik verder uitleggen hoe mijn visie was omdit uit te werken voor evt extra toelichting en verheldering.
            await _context.SaveChangesAsync();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveItem(int itemid, int orderid)
        {
            Order order = _context.Orders.Find(orderid);
            OrderItem orderitem = _context.OrderItems.Find(orderid, itemid);
            _context.OrderItems.Remove(orderitem);
            return RedirectToAction("Items", "Orders", new { orderitem = order });
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["Klantid"] = new SelectList(_context.Klants, "Klantid", "Klantid", order.Klantid);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Orderid,Price,Date,Discount,Klantid,Totalprice,Paydate")] Order order)
        {
            if (id != order.Orderid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Orderid))
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
            ViewData["Klantid"] = new SelectList(_context.Klants, "Klantid", "Klantid", order.Klantid);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Klant)
                .FirstOrDefaultAsync(m => m.Orderid == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'RechtefrietDB_V2.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.Orderid == id)).GetValueOrDefault();
        }
    }
}
