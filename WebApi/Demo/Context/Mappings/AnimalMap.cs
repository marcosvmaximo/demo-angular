using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Context.Mappings;

public class AnimalMap : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {

        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .IsRequired();
            
        builder.Property(x => x.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)");
        
        builder.Property(x => x.Porte)
            .HasColumnName("porte")
            .HasColumnType("varchar(50)");
        
        builder.Property(x => x.Descricao)
            .HasColumnName("descricao")
            .HasColumnType("varchar(1000)");
    }
}