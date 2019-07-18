    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class EmpleadoConHorasTriples : Empleado

    {
        public int HorasExtras { get; set; }
        public int HorasTriples { get; set; }

        public EmpleadoConHorasTriples(string identificacion, string nombre, double sueldoPorHora, int horasTrabajadas)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
            

        }
        public int CalcularHorasTriples()
        {
            HorasExtras =  40;
            HorasTriples = HorasTrabajadas - 80;
            return HorasTriples;
        }
        public override double CalcularSalario()
        {
            Salario = ((40 * SueldoPorHora) + (HorasExtras * 3000) + (HorasTriples * 5000)  );
            return Salario;
        }
        public override string ToString()
        {
            return $"Empleado Con horas triples\n Identificacion: {Identificacion}\r\n Nombre del Empleado: {Nombre}\r\n Sueldo por Hora:{SueldoPorHora}\r\n HorasTrabajadas: {HorasTrabajadas}\r\n HorasExtras: {HorasExtras}\r\n HorasTriples: {HorasTriples}\r\n Salario: {Salario}\n";
        }
    }
}

