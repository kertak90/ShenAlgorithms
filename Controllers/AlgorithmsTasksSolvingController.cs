using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShenAlgorithms.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ShenAlgorithms.Controllers
{
    [Controller]

    [Route("algorithms/[controller]")]
    public class AlgorithmsTasksSolvingController : Controller
    {
        private readonly AlgorithmsTasksSolvingService _algorithmsTasksSolvingService;
        public AlgorithmsTasksSolvingController(AlgorithmsTasksSolvingService algorithmsTasksSolvingService)
        {
            _algorithmsTasksSolvingService = algorithmsTasksSolvingService;
        }
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.1 Даны две целые переменные a, b. Составьте фрагмент про-"
            + "граммы, после исполнения которого значения переменных поменялись"
            + "бы местами (новое значение a равно старому значению b и наоборот)")]
        public async Task<string> Task1_1_1(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_1(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.2 Решите предыдущую задачу, не используя дополнительных"
            + "переменных (и предполагая, что значениями целых переменных могут"
            + "быть произвольные целые числа).")]
        public async Task<string> Task1_1_2(int a, int b) =>
            await _algorithmsTasksSolvingService.Task1_1_2(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.3 Дано целое число а и натуральное (целое неотрицательное)"
            + "число n. Вычислите an. Другими словами, необходимо составить про-"
            + "грамму, при исполнении которой значения переменных а и n не меняют-"
            + "ся, а значение некоторой другой переменной (например, b) становится"
            + "равным an. (При этом разрешается использовать и другие переменные.)")]
        public async Task<string> Task1_1_3(int a, int n) => 
            await _algorithmsTasksSolvingService.Task1_1_3(a, n);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.4 Решите предыдущую задачу, если требуется, чтобы число"
            + "действий (выполняемых операторов присваивания) было порядка log n"
            + "(то есть не превосходило бы log n для некоторой константы ; log n"
            + "это степень, в которую нужно возвести 2, чтобы получить n).")]
        public async Task<string> Task1_1_4(int a, int n) => 
            await _algorithmsTasksSolvingService.Task1_1_4(a, n);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.5 Даны натуральные числа a, b. Вычислите произведение a * b"
            + "используя в программе лишь операции +, -, =, !=")]
        public async Task<string> Task1_1_5(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_5(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.6 Даны натуральные числа a и b. Вычислите их сумму a + b,"
            + "используйте операторы присваивания лишь вида: p1 = p2, p = value, p1 = p2 + 1")]
        public async Task<string> Task1_1_6(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_6(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.7 дано натуральное число (целое не отрицательное) a и целое положительное"
            + "число d. Вычислите частное q и остаток от деления r пр делении a на d, не используя операций / и %")]
        public async Task<string> Task1_1_7(int a, int b) =>
            await _algorithmsTasksSolvingService.Task1_1_7(a, b);
        
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.8 Дано натуральное n, вычислите n!")]
        public async Task<string> Task1_1_8(int n) =>
            await _algorithmsTasksSolvingService.Task1_1_8(n);
        
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.9 Последовательность Фибоначи определяется так: A0 = 0,"
            + "A1 = 1, Ak = Ak-1 + Ak-2 при k >= 2. Дано n, вычислите An")]
        public async Task<string> Task1_1_9(int n) =>
            await _algorithmsTasksSolvingService.Task1_1_9(n);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.10 Последовательность фибоначи. Определить An пропорционально log n")]
        public async Task<string> Task1_1_10(int n) =>
            await _algorithmsTasksSolvingService.Task1_1_10(n);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.11 Дано натуральное число n, вычислите 1/0! + 1/1! + ... + 1/n!")]
        public async Task<string> Task1_1_11(int n) =>
            await _algorithmsTasksSolvingService.Task1_1_11(n);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.13_1 Даны два натуральных числа a и b, не равные нулю одновременно."
            + "Вычислите НОД(a,b) наибольший общий делитель a и b")]
        public async Task<string> Task1_1_13_1(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_13_1(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.13_2 Даны два натуральных числа a и b, не равные нулю одновременно."
            + "Вычислите НОД(a,b) наибольший общий делитель a и b алгоритмом Евклида")]
        public async Task<string> Task1_1_13_2(int a, int b) => 
            await _algorithmsTasksSolvingService.Task1_1_13_2(a, b);

        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.1.15 Даны натуральные a и b, не равные нулю одновременно. Найдите"
            + "d = НОД(a,b) и такие целые x и y, что d = a*x + b*y")]
        public async Task<string> Task1_1_15(int a, int b) =>
            await _algorithmsTasksSolvingService.Task1_1_15(a, b);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.2.1 Заполните массив нулями, независимо от начального значения переменной x")]
        public async Task<string> Task1_2_1(int n) =>
            await _algorithmsTasksSolvingService.Task1_2_1(n);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.2.2 Подсчитайте количество нулей в массиве x."
            + "Составьте фрагмент программы, не меняющий значения х, после исполнения"
            + " которого значение некоторой целой переменной k равнялось бы числу нулей среди"
            + "компонент массива k")]
        public async Task<int> Task1_2_2(int n) =>
            await _algorithmsTasksSolvingService.Task1_2_2(n);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.2.4 Найдите максимум массива")]
        public async Task<int> Task1_2_4(int n) =>
            await _algorithmsTasksSolvingService.Task1_2_4(n);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.2.5 Дан массив x, причем x[1] <= x[2] <= ... <= x[n]"
            + "Найдите количество различных чисел среди элементов массива")]
        public async Task<int> Task1_2_5(int n) =>
            await _algorithmsTasksSolvingService.Task1_2_5(n);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.2.6 Дан массив x, array[1..n] of integer"
            + "Найдите количество различных чисел среди элементов массива, чтобы количество действий"
            + "был порядка n^2")]
        public async Task<string> Task1_2_6(int n) =>
            await _algorithmsTasksSolvingService.Task1_2_6(n);
        [HttpPost("[action]")]
        [SwaggerOperation(Description = "1.2.7 Дан массив x, причем x[1] <= x[2] <= ... <= x[n]"
            + "Найдите количество различных чисел среди элементов массива, чтобы количество действий"
            + "был порядка log n")]
        public async Task<int> Task1_2_7(int n) =>
            await _algorithmsTasksSolvingService.Task1_2_7(n);
    }
}