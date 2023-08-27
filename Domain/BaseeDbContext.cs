using Microsoft.EntityFrameworkCore;

namespace WebMvcTelefonRehberi.Domain
{
    public class BaseeDbContext : DbContext
    {

        public DbSet<Kisi> Kisiler { get; set; }

        //public DbSet<Ogrenci> Ogrenciler { get; set; }
        //public DbSet<Ogretmen> Ogretmenler { get; set; }
        //public DbSet<Plan> Planlar { get; set; }
        //public DbSet<Sinif> Siniflar { get; set; }
        //public DbSet<Yoklama> Yoklamalar { get; set; }
        //public DbSet<Kullanici> Kullanicilar { get; set; }

        public BaseeDbContext()
        {

        }

        public BaseeDbContext(DbContextOptions<BaseeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Server=.;Database=OkulDb5142;User Id=sa;password=123");
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=TelRehber;User Id=postgres;Password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Brans>().Property(e => e.BransAdi).HasMaxLength(50);
            //modelBuilder.Entity<Brans>().HasData(
            //            new Brans { BransAdi = "Matematik", Id = 1 },
            //            new Brans { BransAdi = "Fizik", Id = 2 },
            //            new Brans { BransAdi = "Muzik", Id = 3 },
            //            new Brans { BransAdi = "Tarih", Id = 4 },
            //            new Brans { BransAdi = "Kimya", Id = 5 },
            //            new Brans { BransAdi = "Edebiyat", Id = 6 }
            //);


            #region Kisi
            modelBuilder.Entity<Kisi>().Property(e => e.Adi).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Kisi>().Property(e => e.Soyadi).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Kisi>().Property(e => e.Email).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Kisi>().Property(e => e.Gsm).HasMaxLength(15);
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi { Adi = "Ali", Soyadi = "Veli", Email = "ali@veli.com", Gsm = "5551112233", Id = 1 }
                );




            #endregion


            //#region Ogretmen
            //modelBuilder.Entity<Ogretmen>().Property(e => e.Adi).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Ogretmen>().Property(e => e.Soyadi).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Ogretmen>().Property(e => e.TcNo).HasMaxLength(11).IsRequired();
            //modelBuilder.Entity<Ogretmen>().Property(e => e.Gsm).HasMaxLength(15);

            //modelBuilder.Entity<Ogretmen>().HasData(
            //   new Ogretmen { Adi = "Ayse", Soyadi = "Yilmaz", TcNo = "12345678901", BransId = 1, Id = 1 }
            //   );

            //modelBuilder.Entity<Ogretmen>()
            //                   .HasOne(b => b.Brans)
            //                   .WithMany(a => a.Ogretmenler)
            //                   .OnDelete(DeleteBehavior.Restrict);


            //#endregion



            //#region Sinif
            //modelBuilder.Entity<Sinif>().Property(e => e.SinifAdi).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Sinif>().HasData(
            //    new Sinif { SinifAdi = "11A", Kapasite = 30, Id = 1 },
            //    new Sinif { SinifAdi = "12A", Kapasite = 30, Id = 2 },
            //    new Sinif { SinifAdi = "13A", Kapasite = 30, Id = 3 },
            //    new Sinif { SinifAdi = "14A", Kapasite = 30, Id = 4 }
            //    );

            //#endregion

            //#region Plan
            //modelBuilder.Entity<Plan>()
            //    .HasOne(p => p.Brans)
            //    .WithMany(a => a.Planlar)
            //     .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Plan>()
            //    .HasOne(p => p.Sinif)
            //    .WithMany(a => a.Planlar)
            //     .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Plan>()
            //    .HasOne(p => p.Ogretmen)
            //    .WithMany(a => a.Planlar)
            //     .OnDelete(DeleteBehavior.Restrict);


            //#endregion



            //#region Yoklama
            //modelBuilder.Entity<Yoklama>()
            //        .HasOne(yoklamalar => yoklamalar.Ogrenci)
            //        .WithMany(ogrenci => ogrenci.Yoklamalar)
            //         .OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<Yoklama>()
            //    .HasOne(yoklamalar => yoklamalar.Plan)
            //    .WithMany(plan => plan.Yoklamalar)
            //    .OnDelete(DeleteBehavior.Restrict);

            //#endregion

            //#region Kullanicilar
            //modelBuilder.Entity<Kullanici>()
            //    .Property(x => x.UserName)
            //    .HasMaxLength(20)
            //    .IsRequired();


            //modelBuilder.Entity<Kullanici>()
            //    .Property(x => x.Password)
            //    .HasMaxLength(50)
            //    .IsRequired();

            //modelBuilder.Entity<Kullanici>()
            //    .Property(x => x.Role)
            //    .HasMaxLength(20)
            //    .HasDefaultValue<string>("user");



            //#endregion


        }
    }
}
