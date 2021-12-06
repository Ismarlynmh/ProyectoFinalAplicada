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
                Descripcion = "Empleado"
            }

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                RolId = 1,
                Nombres = "Julio César",
                Apellidos = "Jimeno Disla",
                Cedula = "40223489199",
                Sexo = "Masculino",
                Telefono = "8095884287",
                Celular = "8294562890",
                Direccion = "SFM",
                Email = "Jimeno207@gmail.com",
                TipoUsuario = "Empleado",
                FechaIngreso = DateTime.Now,
                NombreDeUsuario = "julio",
                Contraseña = "Ucne2021@"
            }
            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 2,
                Descripcion = "Administrador"
            }

            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 2,
                RolId = 2,
                Nombres = "Ismarlin Altagracia",
                Apellidos = "Mendoza Hernández",
                Cedula = "40212498188",
                Sexo = "Femenino",
                Telefono = "8095885751",
                Celular = "8498852233",
                Direccion = "SFM",
                Email = "ismarlyn123@gmail.com",
                TipoUsuario = "Administrador",
                FechaIngreso = DateTime.Now,
                NombreDeUsuario = "ismarlyn",
                Contraseña = "UCNE2021@"
            }



            );

        }
    }
}
