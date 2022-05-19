using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cinehub.Models
{
    public partial class CinehubContext : DbContext
    {
        public CinehubContext()
        {
        }

        public CinehubContext(DbContextOptions<CinehubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<ScreenType> ScreenTypes { get; set; } = null!;
        public virtual DbSet<Show> Shows { get; set; } = null!;
        public virtual DbSet<ShowTiming> ShowTimings { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cinehub;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.NoOfSeats).HasColumnName("noOfSeats");

                entity.Property(e => e.SeatNumbers)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("seatNumbers");

                entity.Property(e => e.ShowTimeId).HasColumnName("showTimeId");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.ShowTime)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ShowTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__showTim__70DDC3D8");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__usernam__71D1E811");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId)
                    .ValueGeneratedNever()
                    .HasColumnName("genreId");

                entity.Property(e => e.Genre1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("genre");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => new { e.SessionNo, e.Username })
                    .HasName("PK__Login__0CE6C51E57F681F0");

                entity.ToTable("Login");

                entity.Property(e => e.SessionNo).HasColumnName("sessionNo");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Login__username__25869641");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId)
                    .ValueGeneratedNever()
                    .HasColumnName("movieId");

                entity.Property(e => e.Certification)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("certification");

                entity.Property(e => e.GenreId).HasColumnName("genreId");

                entity.Property(e => e.ImageSrc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("imageSrc");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.Runtime)
                    .HasColumnType("time(0)")
                    .HasColumnName("runtime");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.TrailerUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("trailerUrl");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Movies__genreId__2A4B4B5E");
            });

            modelBuilder.Entity<ScreenType>(entity =>
            {
                entity.HasKey(e => e.ScreenType1)
                    .HasName("PK__ScreenTy__D417674B3B7576F5");

                entity.ToTable("ScreenType");

                entity.Property(e => e.ScreenType1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("screenType");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.ShowId)
                    .ValueGeneratedNever()
                    .HasColumnName("showId");

                entity.Property(e => e.MovieId).HasColumnName("movieId");

                entity.Property(e => e.ShowDate)
                    .HasColumnType("date")
                    .HasColumnName("showDate");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Shows)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK__Shows__movieId__2F10007B");
            });

            modelBuilder.Entity<ShowTiming>(entity =>
            {
                entity.HasKey(e => e.ShowTimeId)
                    .HasName("PK__tmp_ms_x__1560B1EC6C6F31E9");

                entity.Property(e => e.ShowTimeId)
                    .ValueGeneratedNever()
                    .HasColumnName("showTimeId");

                entity.Property(e => e.ScreenType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("screenType");

                entity.Property(e => e.ShowId).HasColumnName("showId");

                entity.Property(e => e.ShowTime)
                    .HasColumnType("time(0)")
                    .HasColumnName("showTime");

                entity.HasOne(d => d.ScreenTypeNavigation)
                    .WithMany(p => p.ShowTimings)
                    .HasForeignKey(d => d.ScreenType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShowTimin__scree__4AB81AF0");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.ShowTimings)
                    .HasForeignKey(d => d.ShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShowTimin__showI__49C3F6B7");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("transactionId");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookingId).HasColumnName("bookingId");

                entity.Property(e => e.CardHolder)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cardHolder");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("cardNumber")
                    .IsFixedLength();

                entity.Property(e => e.CardType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cardType");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cvv")
                    .IsFixedLength();

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Transacti__booki__6FE99F9F");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Transacti__usern__3B75D760");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Users__F3DBC573F0407DEF");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phoneNo")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
