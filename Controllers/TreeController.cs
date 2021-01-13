using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShenAlgorithms.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShenAlgorithms.Controllers
{
    [Controller]
    [Route("rbtree/[controller]")]
    public class TreeController : Controller
    {
        private readonly TreeService _treeService;
        public TreeController(TreeService treeService)
        {
            _treeService = treeService;
        }
        [HttpPost]
        public async Task CreateTree(int n)
        {
            _treeService.CreateRBTree(n);
        }
    }
}