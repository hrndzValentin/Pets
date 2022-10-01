using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetsApi.Dtos;

namespace PetsApi.Repositories
{
    public class Persona : DbContext
    {
        public DbSet<PersonaEntity> Persona1 { get; set; }

        public async Task<PersonaEntity?> Get(long id)
        {
            return await Persona1.FirstAsync(x => x.Id == id);
        }

        public async Task<PersonaEntity> Add(CreateCustomerDto customer)
        {
            PersonaEntity entity = new PersonaEntity()
            {
                Id = null,
                Nombre = customer.FirstName,
                Apellido = customer.LastName,
                Email = customer.Email,
                Direccion = customer.Address,
                Telefono = customer.Phone
};
            EntityEntry<PersonaEntity> response = await Persona1.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id ?? throw new Exception("no se ha podido guardar"));
        }
    }

    public class PersonaEntity
    {
        public long? Id { get; set; }

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
