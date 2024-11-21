using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ridel.Domain.Entities;
using Ridel.Domain.Entities.Role;
using Ridel.Domain.ValueObjects.Order;

namespace Ridel.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        // DbSet Tanımlamaları
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Dispatcher> Dispatchers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionPackage> SubscriptionPackages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<VehicleFeature> VehicleFeatures { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        // OnModelCreating metodunu override ediyoruz
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Subscription>(entity =>
            {
                entity.HasOne(s => s.User)
                      .WithMany(u => u.Subscriptions)
                      .HasForeignKey(s => s.UserId)
                      .IsRequired();

                entity.HasOne(s => s.SubscriptionPackage)
                      .WithMany(sp => sp.Subscriptions)  // SubscriptionPackage'ın birden fazla Subscription'ı olabilir
                      .HasForeignKey(s => s.SubscriptionPackageId)  // Yabancı anahtar ilişkiyi kurar
                      .IsRequired();
            });

            // Subscription ile SubscriptionPackage arasında ilişki tanımlanabilir
            //builder.Entity<Subscription>()
            //    .HasOne(s => s.SubscriptionPackage)
            //    .WithMany()
            //    .HasForeignKey(s => s.SubscriptionPackageId)
            //    .OnDelete(DeleteBehavior.Restrict); // İlişkili paketin silinmesini kısıtla

            //builder.Entity<Subscription>()
            //    .Property(s => s.Type)
            //    .HasConversion<string>(); // Enum'ı string olarak sakla

            //builder.Entity<Subscription>(entity =>
            //{
            //    entity.HasOne(s => s.User)
            //          .WithMany(u => u.Subscriptions) // Kullanıcı ile bir-to-many ilişki
            //          .HasForeignKey(s => s.UserId)
            //          .IsRequired();

            //    entity.HasOne(s => s.SubscriptionPackage)
            //          .WithMany()
            //          .HasForeignKey(s => s.SubscriptionPackageId)
            //          .IsRequired();
            //});

            //builder.Entity<SubscriptionPackage>(entity =>
            //{
            //    entity.Property(p => p.Name)
            //          .IsRequired()
            //          .HasMaxLength(100); // Paket adı zorunlu ve 100 karakter uzunluğunda olacak

            //    entity.Property(p => p.Price)
            //          .IsRequired(); // Fiyat zorunlu

            //    entity.Property(p => p.DurationInDays)
            //          .IsRequired(); // Süre zorunlu
            //});

            // User ve UserDetail arasındaki birebir ilişki
            builder.Entity<User>()
                .HasOne(u => u.UserDetail)
                .WithOne(ud => ud.User)
                .HasForeignKey<UserDetail>(ud => ud.UserId);

            // Vehicle ve VehicleType arasındaki ilişkiyi tanımla
            builder.Entity<Vehicle>()
                .HasOne(v => v.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Vehicle ve VehicleFeature arasındaki ilişkiyi tanımla
            builder.Entity<Vehicle>()
                .HasMany(v => v.Features)
                .WithMany(f => f.Vehicles);

            // Vehicle ve VehiclePhoto arasındaki ilişkiyi tanımla
            builder.Entity<VehiclePhoto>()
                .HasOne(p => p.Vehicle)
                .WithMany(v => v.Photos)
                .HasForeignKey(p => p.VehicleId)
                .OnDelete(DeleteBehavior.Cascade); // Araç silinirse, ona bağlı tüm fotoğraflar silinir


            // Order ve User arasındaki ilişkiyi tanımla
            builder.Entity<Order>()
                .HasOne(o => o.CreatedByUser)
                .WithMany()
                .HasForeignKey(o => o.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Offer ve User arasındaki ilişkiyi tanımla
            builder.Entity<Offer>()
                .HasOne(o => o.AcceptedByUser)
                .WithMany()
                .HasForeignKey(o => o.AcceptedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Offer ve Order arasındaki ilişkiyi tanımla
            builder.Entity<Offer>()
                .HasOne(o => o.Order)
                .WithOne(o => o.Offer) // Her siparişin yalnızca bir teklifi olabilir
                .HasForeignKey<Offer>(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade); // Order silinirse, ona bağlı Offer da silinir


            // Trip ve Order arasındaki ilişkiyi tanımla
            builder.Entity<Trip>()
                .HasOne(t => t.Order)
                .WithOne(o => o.Trip)
                .HasForeignKey<Trip>(t => t.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Trip ve User (Driver) arasındaki ilişkiyi tanımla
            builder.Entity<Trip>()
                .HasOne(t => t.Driver)
                .WithMany()
                .HasForeignKey(t => t.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Trip ve User (Dispatcher) arasındaki ilişkiyi tanımla
            builder.Entity<Trip>()
                .HasOne(t => t.Dispatcher)
                .WithMany()
                .HasForeignKey(t => t.DispatcherId)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment ve User arasındaki ilişkiyi tanımla
            builder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
