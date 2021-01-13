using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShenAlgorithms.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShenAlgorithms.Controllers
{
    [Controller]

    [Route("somearrayalgorithms/[controller]")]
    public class SomeArrayAlgorithmsController : Controller
    {
        private readonly SomeArrayAlgorithmsService _someArrayAlgorithmsService;
        public SomeArrayAlgorithmsController(SomeArrayAlgorithmsService someArrayAlgorithmsService)
        {
            _someArrayAlgorithmsService = someArrayAlgorithmsService;
        }
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1. Нахождение палиндромов в строке, Сложность алгоритма O(N^3)")]
        public async Task<string> PalindromN3(string str) =>
            await _someArrayAlgorithmsService.PalindromN3(str);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "2. Нахождение палиндромов в строке, Сложность алгоритма N^2 + N^2 = 2N^2 т.е. O(N^2)")]
        public async Task<string> PalindromN2(string str) =>
            await _someArrayAlgorithmsService.PalindromeN2(str);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "3. Наибольшая общая подпоследовательность O(N^2)")]
        public async Task<string> NOP(string str1, string str2) =>
            await _someArrayAlgorithmsService.NOP(str1, str2);
    }
}