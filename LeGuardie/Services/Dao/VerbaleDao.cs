using LeGuardie.Models;
using LeGuardie.Models.Dto;
using Microsoft.Data.SqlClient;

namespace LeGuardie.Services.Dao
{
    public class VerbaleDao
    {
        private readonly IConfiguration _config;

        public VerbaleDao(IConfiguration config)
        {
            _config = config;
        }

        public List<VerbaleDto> GetVerbals()
        {
            List<VerbaleDto> verbals = new List<VerbaleDto>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_CMD = @"SELECT v.IdVerbale,a.IdAnagrafica,a.Nome,a.Cognome,v.IdViolazione,t.Descrizione,v.DataViolazione,v.IndirizzoViolazione,v.Nominativo_Agente,v.DataTrascrizioneVerbale,v.Importo,v.DecurtamentoPunti FROM VERBALE AS V INNER JOIN ANAGRAFICA AS A ON A.IdAnagrafica=V.IdAnagrafica INNER JOIN TIPO_VIOLAZIONE AS T ON T.IdViolazione = V.IdViolazione";
                    using (SqlCommand cmd = new SqlCommand(SELECT_CMD, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleDto verbale = new VerbaleDto
                                {
                                    IdVerbale = reader.GetInt32(0),
                                    IdUtente = reader.GetInt32(1),
                                    Nome = reader.GetString(2),
                                    Cognome = reader.GetString(3),
                                    IdViolazione = reader.GetInt32(4),
                                    Descrizione = reader.GetString(5),
                                    DataViolazione = reader.GetDateTime(6),
                                    IndirizzoViolazione = reader.GetString(7),
                                    NomeAgente = reader.GetString(8),
                                    DataTrascrizione = reader.GetDateTime(9),
                                    Importo = reader.GetDecimal(10),
                                    PuntiDecurtati = reader.GetInt32(11)
                                };
                                verbals.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei verbali", ex);
            }
            return verbals;
        }
        public void NewVerbal(VerbaleDto verbale)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT_CMD = "insert into VERBALE (IdAnagrafica,IdViolazione,DataViolazione,IndirizzoViolazione,Nominativo_Agente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti) values (@IdUtente,@IdViolazione,@DataViolazione,@IndirizzoViolazione,@NomeAgente,@DataTrascrizione,@Importo,@PuntiDecurtati)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUtente", verbale.IdUtente);
                        cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                        cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                        cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                        cmd.Parameters.AddWithValue("@NomeAgente", verbale.NomeAgente);
                        cmd.Parameters.AddWithValue("@DataTrascrizione", verbale.DataTrascrizione);
                        cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                        cmd.Parameters.AddWithValue("@PuntiDecurtati", verbale.PuntiDecurtati);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'inserimento del verbale", ex);
            }
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
