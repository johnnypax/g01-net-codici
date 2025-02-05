namespace G01_02_Diagnostica_GC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simulazione Garbage Collector avviata, premi ENTER.");
            Console.ReadLine();

            GC.AddMemoryPressure(10 * 1000 * 1024);

            //Thread.Sleep(1000);

            OggetiTemporanei();

            //Thread.Sleep(4000);

            OggettiLungaDurata();

            //Thread.Sleep(4000);

            
            GC.Collect();                               //Forza la collezione
            GC.RemoveMemoryPressure(10 * 1000 * 1024);

            Console.WriteLine("Monitoraggio della memoria...");
            Console.WriteLine($"Memoria totale allocata: {GC.GetTotalMemory(false) / 1024 / 1024} MB");
            Console.WriteLine($"Collezioni Gen 0: {GC.CollectionCount(0)}");
            Console.WriteLine($"Collezioni Gen 1: {GC.CollectionCount(1)}");
            Console.WriteLine($"Collezioni Gen 2: {GC.CollectionCount(2)}\n");

        }

        static void OggetiTemporanei()
        {
            Console.WriteLine("Allocazione oggetti temporanei - GEN0");
            for (int i = 0; i < 1000; i++)
            {
                byte[] bytes = new byte[1024];  //1 KB per ogg.
            }
            Console.WriteLine("Allocazione oggetti temporanei completata!");
        }

        static void OggettiLungaDurata()
        {
            Console.WriteLine("Allocazione oggetti a lunga durata - GEN2");
            List<byte[]> list = new List<byte[]>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new byte[10 * 1000 * 1024]);
                Thread.Sleep(1500);
            }
            Console.WriteLine("Allocazione oggetti a lunga durata completata!");
        }
    }
}
