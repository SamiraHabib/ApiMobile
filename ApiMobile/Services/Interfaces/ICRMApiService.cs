using ApiMobile.DTO;

namespace ApiMobile.Services.Interfaces
{
    public interface ICRMApiService
    {
        Task<ConsultaCRMResult> GetMedicosAsync(string numero, string uf);
    }
}