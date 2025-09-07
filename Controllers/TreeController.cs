using Microsoft.AspNetCore.Mvc;
using Test.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {


        // POST api/<ValuesController>
        [HttpPost]
        public void CreateTree([FromBody] string value)
        {
           Tree.Create(value);
        }

        [HttpGet]
        public string GetAdv(string value)
        {
            var i = Tree.FindNode(Tree.root, value)?.Children;
            var ii = i?.Where(x => x.Children.Count() == 0).ToList();

            return (ii == null || ii.Count == 0)? "Рекламных площадок не найдено" : String.Join(",", ii.Select(x => x.Value));
        }
    }
}
