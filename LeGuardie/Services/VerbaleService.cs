using LeGuardie.Models;
using LeGuardie.Models.Dto;
using Microsoft.Data.SqlClient;
using LeGuardie.Services.Dao;
using LeGuardie.Interfaces;
namespace LeGuardie.Services
{
    public class VerbaleService : IVerbaleService
    {
        private readonly IConfiguration _config;
        private readonly IVerbaleDao _verbaleDao;
        private readonly IViolazioneDao _violazioneDao;

        public VerbaleService(IConfiguration config, IVerbaleDao verbaleDao, IViolazioneDao violazioneDao)
        {
            _config = config;
            _verbaleDao = verbaleDao;
            _violazioneDao = violazioneDao;
        }

        public List<VerbaleDto> GetVerbals()
        {
            return _verbaleDao.GetVerbals();
        }


        public void NewVerbal(VerbaleDto verbale)
        {
          _verbaleDao.NewVerbal(verbale);
        }

        public List<Violazione> GetViolations()
        {
            return _violazioneDao.GetViolations();
        }
        public List<Anagrafica> GetUsers()
        {
            return _verbaleDao.GetUsers();
        }
        
    }
}
