namespace G01_14_Minimal_EF_MTM.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<ProdottoCategoria> ProdottoCategorias { get; set; } = new();

    }
}
