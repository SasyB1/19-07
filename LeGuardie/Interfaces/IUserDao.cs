using LeGuardie.Models.Dto;

namespace LeGuardie.Interfaces
{
    public interface IUserDao
    {
        List<AnagraficaDto> GetUsers();
        void RegisterUser(AnagraficaDto user);
    }
}
