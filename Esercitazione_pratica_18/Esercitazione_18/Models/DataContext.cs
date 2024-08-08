using Microsoft.EntityFrameworkCore;

namespace Esercitazione_18.Models
{
    public class DataContext : DbContext
    {
        // Definisco le tabelle del database
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        
        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuro la relazione molti-a-molti tra Product e Ingredient
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Ingredients)
                .WithMany(i => i.Products)
                .UsingEntity(j => j.ToTable("IngredientProduct"));

            // Configuro la relazione molti-a-molti tra User e Role
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity(j => j.ToTable("RoleUser"));

            // Configuro la relazione uno-a-molti tra Order e OrderItem
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(op => op.Order)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuro la relazione uno-a-molti tra Product e OrderItem
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(op => op.Product)
                .OnDelete(DeleteBehavior.Cascade);

            // Inserisco i dati iniziali per i ruoli
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Client" }
            );
        }
    }
}
