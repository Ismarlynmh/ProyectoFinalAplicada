using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada.DAL;
using ProyectoFinalAplicada.Entidades;
using System.Linq.Expressions;
using System.Security.Cryptography;


namespace ProyectoFinalAplicada.BLL
{
    public class RolesBLL
    {
        public static bool Guardar(Roles Rol)
        {
            if (!Existe(Rol.RolId))
                return Insertar(Rol);
            else
                return Modificar(Rol);
        }

        private static bool Existe(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Roles.Any(x => x.RolId == RolId);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Roles Rol)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Roles.Add(Rol);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Roles Rol)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(Rol).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        public static Roles Buscar(int RolId)
        {
            Contexto contexto = new Contexto();
            Roles Rol;
            try
            {
                Rol = contexto.Roles.Find(RolId);//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Rol;
        }

        public static bool Eliminar(int RolId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(RolId);
                if (item != null)
                {
                    contexto.Roles.Remove(item);
                    ok = contexto.SaveChanges() > 0;
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

            return ok;
        }

        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Roles> lista = new List<Roles>();

            try
            {
                lista = contexto.Roles.Where(criterio).ToList();
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
