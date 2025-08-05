using Microsoft.AspNetCore.Mvc;
using WidgetApi.Data;
using WidgetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WidgetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WidgetsController : ControllerBase
    {
        private readonly WidgetContext _context;

        public WidgetsController(WidgetContext context)
        {
            _context = context;
        }

        // GET: api/widgets
        [HttpGet]
        public ActionResult<IEnumerable<Widget>> GetWidgets()
        {
            return _context.Widgets.ToList();
        }

        // GET: api/widgets/5
        [HttpGet("{id}")]
        public ActionResult<Widget> GetWidget(int id)
        {
            var widget = _context.Widgets.Find(id);
            if (widget == null)
            {
                return NotFound();
            }
            return widget;
        }

        // POST: api/widgets
        [HttpPost]
        public ActionResult<Widget> PostWidget(Widget widget)
        {
            _context.Widgets.Add(widget);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetWidget), new { id = widget.Id }, widget);
        }

        // PUT: api/widgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWidget(int id, Widget widget)
        {
            if (id != widget.Id)
            {
                return BadRequest();
            }

            _context.Entry(widget).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        // DELETE: api/widgets/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWidget(int id)
        {
            var widget = _context.Widgets.Find(id);
            if (widget == null)
            {
                return NotFound();
            }

            _context.Widgets.Remove(widget);
            _context.SaveChanges();

            return NoContent();
        }

        private bool WidgetExists(int id)
        {
            return _context.Widgets.Any(e => e.Id == id);
        }

    }
}
