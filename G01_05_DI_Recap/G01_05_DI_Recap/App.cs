using G01_05_DI_Recap.Context;
using G01_05_DI_Recap.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G01_05_DI_Recap
{
    internal class App
    {
        #region Iniezione del servizio
        private readonly LibreriaContex _context;

        public App(LibreriaContex dbContext)
        {
            _context = dbContext;
        }
        #endregion

        public async Task RunAsync()
        {
            var libri = await FindAllLibros();

            foreach (var libro in libri)
            {
                Console.WriteLine(libro);
            }
        }

        public async Task<List<Libro>> FindAllLibros()
        {
            return await _context.Libros.ToListAsync();
        }
    }
}
