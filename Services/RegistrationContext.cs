using FranksKaffeehaus.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FranksKaffeehaus.Services
{
    public class RegistrationContext : DbContext
    {
        public RegistrationContext (DbContextOptions<RegistrationContext> options) : base(options) 
        {
        
        }

        public DbSet<RegistrationViewModel> Users { get; set; } // This is a PROPERTY (not an ATTRIBUTE)
    }
}
