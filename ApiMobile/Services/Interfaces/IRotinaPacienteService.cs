using ApiMobile.DTO;
using ApiMobile.Models;

namespace ApiMobile.Services.Interfaces
{
    public interface IRotinaPacienteService
    {
        Task<RotinaDto?> GetRotinaDoPaciente(int idPaciente, int idRotina);
        Task<List<RotinaDto>> GetAllRotinasDoPaciente(int idPaciente);
    }
}
