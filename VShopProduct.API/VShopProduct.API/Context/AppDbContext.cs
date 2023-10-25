using Microsoft.EntityFrameworkCore;
using VShopProduct.API.Models;

namespace VShopProduct.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasKey(ent => ent.CategoryId);

            mb.Entity<Category>()
                .Property(ent => ent.Name)
                    .HasMaxLength(100).IsRequired();

            mb.Entity<Product>()
                .Property(ent => ent.Name)
                    .HasMaxLength(100).IsRequired();

            mb.Entity<Product>()
                .Property(ent => ent.Description)
                    .HasMaxLength(255).IsRequired();     
            
            mb.Entity<Product>()
                .Property(ent => ent.ImageURL)
                    .HasMaxLength(255).IsRequired();            
            
            mb.Entity<Product>()
                .Property(ent => ent.Price)
                    .HasPrecision(12,2);

            mb.Entity<Category>()
                .HasMany(g => g.Products)
                    .WithOne(c => c.Category)
                        .IsRequired()
                            .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Acessórios"
                });
        }
    }
}
