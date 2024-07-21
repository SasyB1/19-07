using LeGuardie.Models.Dto;
using LeGuardie.Models;

namespace LeGuardie.Interfaces
{
    public interface IVerbaleService
    {
        List<VerbaleDto> GetVerbals();
        void NewVerbal(VerbaleDto verbale);
        List<Violazione> GetViolations();
        List<Anagrafica> GetUsers();
    }
}
