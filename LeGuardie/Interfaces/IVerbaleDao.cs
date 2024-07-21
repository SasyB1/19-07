using LeGuardie.Models.Dto;
using LeGuardie.Models;

namespace LeGuardie.Interfaces
{
    public interface IVerbaleDao
    {
        List<VerbaleDto> GetVerbals();
        void NewVerbal(VerbaleDto verbale);
        List<Anagrafica> GetUsers();
    }
}
