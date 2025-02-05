using System;
using System.Diagnostics;

namespace G01_01_Span_Memory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //char[] caratteri = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };
            //Span<char> spanCaratteri = caratteri.AsSpan(6, 5);
            //Console.WriteLine(spanCaratteri.ToString());

            const int counter = 10_000_000;

            #region Variabile standard
            var sw = Stopwatch.StartNew();

            for(int i=0; i< counter; i++)
            {
                char[] caratteri = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };
                _ = caratteri[2];
            }

            sw.Stop();
            Console.WriteLine($"Tempo Variabile: {sw.ElapsedMilliseconds}");
            #endregion

            #region Tempo con SPAN
            char[] caratteri1 = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };

            var sw1 = Stopwatch.StartNew();

            for (int i = 0; i < counter; i++)
            {
                Span<char> spanCaratteri = caratteri1.AsSpan();
                _ = spanCaratteri[2];
            }

            sw1.Stop();
            Console.WriteLine($"Tempo Span: {sw1.ElapsedMilliseconds}");
            #endregion

            #region Tempo con SPAN
            char[] caratteri2 = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };

            var sw2 = Stopwatch.StartNew();

            for (int i = 0; i < counter; i++)
            {
                Memory<char> spanCaratteri2 = caratteri2.AsMemory();
                _ = spanCaratteri2.Span[2];
            }

            sw2.Stop();
            Console.WriteLine($"Tempo Memory: {sw2.ElapsedMilliseconds}");
            #endregion
        }
    }
}
