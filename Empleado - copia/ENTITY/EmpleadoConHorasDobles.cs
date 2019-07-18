using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
 public   class EmpleadoConHorasDobles: Empleado

    {
        public int HorasExtras { get; set; }
        
        public EmpleadoConHorasDobles(string identificacion, string nombre, double sueldoPorHora, int horasTrabajadas)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
            

        }
        public int CalcularHorasExtras()
        {
            HorasExtras = HorasTrabajadas - 40;
            return HorasExtras;
        }
        public override double CalcularSalario()
        {
            Salario = ((HorasExtras * 3000) + (40 * SueldoPorHora)); 
            return Salario;
        }
        public override string ToString()
        {
            return $"Empleado con horas Extras\n Identificacion: {Identificacion}\r\n Nombre del Empleado: {Nombre}\r\n Sueldo por Hora:{SueldoPorHora}\r\n HorasTrabajadas: {HorasTrabajadas}\r\n HorasExtras: {HorasExtras}\r\n Salario: {Salario}\n";
        }
    }
}
