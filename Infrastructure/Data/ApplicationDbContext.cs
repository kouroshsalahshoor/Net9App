using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var createdOn = DateTime.Now;
        int i = 1;
        var categories = new List<Category>()
        {
            new Category{ Id = i++, Name = "Pasta", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Ris", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Olja", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Konserver", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Konserver", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Färdigmat", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Kryddor", CreatedDate = createdOn},

            new Category{ Id = i++, Name = "Ägg", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Kaffe", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Ost", CreatedDate = createdOn},
            new Category{ Id = i++,Name = "Pasta", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Krossade Tomater", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Olja", CreatedDate = createdOn},
            new Category{ Id = i++,Name = "Ketchup", CreatedDate = createdOn},
            new Category{ Id = i++,Name = "Saffran", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Hund- & kattmat", CreatedDate = createdOn},
            
            new Category{ Id = i++, Name = "Kött", CreatedDate = createdOn},
            new Category{ Id = i++,Name = "Grönsaker", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Mejerivaror", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Spannmål", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Frukt & bär", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Potatis & rotfrukter", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Fågel", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Honung & socker", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Fisk & skaldjur", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Svamp", CreatedDate = createdOn},
            new Category{ Id = i++, Name = "Blommor & växter", CreatedDate = createdOn},
        };
        builder.Entity<Category>().HasData(categories);
    }
}
