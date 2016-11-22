using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class LocaleController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            //string st = System.IO.File.ReadAllText("Data/locale.json");

            JObject o = getJson();
                //JObject.Parse(st);
            return new ObjectResult(o);
        }

        [HttpGet("{lang}")]
        public IActionResult GetByLang(string lang)
        {
            JObject obj = getJson();

            foreach (var x in obj)
            {
                string name = x.Key;
                if (name.ToLowerInvariant() == lang.ToLowerInvariant())
                {
                    return new ObjectResult(x.Value);
                }
            }

            return new ObjectResult(String.Empty);
        }

        private JObject getJson()
        {
            string st = System.IO.File.ReadAllText("Data/locale.json");
            return JObject.Parse(st);
        }
    }

}