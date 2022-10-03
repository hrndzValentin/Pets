using Domain.Entities.Models;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class PersonaDomain : IPersonaDomain
    {
        private readonly VeterinariaContext _context;

        public PersonaDomain(VeterinariaContext context)
        {
            _context = context;
        }

        public Response<Persona> ObtenerPersona(int id)
        {
            Response<Persona> response = new Response<Persona>();

            Persona? persona = _context.Personas.Where(persona => persona.Id == id).FirstOrDefault();

            if (persona is not null)
            {
                response.Data = persona;
                response.Message = "Persona consultada exitosamente";
                response.IsSuccess = true;
            }
            else 
            {
                response.Message = $"No se pudo encontrar una persona con el Id: {id}";
            }

            return response;
        }

        public Response<bool> InsertarPersona(Persona persona)
        {
            Response<bool> response = new Response<bool>();
            _context.Personas.Add(persona);
            _context.SaveChanges();

            response.id = persona.Id;

            return response;
        }

    }
}
