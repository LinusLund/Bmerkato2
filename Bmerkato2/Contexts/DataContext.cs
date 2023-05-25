using Bmerkato2.Models.Entities;
using Bmerkato2.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerkato2.Contexts
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        //Tabeller för User-relaterade saker.
        public DbSet<AddressEntity> Adresses { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }

        //Kontaktformuläret
        public DbSet<ContactFormEntity> ContactFormsSubmitted { get; set; }

        //Tabeller för Product-relaterade saker.
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductTagEntity> ProductTags { get; set; }

    }
}
