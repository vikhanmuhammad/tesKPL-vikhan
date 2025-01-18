namespace teskpl_vikhan
{
    public class Students
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public int Umur { get; set; }
        public string Jurusan { get; set; }

        public Students(string nama, int umur, string jurusan)
        {
            this.Nama = nama;
            this.Umur = umur;
            this.Jurusan = jurusan;
        }
    }
}
