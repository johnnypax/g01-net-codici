namespace G01_07_EF_CF_OTM.Models
{
    public class AutoreDTO
    {
        public string Nom { get; set; } = null!;
        public string Cod { get; set; } = null!;
        public IEnumerable<LibroDTO>? Ele { get; set; }
    }
}
