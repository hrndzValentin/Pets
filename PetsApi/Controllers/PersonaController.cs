using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        #region Variables
        private readonly IPersonaDomain _personaDomain;
        #endregion

        #region Constructor
        public PersonaController(IPersonaDomain personaDomain)
        {
            _personaDomain = personaDomain;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public IActionResult ObtenerAlumnoPorId(int id) 
        {
            var response = _personaDomain.ObtenerPersona(id);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        #endregion
    }
}
