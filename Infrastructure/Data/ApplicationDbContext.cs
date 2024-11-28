using Core;
using Core.BethanysPieShopHR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }

    #region BethanysPieShopHRM
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<JobCategory> JobCategories { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //var createdOn = DateTime.Now;
        //int i = 1;
        //var categories = new List<Category>()
        //{
        //    new Category{ Id = i++, Name = "Pasta", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Ris", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Olja", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Konserver", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Konserver", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Färdigmat", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Kryddor", CreatedDate = createdOn},

        //    new Category{ Id = i++, Name = "Ägg", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Kaffe", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Ost", CreatedDate = createdOn},
        //    new Category{ Id = i++,Name = "Pasta", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Krossade Tomater", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Olja", CreatedDate = createdOn},
        //    new Category{ Id = i++,Name = "Ketchup", CreatedDate = createdOn},
        //    new Category{ Id = i++,Name = "Saffran", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Hund- & kattmat", CreatedDate = createdOn},
            
        //    new Category{ Id = i++, Name = "Kött", CreatedDate = createdOn},
        //    new Category{ Id = i++,Name = "Grönsaker", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Mejerivaror", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Spannmål", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Frukt & bär", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Potatis & rotfrukter", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Fågel", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Honung & socker", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Fisk & skaldjur", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Svamp", CreatedDate = createdOn},
        //    new Category{ Id = i++, Name = "Blommor & växter", CreatedDate = createdOn},
        //};
        //modelBuilder.Entity<Category>().HasData(categories);

        #region BethanysPieShopHRM
        modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Belgium" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Germany" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Netherlands" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "USA" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Japan" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 6, Name = "China" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 7, Name = "UK" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 8, Name = "France" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 9, Name = "Brazil" });

        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 1, Name = "Pie research" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 2, Name = "Sales" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 3, Name = "Management" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 4, Name = "Store staff" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 5, Name = "Finance" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 6, Name = "QA" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 7, Name = "IT" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 8, Name = "Cleaning" });
        modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { Id = 9, Name = "Bakery" });

        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1,
            CountryId = 1,
            MaritalStatus = MaritalStatus.Single,
            BirthDate = new DateTime(1979, 1, 16),
            City = "Brussels",
            Email = "bethany@bethanyspieshop.com",
            FirstName = "Bethany",
            LastName = "Smith",
            Gender = Gender.Female,
            PhoneNumber = "324777888773",
            Smoker = false,
            Street = "Grote Markt 1",
            Zip = "1000",
            JobCategoryId = 1,
            Comment = "Lorem Ipsum",
            ExitDate = null,
            JoinedDate = new DateTime(2015, 3, 1),
            Latitude = 50.8503,
            Longitude = 4.3517
        });
        #endregion
    }
}
