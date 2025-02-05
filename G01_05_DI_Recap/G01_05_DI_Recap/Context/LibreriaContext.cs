using G01_05_DI_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G01_05_DI_Recap.Context
{
    internal class LibreriaContex : DbContext
    {
        public LibreriaContex(DbContextOptions<LibreriaContex> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
    }
}
