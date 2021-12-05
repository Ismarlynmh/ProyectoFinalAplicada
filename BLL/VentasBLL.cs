using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ProyectoFinalAplicada.Entidades;
using ProyectoFinalAplicada.DAL;

namespace ProyectoFinalAplicada.BLL
{
    public class VentasBLL
    {
        public static bool Guardar(Ventas venta)
        {
            if (!Existe(venta.VentaId))
                return Insertar(venta);
            else
                return Modificar(venta);
        }

        private static bool Existe(int VentaId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Ventas.Any(x => x.VentaId == VentaId);
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

        private static bool Insertar(Ventas venta)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                foreach (var item in venta.Detalle)
                {
                    contexto.Entry(item.ProductoId).State = EntityState.Modified;
                }
                contexto.Ventas.Add(venta);
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
        public static bool Modificar(Ventas venta)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM VentasDetalles where VentaId = {venta.VentaId}");
                foreach (var item in venta.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(venta).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int VentaId)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var item = Buscar(VentaId);
                if (item != null)
                {
                    contexto.Ventas.Remove(item);
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

        public static Ventas Buscar(int VentaId)
        {
            Contexto contexto = new Contexto();
            Ventas venta;
            try
            {
                venta = contexto.Ventas
                    .Where(x => x.VentaId == VentaId)
                    .Include(d => d.Detalle)
                    .ThenInclude(d => d.ProductoId)
                    .SingleOrDefault();//Busca el registro en la base de datos.
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return venta;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> venta)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Ventas.Where(venta).Include(X => X.Detalle).ThenInclude(d => d.ProductoId).ToList();
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
