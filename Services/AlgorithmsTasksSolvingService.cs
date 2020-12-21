using System;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using Newtonsoft.Json;

namespace ShenAlgorithms.Services
{
    public class AlgorithmsTasksSolvingService
    {
        public AlgorithmsTasksSolvingService()
        {           
        }
        public async Task<string> Task1_1_1(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            
            var t = a;
            a = b;
            b = t;

            result += $"a = {a}, b = {b}\n";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_2(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            
            a = a + b;
            b = a - b;
            a = a - b;

            result += $"a = {a}, b = {b}\n";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_3(int a = 3, int n = 5)
        {
            string result = "";
            result += $"a = {a}, n = {n}\n";
            int k = 0, b = 1;
            b = a;
            while(k < n)
            {
                k++;
                b = b* a;
            }
            result += $"result = {b}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_4(int a = 3, int n = 5)
        {
            string result = "";
            result += $"a = {a}, n = {n}\n";
            int k = n, b = 1, c = a;
            while(k > 0)
            {
                if(k % 2 == 0)
                {
                    k = k / 2;
                    c = c * c;
                }
                else
                {
                    k = k - 1;
                    b = b * c;
                }
            }
            result += $"result = {b}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_5(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            
            int k = 0;

            while(b > 0)
            {
                k = k + a;
                b--;
            }

            result += $"result = {k}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_6(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            int k = 0;

            while(k < b)
            {
                k = k + 1;
                a = a + 1;
            }           

            result += $"result = {a}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_7(int a = 5, int b = 3)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            int k = 0;

            int q = 0, r = a;
            if(!(a >= 0 && b > 0))
                return result += "a или b не удовлетворяют условиям";
            
            while(r >= b)
            {
                r = r - b;
                q++;
            }

            result += $"q = {q}, r = {r}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_8(int n = 5)
        {
            string result = "";
            result += $"n = {n}\n";
            int k = n;

            while(n > 1)
            {
                k = k * (n - 1);
                n--;
            }

            result += $"n! = {k}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_9(int n = 5)
        {
            string result = "";
            result += $"n = {n}\n";
            int A0 = 0, A1 = 1;

            if(n < 2)
                return result += "n not condition";

            int k = 1, Ak = 0;
            while(k<n)
            {
                Ak = A0 + A1;                
                A0 = A1;
                A1 = Ak;
                k++;
            }

            result += $"fibonachi An = {Ak}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_10(int n = 5)
        {
            string result = "";
            result += $"n = {n}\n";
            double Ak = 0;

            double[,] m = 
                {
                    {1, 1},
                    {1, 0}
                };

            var M = Matrix<double>.Build.DenseOfArray(m);
            var M2 = M;

            while(n>2)
            {
                n--;
                M2 = M2.Multiply(M);
            }
            Ak = M2[0,0];
            System.Console.WriteLine($"M2:\n {M2.ToString()}");
            result += $"fibonachi An = {Ak}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_11(int n = 5)
        {
            string result = "";
            result += $"n = {n}\n";
            double res = 0;
            for(int i = 0; i <= n; i++)
            {
                double[,] m = 
                    {
                        {1, 1},
                        {1, 0}
                    };

                var M = Matrix<double>.Build.DenseOfArray(m);
                var M2 = M;

                var j = i;
                while(j>2)
                {
                    j--;
                    M2 = M2.Multiply(M);
                }
                res += 1/M2[0,0];
            }
            
            result += $"fibonachi res = {res}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_13_1(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            int k = 0;
            if(a < b)
            {
                k = a;
            }
            else
                k = b;

            while(!(a % k == 0 && b % k == 0))
            {
                k--;
            }

            result += $"NOD = {k}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_13_2(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            int m = a, n = b;
            int k = 0;
            while(m != 0 || n != 0)
            {
                if(m > n)
                    m = m - n;
                else
                    n = n - m;

                if(m == 0)
                {
                    k = n;
                    break;
                }
                else if(n == 0)
                {
                    k = m;
                    break;
                }
            }

            result += $"NOD = {k}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_14(int a = 3, int b = 5)
        {
            string result = "";
            result += $"a = {a}, b = {b}\n";
            int k = 0;
            if(a < b)
            {
                k = a;
            }
            else
                k = b;

            while(!(a % k == 0 && b % k == 0))
            {
                k--;
            }

            result += $"NOD = {k}";
            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_1_15(int a, int b)
        {
            string result = "";

            int d = 0;
            int m = 0;
            int n = 0;
            int k = 0;

            k = a < b ? a : b;
            while(!(a%k == 0 && b%k == 0))
            {
                k--;
            }
            d = k;
            result += $"d = {d}";

            return await Task.FromResult<string>(result);
        }
        public async Task<string> Task1_2_1(int n)
        {
            string result = "";
            int[] arr = new int[n];
            var rnd = new Random();
            for(int i=0;i<n;i++)
            {
                arr[i] = rnd.Next(0, n);
            }
            System.Console.WriteLine($"{JsonConvert.SerializeObject(arr)}");
            for(int i =0; i<n; i++)
            {
                arr[i]=0;
            }
            System.Console.WriteLine($"{JsonConvert.SerializeObject(arr)}");
            result = JsonConvert.SerializeObject(arr);
            return await Task.FromResult<string>(result);
        }
        public async Task<int> Task1_2_2(int n)
        {
            int result = 0;
            int[] arr = new int[n];
            FillRandomArray(ref arr);
            for(int i =0; i<n; i++)
            {
                if(arr[i] == 0)
                {
                    result++;
                }
            }
            System.Console.WriteLine($"{JsonConvert.SerializeObject(arr)}");
            return await Task.FromResult<int>(result);
        }
        public async Task<int> Task1_2_4(int n)
        {
            int max = 0;
            int[] arr = new int[n];
            var rnd = new Random();
            FillRandomArray(ref arr);
            for( int i = 0; i < arr.Length; i++)
            {
                if(max < arr[i])
                    max = arr[i];
            }            
            return await Task.FromResult<int>(max);
        }
        public async Task<int> Task1_2_5(int n)
        {
            int number = 0;
            int numberCount = 0;
            int[] arr = new int[n];
            var rnd = new Random();
            FillSortedArray(ref arr);
            for(int i = 0; i < arr.Length; i++)
            {
                if(number != arr[i])
                {
                    numberCount++;
                    number = arr[i];
                }
            }
            return await Task.FromResult<int>(numberCount);
        }
        public async Task<string> Task1_2_6(int n)
        {
            int numberCount = 0;
            int[] arr = new int[n];
            var rnd = new Random();
            FillRandomArray(ref arr);
            bool flag = false;
            System.Console.WriteLine($"{JsonConvert.SerializeObject(arr)}");

            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    if(arr[i] == arr[j] && i != j)
                    {
                        flag = true;
                        break;
                    }
                }
                if(!flag)
                    numberCount++;
                flag = false;
            }
            return await Task.FromResult<string>($"array: {JsonConvert.SerializeObject(arr)}\nnumberCount: {numberCount}");
        }
        // public async Task<int> Task1_2_7(int n)
        // {
        //     int number = 0;
        //     int numberCount = 0;
        //     try
        //     {
        //         var array = new int[] { 1, 2 };
        //         Console.Write(array[5]);
        //     }
        //     catch(ApplicationException e)
        //     {
        //         Console.Write(1);
        //     }
        //     catch(SystemException e)
        //     {
        //         Console.Write(2);
        //     }
        //     catch(Exception e)
        //     {
        //         Console.Write(3);
        //     }
        //     Console.ReadLine();
        //     return await Task.FromResult<int>(numberCount);
        // }
        // public async Task<int> Task1_2_9(int m, int n)
        // {
        //     if(m==0 || n ==0)
        //         await Task.FromResult<int>(0);
        //     int numberCount = 0;
        //     int[,] area = new int[m,n];
        //     CreateAndFillArea(ref area, m, n);

        //     return await Task.FromResult<int>(numberCount);
        // }
        private void CreateAndFillArea(ref int[,] area, int m, int n)
        {
            var minSideLength = m > n ? n : m;
            
        }
        private void FillRandomArray(ref int[] arr)
        {
            var rnd = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, arr.Length);
            }
        }
        private void FillSortedArray(ref int[] arr)
        {
            var rnd = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, arr.Length);
            }
            BubleSort(ref arr);
            // Array.Sort<int>(arr);
            System.Console.WriteLine($"{JsonConvert.SerializeObject(arr)}");
        }
        private void BubleSort(ref int[] arr)
        {
            for(int i = 0; i< arr.Length; i++)
            {
                for(int j = i; j < arr.Length; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        var tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }
    }
}