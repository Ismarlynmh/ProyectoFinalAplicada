using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalAplicada.BLL
{
    public class ComprasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Compras.Any(e => e.CompraId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Guardar(Compras compras)
        {
            if (!Existe(compras.CompraId))
            {
                return Insertar(compras);
            }
            else
            {
                return Modificar(compras);
            }
        }

        private static bool Insertar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Compras.Add(compras);

                foreach (var detalle in contexto.Compras)
                {
                    contexto.Entry(detalle).State = EntityState.Added;
                }
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalle where CompraId = {compras.CompraId}");
                foreach (var item in compras.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(compras).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int CompraId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var item = Buscar(CompraId);
                if (item != null)
                {
                    contexto.Compras.Remove(item);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        /// <summary>
        /// Permite eliminar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El id de la entidad que se desea buscar</param>
        public static Compras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compras compras;

            try
            {
                compras = contexto.Compras.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return compras;
        }

        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> lista = new List<Compras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Compras.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static List<Compras> GetAportes()
        {
            List<Compras> lista = new List<Compras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Compras.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
