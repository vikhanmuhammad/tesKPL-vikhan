namespace teskpl_vikhan
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Inisialisasi 2 objek singleton
            DatabaseSingleton ds1 = DatabaseSingleton.GetInstance();
            DatabaseSingleton ds2 = DatabaseSingleton.GetInstance();

            Console.WriteLine("Mengisi data di ds1 dengan isi 'data awal'.");
            ds1.updateData("data awal");

            Console.Write("Berikut adalah isi ds1 : ");
            ds1.printData();

            Console.Write("Berikut adalah isi ds2 : ");
            ds2.printData();

            Console.WriteLine();
            Console.WriteLine("Mengisi data di ds2 dengan isi 'data terbaru'.");
            ds1.updateData("data terbaru");

            Console.Write("Berikut adalah isi ds1 : ");
            ds1.printData();

            Console.Write("Berikut adalah isi ds2 : ");
            ds2.printData();
        }
    }
    public sealed class DatabaseSingleton
    {
        private DatabaseSingleton() { }

        private static DatabaseSingleton _instance;
        public static string data;

        public static DatabaseSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseSingleton();
            }
            return _instance;
        }
        public void updateData(string update)
        {
            data = update;
        }

        public void printData()
        {
            Console.WriteLine(data);
        }
    }
}
