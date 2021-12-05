using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProyectoFinalAplicada.Entidades;


namespace ProyectoFinalAplicada.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet <Ventas> Ventas { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet <Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet <Empleados> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data/MendozaCreation.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 1,
                Descripcion = "Admin"
            }

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                RolId = 1,
                Nombres = "Admin",
                Apellidos = "Admin",
                Cedula = "88888888888",
                Sexo = "Femenino",
                Telefono = "8888888888",
                Celular = "8888888888",
                Direccion = "SFM",
                Email = "admin123@gmail.com",
                TipoUsuario = "Administrador",
                FechaIngreso = DateTime.Now,
                NombreUsuario = "Admin",
                Contrasena = "Admin"
            }


            );

        }
    }
}
