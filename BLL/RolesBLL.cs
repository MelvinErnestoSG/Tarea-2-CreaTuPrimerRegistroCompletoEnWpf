using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.DAL;
using Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.Entidades;

namespace Tarea_2_CreaTuPrimerRegistroCompletoEnWpf.BLL
{
    public class RolesBLL
    {
        public static bool Guardar(Roles roll)
        {
            if (!Existe(roll.RolesId))
                return Insertar(roll);
            else
                return Modificar(roll);
        }

        private static bool Insertar(Roles roll)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Roles.Add(roll);
                esValido = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        private static bool Modificar(Roles roll)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(roll).State = EntityState.Modified;
                esValido = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return esValido;
        }

        public static bool Eliminar(int id)
        {
            bool esValido = false;
            Contexto contexto = new Contexto();

            try
            {
                var roll = contexto.Roles.Find(id);

                if (roll != null)
                {
                    contexto.Roles.Remove(roll);//Remover la entidad
                    esValido = contexto.SaveChanges() > 0;
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
            return esValido;
        }

        public static Roles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roles rol;

            try
            {
                rol = contexto.Roles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return rol;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolesId == id);
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

        public static bool Alias(string alias)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.Alias == alias);
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

        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> lista = new List<Roles>();
            Contexto contexto = new Contexto();

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

