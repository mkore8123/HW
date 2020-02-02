using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Logging;
using Swashbuckle.Models;

namespace Swashbuckle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Creates a Model.
        /// </summary>
        /// <param name="item"></param>
        [HttpPost("{item}")]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public ActionResult<ErrorViewModel> Create(ErrorViewModel item)
        {
            //_context.TodoItems.Add(item);
            //_context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { RequestId = "1" }, item);
        }

        /// <summary>
        /// Get a Model
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IEnumerable<ErrorViewModel> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ErrorViewModel
            {
                RequestId = "1"
            })
            .ToArray();
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary> 
        /// <param name="id"></param>        
        [HttpDelete("{id}")]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete123(long id)
        {
            var todo = string.Empty;
            //var todo = _context.TodoItems.Find(id);

            if (todo == null)
            {
                return NotFound();
            }

            //_context.TodoItems.Remove(todo);
            //_context.SaveChanges();

            return NoContent();
        }
    }
}
