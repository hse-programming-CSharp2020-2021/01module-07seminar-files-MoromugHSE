using System;
using System.IO;
using System.Text;
/*
 * По массиву A целых чисел со значениями из диапазона (1; 10000] создать массив целых чисел B,
 * в котором на каждой позиции стоит ближайшая степень двойки меньшая значения из массива A у той же позиции.
 * Например, A = {30, 100, 300} B = {16, 64, 256}.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 3 10 20
 *
 * Пример выходных данных:
 * 2 8 16
 */

namespace Task02
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
            for (int i = 0; i < parsed.Length; ++i)
            {
                parsed[i] = int.Parse(unparsed[i]);
            }
            return parsed;
        }
        
        static bool CheckArray(int[] array)
        {
            // TODO: implement this method
            foreach(var el in array)
            {
                if (el <= 1 || el > 10 * 1000)
                {
                    return false;
                }
            }
            return true;
        }

        private static int MyLog(int x)
        {
            int log = 0;
            while (x > 1)
            {
                ++log;
                x >>= 1;
            }
            return log;
        }
        
        static int[] ConvertArray(int[] array)
        {
            // TODO: implement this method
            int[] newArr = new int[array.Length];
            for (int i = 0; i < array.Length; ++i)
            {
                int log = MyLog(array[i]);
                newArr[i] = 1 << log;
                if (newArr[i] == array[i])
                {
                    newArr[i] >>= 1;
                }
            }
            return newArr;
        }

        static void WriteFile(string path, int[] array)
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

        // you do not need to fill your file manually, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            int[] B;
            
            try
            {
                A = ReadFile(inputPath);
                
                if (!CheckArray(A))
                // TODO: implement this case
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                B = ConvertArray(A);
                WriteFile(outputPath, B);
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