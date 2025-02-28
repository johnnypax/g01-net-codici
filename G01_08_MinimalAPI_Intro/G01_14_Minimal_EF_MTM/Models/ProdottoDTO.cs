namespace G01_14_Minimal_EF_MTM.Models
{
    public class ProdottoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Prezzo { get; set; }

        public List<string> Categorias { get; set; } = new();

    }
}
