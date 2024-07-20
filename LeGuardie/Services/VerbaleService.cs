using LeGuardie.Models;
using LeGuardie.Models.Dto;
using Microsoft.Data.SqlClient;
using LeGuardie.Services.Dao;
namespace LeGuardie.Services
{
    public class VerbaleService
    {
        private readonly IConfiguration _config;
        private readonly VerbaleDao _verbaleDao;
        private readonly ViolazioneDao _violazioneDao;

        public VerbaleService(IConfiguration config, VerbaleDao verbaleDao, ViolazioneDao violazioneDao)
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
            List<Anagrafica> anagrafiche = new List<Anagrafica>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_CMD = "SELECT * FROM ANAGRAFICA";
                    using (SqlCommand cmd = new SqlCommand(SELECT_CMD, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Anagrafica anagrafica = new Anagrafica
                                {
                                    IdUtente = reader.GetInt32(0),
                                    Nome = reader.GetString(1),
                                    Cognome = reader.GetString(2),
                                    Indirizzo = reader.GetString(3),
                                    Citta = reader.GetString(4),
                                    CAP = reader.GetString(5),
                                    CodiceFiscale = reader.GetString(6)
                                };
                                anagrafiche.Add(anagrafica);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero delle anagrafiche", ex);
            }
            return anagrafiche;
        }
    }
}
