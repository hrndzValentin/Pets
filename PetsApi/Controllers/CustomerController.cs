using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsApi.Dtos;
using PetsApi.Repositories;

namespace PetsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {

        private readonly Persona _Persona;

        public CustomerController(Persona persona)
        {
            _Persona = persona;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<IActionResult> GetCustomer(long id)
        {
            CustomerDto customer = new CustomerDto();

            return new OkObjectResult(customer);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<List<CustomerDto>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult>  PostCustomer(CreateCustomerDto customer)
        {
            var vacio = new CustomerDto();
            return new CreatedResult($"https://localhost:7158/api/customer/{vacio.Id}", null);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<CustomerDto> PutCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

    }
}
