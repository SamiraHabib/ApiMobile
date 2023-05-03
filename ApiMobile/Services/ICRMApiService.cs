using ApiMobile.Models;
namespace ApiMobile.Services
{
    public interface ICRMApiService
    {
        Task<ConsultaCRMResult> GetMedicos(string numero, string uf);
    }
}