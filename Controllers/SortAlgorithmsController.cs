using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShenAlgorithms.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShenAlgorithms.Controllers
{
    [Controller]

    [Route("sortalgorithms/[controller]")]
    public class SortAlgorithmsController : Controller
    {
        private readonly SortAlgorithmsService _sortAlgorithmService;
        public SortAlgorithmsController(SortAlgorithmsService sortAlgorithmService)
        {
            _sortAlgorithmService = sortAlgorithmService;
        }
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1. Быстрая сортировка")]
        public async Task<string> QuickSort(int arraySize) =>
            await _sortAlgorithmService.Quick_Sort(arraySize);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "2. Cортировка слиянием")]
        public async Task<string> MergeSort(int arraySize) =>
            await _sortAlgorithmService.Merge_Sort(arraySize);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "3. Шейкер сорт")]
        public async Task<string> ShakerSort(int arraySize) =>
            await _sortAlgorithmService.Shaker_Sort(arraySize);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "4. Сортировка подсчетом")]
        public async Task<string> CountingSort(int arraySize) =>
            await _sortAlgorithmService.Counting_Sort(arraySize);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "5. Получить медиану O(n log n)")]
        public async Task<string> GetMedian(int arraySize) =>
            await _sortAlgorithmService.GetMediannlogn(arraySize);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "6. Получить медиану O(n)")]
        public async Task<string> GetMedianOn(int arraySize) =>
            await _sortAlgorithmService.GetMedianOn(arraySize);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "7. Получить медиану. Метод медиан пятерок O(n)")]
        public async Task<string> GetMedian5(int arraySize) =>
            await _sortAlgorithmService.GetMedian5(arraySize);

    }
}