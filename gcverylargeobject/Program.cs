using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gcverylargeobject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;

            try
            {
                var myArray = new float[480431, 4748];
                // fill the array with a random float number
                var rnd = new Random();
                var myFloat = (float)rnd.NextDouble();
                for ( i = 0; i < myArray.GetLength(0); i++)
                {
                    if (i%1000==0) Console.WriteLine($"iteration i:{i}");
                    for ( j = 0; j < myArray.GetLength(1); j++)
                    {
                        myArray[i, j] = myFloat;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"iteration i:{i} j:{j} --> {e}");
            }
            finally
            {
                Console.WriteLine("finished!");
                Console.ReadLine();
            }

        }

        private static void StringTest()
        {
            int i = 0;
            // generate an array of 50 strings, all copies of the first string
            string[] s2 = new string[50];
            for (i = 0; i < s2.Length; i++)
            {
                s2[i] = new string('1', 100000000);
                if (i % 5 == 0)
                {
                    Console.WriteLine("Allocated {0} MB", i * 100);
                }
            }
            Console.WriteLine("Allocated 100*50 MB");
        }

        private static void ByteArrayExperiment()
        {
            // generate a bytearray of 100MB and initialize it with all 1s
            byte[] b = new byte[100 * 1024 * 1024];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = 1;
            }
            Console.WriteLine("Allocated first array");

            // now allocate a new array of bytearrays, 25 elements and every element is a copy of the first array
            byte[][] b2 = new byte[50][];
            for (int i = 0; i < b2.Length; i++)
            {
                b2[i] = new byte[b.Length];
                Array.Copy(b, b2[i], b.Length);
                if (i % 5 == 0)
                {
                    Console.WriteLine("Allocated {0} MB", i * 100);
                }
            }
            Console.WriteLine("Allocated 100*50 MB");
        }
    }
}
