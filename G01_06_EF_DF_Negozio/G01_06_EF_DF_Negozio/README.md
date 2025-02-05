Inserire questa stringa nella console di gestione pacchetti

```batch
Scaffold-DbContext "Server=BOOK-N57JVKH6HJ\SQLEXPRESS;Database=g01_04_DF_Negozio;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables Prodotto
```