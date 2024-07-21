using LeGuardie.Models.Dto;
using Microsoft.Data.SqlClient;
using LeGuardie.Interfaces;

namespace LeGuardie.Services.Dao
{
    public class UserDao : IUserDao
    {
        private readonly IConfiguration _config;

        public UserDao(IConfiguration config)
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

        public bool IsUserExists(string cognome, string nome)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                const string CHECK_CMD = "SELECT COUNT(1) FROM anagrafica WHERE Cognome = @cognome AND Nome = @nome";
                using (SqlCommand cmd = new SqlCommand(CHECK_CMD, conn))
                {
                    cmd.Parameters.AddWithValue("@cognome", cognome);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public void RegisterUser(AnagraficaDto user)
        {
            if (IsUserExists(user.Cognome, user.Nome))
            {
                throw new InvalidOperationException("Utente gia' presente in elenco.");
            }

            using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                const string INSERT_CMD = "INSERT INTO anagrafica (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc) VALUES (@cognome, @nome, @indirizzo, @citta, @cap, @codice_fiscale)";
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
    }
}
