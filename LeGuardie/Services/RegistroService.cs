using LeGuardie.Models.Dto;
using Microsoft.Data.SqlClient;


namespace LeGuardie.Services
{
    public class RegistroService
    {
        private readonly IConfiguration _config;

        public RegistroService(IConfiguration config)
        {
            _config = config;
        }

        public List<VerbaleDto> GetVerbalsForUsers()
        {
            List<VerbaleDto> verbals = new List<VerbaleDto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT a.Nome,a.Cognome,COUNT(v.IdVerbale) as TotaleVerbali FROM VERBALE AS V INNER JOIN ANAGRAFICA AS A ON A.IdAnagrafica= V.IdAnagrafica INNER JOIN TIPO_VIOLAZIONE AS T ON T.IdViolazione=V.IdViolazione GROUP BY a.Nome, a.Cognome ORDER BY TotaleVerbali DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleDto verbale = new VerbaleDto
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    TotaleVerbali = reader.GetInt32(2),
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

        public List<VerbaleDto> GetTotalPointsLost()
                    {
            List<VerbaleDto> verbals = new List<VerbaleDto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT Cognome, Nome, SUM(DecurtamentoPunti) AS TotalePunti FROM Anagrafica INNER JOIN Verbale ON Anagrafica.IdAnagrafica = Verbale.IDAnagrafica GROUP BY Cognome, Nome ORDER BY TotalePunti DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleDto verbale = new VerbaleDto
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    PuntiDecurtati = reader.GetInt32(2),
                                };
                                verbals.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei punti decurtati", ex);
            }
            return verbals;
        }

        public List<VerbaleDto> Greater10Points()
        {
            List<VerbaleDto> verbals = new List<VerbaleDto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT a.nome, a.cognome, v.importo, v.DataViolazione, v.DecurtamentoPunti FROM Anagrafica as a inner join verbale as v on a.IdAnagrafica = v.IDAnagrafica WHERE DecurtamentoPunti >= 10 ORDER BY DecurtamentoPunti DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleDto verbale = new VerbaleDto
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    Importo = reader.GetDecimal(2),
                                    DataViolazione = reader.GetDateTime(3),
                                    PuntiDecurtati = reader.GetInt32(4),
                                };
                                verbals.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei punti decurtati", ex);
            }
            return verbals;
        }

        public List<VerbaleDto> GetVerbals400()
        {
            List<VerbaleDto> verbals = new List<VerbaleDto>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT a.NOME , a.cognome , ve.importo , vi.descrizione FROM anagrafica as a inner join verbale as ve on ve.idanagrafica = a.IdAnagrafica inner join tipo_violazione as vi on ve.IDViolazione = vi.IDViolazione where ve.importo > 400 ORDER BY Importo DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleDto verbale = new VerbaleDto
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    Importo = reader.GetDecimal(2),
                                    Descrizione = reader.GetString(3),
                                };
                                verbals.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei punti decurtati", ex);
            }
            return verbals;
        }
    }
}
