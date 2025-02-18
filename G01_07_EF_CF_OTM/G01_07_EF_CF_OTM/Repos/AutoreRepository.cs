using G01_07_EF_CF_OTM.Context;
using G01_07_EF_CF_OTM.Models;

namespace G01_07_EF_CF_OTM.Repos
{
    public class AutoreRepository : IRepoLettura<Autore>, IRepoScrittura<Autore>
    {
        private readonly LibreriaContext _context;
        public AutoreRepository(LibreriaContext libreriaContext)
        {
            _context = libreriaContext;
        }

        public bool Create(Autore entity)
        {
            bool risultato = false;

            try
            {
                _context.Autores.Add(entity);
                _context.SaveChanges();
                risultato = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return risultato;
        }

        public bool Delete(Autore entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Autore> GetAll()
        {
            return _context.Autores.ToList();
        }

        public Autore? GetById(int id)
        {
            return _context.Autores.FirstOrDefault(a => a.AutoreID == id);
        }

        public bool Update(Autore entity)
        {
            throw new NotImplementedException();
        }
    }
}
