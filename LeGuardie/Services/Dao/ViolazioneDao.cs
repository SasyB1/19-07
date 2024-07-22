using LeGuardie.Models;
using Microsoft.Data.SqlClient;
using LeGuardie.Interfaces;

namespace LeGuardie.Services.Dao
{
    public class ViolazioneDao : IViolazioneDao
    {
        private readonly IConfiguration _config;

        public ViolazioneDao(IConfiguration config)
        {
            _config = config;
        }

        public List<Violazione> GetViolations()
        {
            List<Violazione> violazioni = new List<Violazione>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_CMD = "SELECT IdViolazione, Descrizione FROM TIPO_VIOLAZIONE";
                    using (SqlCommand cmd = new SqlCommand(SELECT_CMD, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Violazione violazione = new Violazione
                                {
                                    IdViolazione = reader.GetInt32(0),
                                    Descrizione = reader.GetString(1)
                                };
                                violazioni.Add(violazione);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero delle violazioni", ex);
            }
            return violazioni;
        }
    }
}
