using G01_07_EF_CF_OTM.Models;
using G01_07_EF_CF_OTM.Repos;
using System.Collections.Generic;

namespace G01_07_EF_CF_OTM.Services
{
    public class AutoreService : IService<AutoreDTO>
    {
        private readonly AutoreRepository _repo;
        private readonly LibroService _libService;
        
        public AutoreService(AutoreRepository autoreRepository, LibroService libroService)
        {
            _repo = autoreRepository;
            _libService = libroService;
        }

        public AutoreDTO? CercaPerCodice(string codice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutoreDTO> CercaTutti()
        {
            ICollection<AutoreDTO> risultato = new List<AutoreDTO>();

            IEnumerable<Autore> autori = _repo.GetAll();
            foreach (Autore a in autori)
            {
                AutoreDTO temp = new AutoreDTO()
                {
                    Cod = a.Codice,
                    Nom = a.Nome,
                    Ele = _libService.CercaPerAutore(a.AutoreID)
                };

                risultato.Add(temp);
            }

            return risultato;
        }

        public bool Elimina(AutoreDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Inserisci(AutoreDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Modifica(AutoreDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
