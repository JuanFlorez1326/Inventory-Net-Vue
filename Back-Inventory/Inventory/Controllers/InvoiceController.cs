using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Inventory", "Welcome" };
        }
    }
}