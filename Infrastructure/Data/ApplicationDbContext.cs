using Core;
using Core.BethanysPieShopHR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<ApplicationUser> Users { get; set; }

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

        var createdOn = DateTime.Now;
        int i = 1;
        var categories = new List<Category>()
        {
            //https://www.matsmart.se/alla-produkter
            // https://www.mathem.se/se/products/

            new Category{ Id = i++, Name = "Mejeri"},
            new Category{ Id = i++, Name = "Pasta"},
            new Category{ Id = i++, Name = "Spagetti"},
            new Category{ Id = i++, Name = "Ris"},
            new Category{ Id = i++, Name = "Matgryn"},
            new Category{ Id = i++, Name = "Konserver"},
            new Category{ Id = i++, Name = "Kryddor"},
            new Category{ Id = i++, Name = "Oljor"},
            new Category{ Id = i++, Name = "Såser"},
            new Category{ Id = i++, Name = "Kaffe"},
            new Category{ Id = i++, Name = "Te"},
            new Category{ Id = i++, Name = "Flingor"},
            new Category{ Id = i++, Name = "Gryn"},
            new Category{ Id = i++, Name = "Musli"},
            new Category{ Id = i++, Name = "Sylt"},
            new Category{ Id = i++, Name = "Marmelad"},
            new Category{ Id = i++, Name = "Mjöl"},
            new Category{ Id = i++, Name = "Bakelser"},
            new Category{ Id = i++, Name = "Dessert"},
            new Category{ Id = i++, Name = "Övrig Skafferi"},
            
            new Category{ Id = i++, Name = "Färdigmat"},

            new Category{ Id = i++, Name = "Spannmål"},
            new Category{ Id = i++, Name = "Honung & Söcker"},
            
            new Category{ Id = i++, Name = "Bröd"},
            new Category{ Id = i++, Name = "Bageri"},

            new Category{ Id = i++, Name = "Glass"},
            new Category{ Id = i++, Name = "Godis"},
            new Category{ Id = i++, Name = "Chocklad"},
            new Category{ Id = i++, Name = "Chips"},
            new Category{ Id = i++, Name = "Nötter"},
            new Category{ Id = i++, Name = "Torkade frukt"},
            new Category{ Id = i++, Name = "Fröer"},
            new Category{ Id = i++, Name = "Tuggummi"},
            new Category{ Id = i++, Name = "Lakris"},
            new Category{ Id = i++, Name = "övrig Godis & snack"},

            new Category{ Id = i++, Name = "Rotfrukter"},
            new Category{ Id = i++,Name = "Grönsaker"},
            new Category{ Id = i++, Name = "Frukt & bär"},
            //new Category{ Id = i++, Name = "Svamp"},

            new Category{ Id = i++, Name = "Nöt Kött"},
            new Category{ Id = i++, Name = "Gris Kött"},
            new Category{ Id = i++, Name = "Fågel"},
            new Category{ Id = i++, Name = "Fisk & skaldjur"},

            new Category{ Id = i++, Name = "Läsk"},
            new Category{ Id = i++, Name = "Vatten"},
            new Category{ Id = i++, Name = "Juice"},
            new Category{ Id = i++, Name = "Smoothie"},
            new Category{ Id = i++, Name = "Saft"},
            new Category{ Id = i++, Name = "Energ & Sport Dryck"},
            new Category{ Id = i++, Name = "Växtbaserade Dryck"},
            new Category{ Id = i++, Name = "Övrig Dryck"},

            new Category{ Id = i++, Name = "Hem & Hushåll"},

            new Category{ Id = i++, Name = "Hund & katt"},

            new Category{ Id = i++, Name = "Blommor & växter"},
        };
        modelBuilder.Entity<Category>().HasData(categories);

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
