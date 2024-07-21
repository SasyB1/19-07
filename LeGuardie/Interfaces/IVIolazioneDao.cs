using LeGuardie.Models;

namespace LeGuardie.Interfaces
{
    public interface IVIolazioneDao
    {
        List<Violazione> GetViolations();
    }
}
