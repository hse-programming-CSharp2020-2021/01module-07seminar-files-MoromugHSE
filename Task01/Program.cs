using System;
using System.IO;
using System.Text;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        
        static int[] ReadFile(string path)
        {
            // TODO: implement this method
            string[] unparsed = File.ReadAllText(path).Split();
            int[] parsed = new int[unparsed.Length];
            for (int i=0; i < parsed.Length; ++i)
            {
                parsed[i] = int.Parse(unparsed[i]);
            }
            return parsed;
        }

        static bool CheckArray(int[] array)
        {
            // TODO: implement this method
            foreach (var el in array)
            {
                if (el < -10 || el > 10)
                {
                    return false;
                }
            }
            return true;
        }
        
        static bool[] IntToBoolArray(int[] array)
        {
            // TODO: implement this method
            bool[] arr = new bool[array.Length];
            for (int i=0; i < arr.Length; ++i)
            {
                arr[i] = array[i] < 0 ? false : true;
            }
            return arr;
        }
        
        static void WriteFile(string path, bool[] array)
        {
            // TODO: implement this method
            StringBuilder sb = new StringBuilder();
            foreach (var el in array)
            {
                if (sb.ToString() != "")
                {
                    sb.Append(" ");
                }
                sb.Append(el.ToString());
            }
            File.WriteAllText(path, sb.ToString().ToLower());
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            bool[] L;
            
            try
            {
                A = ReadFile(inputPath);
                
                if (!CheckArray(A))
                // TODO: implement this case
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
            }
            // TODO: catch with meaningful message
            catch (Exception)
            {
                Console.WriteLine("Incorrect Input");
                return;
            }
            
            // do not touch
            ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}