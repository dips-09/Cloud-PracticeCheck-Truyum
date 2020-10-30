using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TruYum_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruyumController : ControllerBase
    {
        private readonly ItemContext _context;

        public TruyumController(ItemContext context)
        {
            _context = context;
        }

        public static List<ClsMenuItem> menuItems = new List<ClsMenuItem>
        {
            new ClsMenuItem{ItemId = 1, ItemName = "Pizza", Price = 50, Active = true, Category = "Snacks", Date_of_Launch = Convert.ToDateTime("2020-05-10"), FreeDelivery = "yes"},
            new ClsMenuItem{ItemId = 2, ItemName = "Burger", Price = 35, Active = true, Category = "Snacks", Date_of_Launch = Convert.ToDateTime("2020-05-15"), FreeDelivery = "yes"},
            new ClsMenuItem{ItemId = 3, ItemName = "Pasta", Price = 60, Active = true, Category = "Snacks", Date_of_Launch = Convert.ToDateTime("2020-05-15"), FreeDelivery = "yes"},
            new ClsMenuItem{ItemId = 4, ItemName = "Maggie", Price = 30, Active = true, Category = "Snacks", Date_of_Launch = Convert.ToDateTime("2020-05-15"), FreeDelivery = "yes"}
        };
        // GET: api/Truyum
        [HttpGet]
        public ActionResult<IEnumerable<ClsMenuItem>> GetMenuItems()
        {
            return menuItems;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<ClsMenuItem> GetItems(int id)
        {
            var mItem = menuItems.FirstOrDefault(item => item.ItemId == id);

            if (mItem == null)
            {
                return NotFound();
            }

            return mItem;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, ClsMenuItem item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                menuItems.Add(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<ClsMenuItem> PostItem(ClsMenuItem item)
        {
            menuItems.Add(item);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetItems", new { id = item.ItemId }, item);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public ActionResult<ClsMenuItem> DeleteItem(int id)
        {
            var item = menuItems.FirstOrDefault(item => item.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            menuItems.Remove(item);
            //await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(int id)
        {
            return menuItems.Any(e => e.ItemId == id);
        }
    }
}
