
using Dapper;
using G01_03_Dapper_Intro.Models;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

string credenziali = "" +
    "Server=BOOK-N57JVKH6HJ\\SQLEXPRESS;" +
    "Database=g01_01_dapper_intro;" +
    "User Id=academy;" +
    "Password=academy!;" +
    "MultipleActiveResultSets=true;" +
    "Encrypt=false;" +
    "TrustServerCertificate=false";

using (SqlConnection conn = new SqlConnection(credenziali))
{
    var sw = Stopwatch.StartNew();

    var risultato = conn.Query<Persona>(
        "SELECT personaID, nome, cognome, cod_fis, numero_mezzi" +
        "   FROM Persona " +
        "   WHERE nome = @nome AND cognome = @cognome;", 
        new {
            @nome = "Luca",
            @cognome = "Bianchi"
        });

    sw.Stop();
    Console.WriteLine($"{sw.ElapsedMilliseconds}");

    foreach (Persona p in risultato)
        Console.WriteLine(p);
}