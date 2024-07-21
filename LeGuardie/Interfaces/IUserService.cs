using LeGuardie.Models.Dto;

namespace LeGuardie.Interfaces
{
    public interface IUserService
    {
        List<AnagraficaDto> GetUsers();

        public bool IsUserExists(string cognome, string nome);
        void RegisterUser(AnagraficaDto user);
    }
}
