using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENTITY;

namespace BLL
{
    public class EmpleadoService
    {
        List<Empleado> Empleados = new List<Empleado>();
        EmpleadoRepository EmpleadoRepositorio = new EmpleadoRepository();

        public string Guardar(Empleado empleado)
        {
            if (EmpleadoRepositorio.Buscar(empleado.Identificacion) == null)
            {
                EmpleadoRepositorio.Guardar(empleado);
                return $"Los datos de {empleado.Nombre} con identificacion {empleado.Identificacion} Se han guardado satisfactoriamente";
            }
            else
            {

                return $"{empleado.Nombre} con identificacion {empleado.Identificacion} se ha guardado";
            }
        }

        public string Eliminar(Empleado empleado)
        {
            if (EmpleadoRepositorio.Buscar(empleado.Identificacion) == null)
            {
                return $"La Persona con identificacion {empleado.Identificacion} No se encuentra registrada";
            }
            else
            {
                EmpleadoRepositorio.Eliminar(empleado);
                return $"¡{empleado.Nombre} con identificacion {empleado.Identificacion} fue eliminada satisfactoriamente!";
            }
        }
        public Respuesta Buscar(string identificacion)
        {
            Respuesta respuesta = new Respuesta();
            if (EmpleadoRepositorio.Buscar(identificacion) == null)
            {
               respuesta.Mensaje="El empleado no existe";
                respuesta.Empleado = null;
  
                return respuesta;
            }
            else
            {
                respuesta.Mensaje = ("El empleado Si existe");
                respuesta.Empleado = EmpleadoRepositorio.Buscar(identificacion);
                return respuesta ;
            }
        }

        public List<Empleado> Consultar()
        {
            return EmpleadoRepositorio.Consultar();
        }



        public string Modificar(Empleado empleadoNuevo, Empleado empleadoViejo)
        {
            if (EmpleadoRepositorio.Buscar(empleadoNuevo.Identificacion) == null)
            {
                EmpleadoRepositorio.Modificar(empleadoNuevo, empleadoViejo);
                return $"La Persona con identificacion {empleadoNuevo.Identificacion} fue modificada";


            }
            else
            {

            return $"¡La Persona con identificacion {empleadoNuevo.Identificacion} fue Encontrada!\n PORFAVOR INGRESE SUS NUEVOS DATOS";
            }
        }
        public Empleado CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            if (empleadoDTO.HorasTrabajadas > 0 && empleadoDTO.HorasTrabajadas < 41)
            {

                EmpleadoSinHorasExtras empleado = new EmpleadoSinHorasExtras(empleadoDTO.Identificacion, empleadoDTO.Nombre, empleadoDTO.SueldoPorHora, empleadoDTO.HorasTrabajadas);
                empleado.CalcularSalario();
                //EmpleadoRepositorio.Guardar(empleado);
                return empleado;
            }
            else
            {
                if (empleadoDTO.HorasTrabajadas > 40 && empleadoDTO.HorasTrabajadas < 81)
                {



                    EmpleadoConHorasDobles empleado = new EmpleadoConHorasDobles(empleadoDTO.Identificacion, empleadoDTO.Nombre, empleadoDTO.SueldoPorHora, empleadoDTO.HorasTrabajadas);
                    empleado.CalcularHorasExtras();
                    empleado.CalcularSalario();
                  //  EmpleadoRepositorio.Guardar(empleado);
                    return empleado;
                }
                else
                {
                    if (empleadoDTO.HorasTrabajadas > 80)
                    {
                        EmpleadoConHorasTriples empleado = new EmpleadoConHorasTriples(empleadoDTO.Identificacion, empleadoDTO.Nombre, empleadoDTO.SueldoPorHora, empleadoDTO.HorasTrabajadas);
                        empleado.CalcularHorasTriples();
                        empleado.CalcularSalario();
                    //    EmpleadoRepositorio.Guardar(empleado);
                        return empleado;
                    }
                }
            }
            return null;
        }
        public class EmpleadoDTO
        {
            public string Identificacion { get; set; }
            public string Nombre { get; set; }
            public double SueldoPorHora { get; set; }
            public int HorasTrabajadas { get; set; }
            public int HorasExtras { get; set; }
            public int HorasTriples { get; set; }

        }

    }

    public class Respuesta {
        public string  Mensaje { get; set; }
        public Empleado Empleado { get; set; }
       
    }
}
