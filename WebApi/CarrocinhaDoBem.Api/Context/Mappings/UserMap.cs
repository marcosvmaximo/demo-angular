using CarrocinhaDoBem.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarrocinhaDoBem.Api.Context.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
           builder.ToTable("AspNetUsers");

           builder.HasKey(x => x.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(u => u.NormalizedUserName)
                .HasColumnName("NormalizedUserName")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(u => u.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(u => u.NormalizedEmail)
                .HasColumnName("NormalizedEmail")
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(u => u.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .HasColumnType("tinyint(1)")
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("longtext");

            builder.Property(u => u.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("longtext");

            builder.Property(u => u.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .HasColumnType("longtext");

            builder.Property(u => u.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("longtext");

            builder.Property(u => u.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .HasColumnType("tinyint(1)")
                .IsRequired();

            builder.Property(u => u.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .HasColumnType("tinyint(1)")
                .IsRequired();

            builder.Property(u => u.LockoutEnd)
                .HasColumnName("LockoutEnd")
                .HasColumnType("datetime(6)");

            builder.Property(u => u.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .HasColumnType("tinyint(1)")
                .IsRequired();

            builder.Property(u => u.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(u => u.Avatar)
                .HasColumnName("avatar")
                .HasColumnType("blob");

            builder.Property(u => u.Address)
                .HasColumnName("adress")
                .HasColumnType("varchar(255)");

            builder.Property(u => u.BirthDate)
                .HasColumnName("birthDate")
                .HasColumnType("date");

            builder.Property(u => u.UserType)
                .HasColumnName("userType")
                .HasColumnType("varchar(20)");

            builder.HasIndex(u => u.NormalizedUserName)
                .HasDatabaseName("UserNameIndex");

            builder.HasIndex(u => u.NormalizedEmail)
                .HasDatabaseName("EmailIndex");
    }
}
