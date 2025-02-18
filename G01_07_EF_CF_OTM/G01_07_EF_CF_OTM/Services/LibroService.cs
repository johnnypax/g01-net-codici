using G01_07_EF_CF_OTM.Models;
using G01_07_EF_CF_OTM.Repos;

namespace G01_07_EF_CF_OTM.Services
{
    public class LibroService : IService<LibroDTO>
    {
        private readonly LibroRepository _repo;

        public LibroService(LibroRepository repo)
        {
            _repo = repo;
        }

        public LibroDTO? CercaPerCodice(string codice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibroDTO> CercaTutti()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibroDTO> CercaPerAutore(int id)
        {
            ICollection<LibroDTO> risultato = new List<LibroDTO>();

            var elencoLibri = _repo.GetByAutore(id);
            foreach (var l in elencoLibri)
            {
                LibroDTO temp = new LibroDTO()
                {
                    Tit = l.Titolo
                };

                risultato.Add(temp);
            }

            return risultato;
        }

        public bool Elimina(LibroDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(LibroDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Modifica(LibroDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
