using ApiMobile.Models;
using ApiMobile.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRMController : ControllerBase
    {
        private readonly ICRMApiService _crmApiService;

        public CRMController(ICRMApiService crmApiService)
        {
            _crmApiService = crmApiService;
        }

        [HttpGet]
        public async Task<ActionResult<ConsultaCRMResult>> GetCRM(string numero, string uf)
        {
            var crms = await _crmApiService.GetMedicosAsync(numero, uf);

            return crms;
        }
    }
}
