using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parcial.Models; // Asegúrate de importar el espacio de nombres correcto para Parcial

#nullable disable

namespace practica.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity<Parcial>(b =>
            {
                b.Property<int>("DNI")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("INTEGER");

                b.Property<string>("Nombre")
                    .HasColumnType("TEXT");

                b.Property<string>("Apellido")
                    .HasColumnType("TEXT");

                b.HasKey("DNI");

                b.ToTable("Parcial"); // Asegúrate de que la tabla coincida con el nombre de tu entidad
            });
#pragma warning restore 612, 618
        }
    }
}
