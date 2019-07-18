using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace RegistroEmpleado
{
    class Program
    {
        static void Main(string[] args)

        {
            int opcion,horasTrabajadas;
            string identificacion,nombre;
            double sueldoPorHora;
            ConsoleKeyInfo op;

             List<Empleado> EmpleadoLista = new List<Empleado>();
            EmpleadoService Empleadoservicio = new EmpleadoService();
            EmpleadoService.EmpleadoDTO empleadoDTO = new EmpleadoService.EmpleadoDTO();  
            

        

            do
            {
                Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
                Console.WriteLine("°** MENU DE OPCIONES **      °");
                Console.WriteLine("°1. Guardar                  °");
                Console.WriteLine("°2. Buscar por identificacion°");
                Console.WriteLine("°3. Consultar                °");
                Console.WriteLine("°4. Eliminar                 °");
                Console.WriteLine("°5. Modificar                °");
                Console.WriteLine("°6. Salir                    °");
                Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");

                opcion = Convert.ToInt16(Console.ReadLine());
                switch (opcion)
                {
                       
                            case 1:
                        try { 
                        do
                        {
                            
                            Console.Clear();
                            Console.WriteLine("Digite identificacion del Empleado");
                            empleadoDTO.Identificacion = Console.ReadLine();
                            Console.WriteLine("Digite el Nombre del empleado: ");
                            empleadoDTO.Nombre = Console.ReadLine();
                            Console.WriteLine("Digite El Sueldo por Hora del Empleado");
                            empleadoDTO.SueldoPorHora = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Digite las Horas trabajadas del Empleado");
                            empleadoDTO.HorasTrabajadas = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine(Empleadoservicio.Guardar(Empleadoservicio.CrearEmpleado(empleadoDTO))); 
                            Console.WriteLine("Desea Continuar S/N");
                           
                            op = Console.ReadKey(); Console.Clear();
                            

                            } while (op.Key == ConsoleKey.S);
                        } catch (Exception)
                        {
                            Console.WriteLine();
                        }
                        
                        break;



                    case 2: // BUSCRA ID
                        Console.Clear();
                        try
                        {
                            Respuesta respuesta;
                            Console.WriteLine("Ingrese el codigo que desea buscar");
                            identificacion = Console.ReadLine();
                            respuesta = Empleadoservicio.Buscar(identificacion);
                             Console.WriteLine(respuesta.Mensaje);
                            Console.WriteLine(respuesta.Empleado.ToString());

                            Console.WriteLine();
                        }
                        catch (Exception )
                        {
                            Console.WriteLine();
                        }
                        break;

                    case 3: // CONSULTAR
                        Console.Clear();
                        foreach (var item in Empleadoservicio.Consultar())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;

                    case 4: //ELIMINAR
                        Console.Clear();
                        try
                        {
                            Respuesta respuesta = new Respuesta();
                            Console.WriteLine("Digite identificacion del empleado a eliminar: ");
                            identificacion = Console.ReadLine();
                            respuesta=Empleadoservicio.Buscar(identificacion);
                            Console.WriteLine(Empleadoservicio.Eliminar(respuesta.Empleado));
                        }
                        catch (Exception ) { }
                        break;

                    case 5:

                        try
                        {


                            Respuesta respuesta = new Respuesta();
                            Console.Clear();
                            Console.WriteLine("Digite identificacion del empleado a modificar: ");
                            identificacion = Console.ReadLine();
                            respuesta=Empleadoservicio.Buscar(identificacion);
                           
                            if (respuesta.Empleado==null)
                            {
                                Console.WriteLine(respuesta.Mensaje);

                            }
                            else
                            {

                                Console.Write("Digite nueva identificacion: ");
                                identificacion = Console.ReadLine();

                                empleadoDTO.Identificacion = identificacion;


                                Console.Write("Digite nuevo nombre: ");
                                nombre = Console.ReadLine();
                                empleadoDTO.Nombre = nombre;

                                Console.Write("Digite sueldo por hora: ");
                                sueldoPorHora = Convert.ToDouble(Console.ReadLine());
                                empleadoDTO.SueldoPorHora = sueldoPorHora;

                                Console.Write("Digite horas trabajadas: ");
                                horasTrabajadas = Convert.ToInt16(Console.ReadLine());
                                empleadoDTO.HorasTrabajadas = horasTrabajadas;

                                Empleado empleadoNuevo = Empleadoservicio.CrearEmpleado(empleadoDTO);
                                Empleado empleadoViejo = respuesta.Empleado;
                                Empleadoservicio.Modificar(empleadoNuevo, empleadoViejo);

                            }
                           
                            

                            

                       //     Empleadoservicio.CrearEmpleado(empleadoDTO);

                        }
                        catch (Exception) { }
                        break;

                    case 6:
                        Console.WriteLine("Pulse enter para salir");
                        break;

                }

            } while (opcion < 6);

            Console.ReadKey();
        }


    }
}