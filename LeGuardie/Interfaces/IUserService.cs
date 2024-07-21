using LeGuardie.Models.Dto;

namespace LeGuardie.Interfaces
{
    public interface IUserService
    {
        List<AnagraficaDto> GetUsers();
        void RegisterUser(AnagraficaDto user);
    }
}
