using ApiMobile.Models;

namespace ApiMobile.Services.Interfaces
{
    public interface IRotinaPacienteService
    {
        Task<Rotina?> GetRotinaDoPaciente(int idPaciente, int idRotina);
    }
}
