using Microsoft.AspNetCore.Http;
using ApiMobile.Services;
using Microsoft.AspNetCore.Mvc;
using ApiMobile.Models;
using Microsoft.EntityFrameworkCore;

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
            
            var crms = await _crmApiService.GetMedicos(numero, uf);

            return crms;
        }
    }
}
