using Domain.Core;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IPersonaDomain
    {
        Response<Persona> ObtenerPersona(int id);
    }
}
