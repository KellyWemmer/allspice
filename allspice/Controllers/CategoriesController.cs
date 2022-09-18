using System;
using System.Collections.Generic;
using System.Linq;
using allspice.Enums;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetCategories()

        {
            List<string> list = Enum.GetValues(typeof(CategoryEnum))
            .Cast<CategoryEnum>()
            .Select(v => v.ToString())
            .ToList();

            return Ok(list);
        }        
    }
}