using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace G01_06_EF_DF_Negozio.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Nome { get; set; } = null!;

    public decimal? Prezzo { get; set; }

    public string Codice { get; set; } = null!;
}
