using CarrocinhaDoBem.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarrocinhaDoBem.Api.Context.Mappings;

public class AnimalMap : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {

        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .IsRequired();
            
    }
}