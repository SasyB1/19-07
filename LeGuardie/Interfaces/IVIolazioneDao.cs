using LeGuardie.Models;

namespace LeGuardie.Interfaces
{
    public interface IViolazioneDao
    {
        List<Violazione> GetViolations();
    }
}
