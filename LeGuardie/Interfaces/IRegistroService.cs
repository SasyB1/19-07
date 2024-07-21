using LeGuardie.Models.Dto;

namespace LeGuardie.Interfaces
{
    public interface IRegistroService
    {
        List<VerbaleDto> GetVerbalsForUsers();
        List<VerbaleDto> GetTotalPointsLost();
        List<VerbaleDto> Greater10Points();
        List<VerbaleDto> GetVerbals400();
    }
}
