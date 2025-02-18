using G01_07_EF_CF_OTM.Context;
using G01_07_EF_CF_OTM.Models;

namespace G01_07_EF_CF_OTM.Repos
{
    public class LibroRepository : IRepoLettura<Libro>
    {
        private readonly LibreriaContext _context;
        public LibroRepository(LibreriaContext libreriaContext)
        {
            _context = libreriaContext;
        }

        public IEnumerable<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.FirstOrDefault(a => a.LibroId == id);
        }

        public IEnumerable<Libro> GetByAutore(int rif)
        {
            return _context.Libros.Where(l => l.AutoreRIF == rif).ToList();
        }
    }
}
