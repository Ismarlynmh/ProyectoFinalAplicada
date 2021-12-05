using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada.BLL
{
    public  class EmpleadosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Empleados.Any(e => e.EmpleadoId == id);
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

        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="empleados">La entidad que se desea guardar</param>
        /// 

        public static bool Guardar(Empleados empleados)
        {
            if (!Existe(empleados.EmpleadoId))
            {
                return Insertar(empleados);
            }
            else
            {
                return Modificar(empleados);
            }
        }

        /// <summary>
        /// Permite insertar o modificar una entidad en la base de datos
        /// </summary>
        /// <param name="empleados">La entidad que se desea guardar</param>
        /// 

        public static bool Insertar(Empleados empleados)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Empleados.Add(empleados);
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

        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="empleados">La entidad que se desea modificar</param>
        /// 

        public static bool Modificar(Empleados empleados)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(empleados).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        /// <summary>
        /// Permite eliminar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El id de la entidad que se desea buscar</param>
        /// 

        public static Empleados Busacar(int id)
        {
            Contexto contexto = new Contexto();
            Empleados empleados;

            try
            {
                empleados = contexto.Empleados.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return empleados;
        }

        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        /// 

        public static List<Empleados> GetList(Expression<Func<Empleados, bool>> cristerio)
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Empleados.Where(cristerio).ToList();
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

        public static List<Empleados> GetEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Empleados.ToList();
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
