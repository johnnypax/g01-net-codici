namespace G01_07_EF_CF_OTM.Models
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Titolo { get; set; } = null!;
        public int AutoreRIF { get; set; }

        public Autore AutoreNav { get; set; } = null!;
    }
}
