﻿// <auto-generated />
using System;
using CapaDatos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CapaDatos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CapaModelos.AutomovilM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion_Problema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Entrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lugar_Fabricacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo_Transmision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.ToTable("automiviles");
                });

            modelBuilder.Entity("CapaModelos.ClienteM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("CapaModelos.EmpleadoM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("marca_vehiculo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("empleado");
                });

            modelBuilder.Entity("CapaModelos.EmpleadoVehiculos", b =>
                {
                    b.Property<int>("EmpleadoVehiculosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpleadoID")
                        .HasColumnType("int");

                    b.Property<int>("AutomivilID")
                        .HasColumnType("int");

                    b.Property<string>("Detalle_Reparaciion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Remitido")
                        .HasColumnType("bit");

                    b.Property<bool>("Validacion")
                        .HasColumnType("bit");

                    b.Property<int?>("automovilEmpleadofID")
                        .HasColumnType("int");

                    b.Property<int?>("empleadoVehiculofID")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoVehiculosID", "EmpleadoID", "AutomivilID");

                    b.HasIndex("automovilEmpleadofID");

                    b.HasIndex("empleadoVehiculofID");

                    b.ToTable("empleadosVehiculos");
                });

            modelBuilder.Entity("CapaModelos.Entrega", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomovilID")
                        .HasColumnType("int");

                    b.Property<string>("Detalles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("AutomovilID");

                    b.ToTable("entregas");
                });

            modelBuilder.Entity("CapaModelos.AutomovilM", b =>
                {
                    b.HasOne("CapaModelos.ClienteM", "ClienteF")
                        .WithMany("automovilC")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CapaModelos.EmpleadoVehiculos", b =>
                {
                    b.HasOne("CapaModelos.AutomovilM", "automovilEmpleadof")
                        .WithMany("GetEmpleados")
                        .HasForeignKey("automovilEmpleadofID");

                    b.HasOne("CapaModelos.EmpleadoM", "empleadoVehiculof")
                        .WithMany("GetEmpleados")
                        .HasForeignKey("empleadoVehiculofID");
                });

            modelBuilder.Entity("CapaModelos.Entrega", b =>
                {
                    b.HasOne("CapaModelos.AutomovilM", "automovilF")
                        .WithMany("entregas")
                        .HasForeignKey("AutomovilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}