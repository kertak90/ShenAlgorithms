using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShenAlgorithms.Services
{
    public class SomeArrayAlgorithmsService
    {
        public Task<string> PalindromN3(string str)
        {
            int palindromesCnt = 0;
            var palindromes = new List<string>();
            for(int leftBorder = 0; leftBorder < str.Length; leftBorder++)
            {
                for(int rightBorder = leftBorder+1; rightBorder < str.Length; rightBorder++)
                {
                    if(IsPalindromes(str, leftBorder, rightBorder))
                    {
                        palindromesCnt++;
                        var palindrome = str.Substring(leftBorder, rightBorder - leftBorder +1);
                        System.Console.WriteLine(palindrome);
                        palindromes.Add(palindrome);
                    }
                }
            }
            return Task.FromResult<string>(JsonConvert.SerializeObject(palindromes));
        }

        private bool IsPalindromes(string str, int leftBorder, int rightBorder)
        {
            while(leftBorder <= rightBorder)
            {
                if(str[leftBorder]!=str[rightBorder])
                {
                    return false;
                }
                leftBorder++;
                rightBorder--;
            }
            return true;
        }
        public Task<string> PalindromeN2(string str)
        {
            int palindromesCnt = 0;
            var palindromes = new List<string>();
            for(int midleIndex = 0; midleIndex < str.Length; midleIndex++)
            {
                var leftBorder = midleIndex;
                var rightBorder = midleIndex + 1;
                if(leftBorder >= 0
                    && rightBorder < str.Length)
                {
                    Compare(leftBorder, rightBorder, str, ref palindromes, ref palindromesCnt);
                }
            }
            for(int midleIndex = 0; midleIndex < str.Length; midleIndex++)
            {
                var leftBorder = midleIndex - 1;
                var rightBorder = midleIndex + 1;
                if(leftBorder >= 0
                    && rightBorder < str.Length)
                {
                    Compare(leftBorder, rightBorder, str, ref palindromes, ref palindromesCnt);
                }
            }
            return Task.FromResult<string>(JsonConvert.SerializeObject(palindromes));
        }
        void Compare(int leftBorder, int rightBorder, string str, ref List<string> palindromes, ref int palindromesCnt)
        {
            while(leftBorder >= 0
                && rightBorder < str.Length
                && str[leftBorder] == str[rightBorder])
            {
                if(str[leftBorder] == str[rightBorder])
                {
                    var palindrome = str.Substring(leftBorder, rightBorder - leftBorder +1);
                    System.Console.WriteLine(palindrome);
                    palindromes.Add(palindrome);
                    leftBorder--;
                    rightBorder++;
                    palindromesCnt++;
                }
            }
        }
        public Task<string> NOP(string str1, string str2)
        {
            var rowCount = str1.Length;
            var columnCount = str2.Length;
            int[,] map = new int[rowCount + 1, columnCount + 1];
            for(int i = 1; i <= rowCount; i++)
            {
                for(int j = 1; j <= columnCount; j++)
                {
                    if(str1[i-1] == str2[j-1])
                    {
                        map[i,j] = map[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        map[i, j] = map[i, j - 1] > map[i - 1, j] 
                            ? map[i, j - 1] 
                            : map[i - 1, j];
                    }
                }
            }
            PrintMap(map, str1, str2);
            var result = new string(PrintNOP(map, str1, str2).ToCharArray().Reverse().ToArray());
            System.Console.WriteLine(result);
            return Task.FromResult<string>(result);
        }
        private void PrintMap(int[,] map, string str1, string str2)
        {
            System.Console.WriteLine($"result:");
            for(int k = 0; k < str1.Length; k++)
            {
                System.Console.Write($"{str1[k]} ");
            }
            System.Console.WriteLine();
            for(int k = 0; k < str2.Length; k++)
            {
                System.Console.Write($"{str2[k]} ");
            }
            System.Console.WriteLine();

            for(int i = 0; i < str2.Length + 1; i++)
            {
                for(int j = 0; j < str1.Length + 1; j++)
                {
                    System.Console.Write($"{map[j, i]} ");
                }
                System.Console.WriteLine();
            }
        }
        private string PrintNOP(int[,] map, string str1, string str2)
        {
            var result = "";
            int row = str2.Length, column = str1.Length;
            while(row >= 0 && column >= 0 && map[column, row] > 0)
            {
                if(map[column - 1, row] == map[column, row - 1])
                {
                    if(map[column - 1, row - 1] != map[column, row])
                        result += str2[row - 1];
                    column--;
                    row--;
                }
                else if(map[column - 1, row] > map[column, row - 1] && map[column - 1, row] != 0)
                {
                    column--;
                }
                else if(map[column - 1, row] < map[column, row - 1] && map[column, row - 1] != 0)
                {
                    row--;
                }
            }
            return result;
        }
    }
}