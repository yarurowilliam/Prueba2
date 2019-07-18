using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class EmpleadoSinHorasExtras : Empleado
    {

        public double TotalPago { get; set; }


        public EmpleadoSinHorasExtras(string identificacion, string nombre, double sueldoPorHora, int horasTrabajadas)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }
           public override double CalcularSalario()
        {
            Salario = (HorasTrabajadas * SueldoPorHora);
            return Salario ;
        }
        public override string ToString()
        {
            return $"Empleado sin horas Extras\n Identificacion: {Identificacion}\r\n Nombre del Empleado: {Nombre}\r\n Sueldo por Hora:{SueldoPorHora}\r\n HorasTrabajadas: {HorasTrabajadas} \r\n Salario {Salario}\n";
        }
    }
}
