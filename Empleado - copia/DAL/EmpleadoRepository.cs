using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DAL
{
    public class EmpleadoRepository
    {
        List<Empleado> empleadoLista = new List<Empleado>();
        //GUARDAR
        public void Guardar(Empleado empleado)
        {
            empleadoLista.Add(empleado);
        }
        //CONSULTAR
        public List<Empleado> Consultar()
        {
            return empleadoLista;
        }

        //BUSCAR ID
        public Empleado Buscar(string identificacion)
        {
            foreach (var item in empleadoLista)
            {
                if (item.Identificacion.Equals(identificacion))
                {

                    return item;
                }

            }

            return null;
        }

        public Empleado Buscar(Empleado empleado)
        {
            foreach (var item in empleadoLista)
            {
                if (item.Equals(empleado))
                {
                    return item;
                }
            }
            return null;
        }
        //ELIMINAR
        public void Eliminar(Empleado empleado)
        {
            empleadoLista.Remove(empleado);
        }
        // MODIFICAR
        public void Modificar(Empleado empleadoNuevo, Empleado empleadoViejo)
        {
            empleadoLista.Remove(empleadoViejo);
            empleadoLista.Add(empleadoNuevo);

        }

    }
}


