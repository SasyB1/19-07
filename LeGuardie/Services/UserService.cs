using LeGuardie.Models.Dto;
using Microsoft.Data.SqlClient;

namespace LeGuardie.Services
{
    public class UserService
    {
        private readonly IConfiguration _config;

        public UserService(IConfiguration config)
        {
            _config = config;
        }
        public List<AnagraficaDto> GetUsers()
        {
            List<AnagraficaDto> users = new List<AnagraficaDto>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_CMD = "select * from anagrafica";
                    using (SqlCommand cmd = new SqlCommand(SELECT_CMD, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AnagraficaDto user = new AnagraficaDto
                                {  
                                    Cognome = reader.GetString(1),
                                    Nome = reader.GetString(2),
                                    Indirizzo = reader.GetString(3),
                                    Citta = reader.GetString(4),
                                    CAP = reader.GetString(5),
                                    CodiceFiscale = reader.GetString(6)
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero delle anagrafiche", ex);
            }
            return users;
        }

        public void RegisterUser(AnagraficaDto user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT_CMD = "insert into anagrafica (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) values (@cognome, @nome, @indirizzo, @citta, @cap, @codice_fiscale)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@cognome", user.Cognome);
                        cmd.Parameters.AddWithValue("@nome", user.Nome);
                        cmd.Parameters.AddWithValue("@indirizzo", user.Indirizzo);
                        cmd.Parameters.AddWithValue("@citta", user.Citta);
                        cmd.Parameters.AddWithValue("@cap", user.CAP);
                        cmd.Parameters.AddWithValue("@codice_fiscale", user.CodiceFiscale);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'inserimento dell'anagrafica", ex);
            }
        }
    }
} 
