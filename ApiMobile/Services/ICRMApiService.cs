using ApiMobile.Models;
namespace ApiMobile.Services
{
    public interface ICRMApiService
    {
        Task<ConsultaCRMResult> GetMedicosAsync(string numero, string uf);
    }
}