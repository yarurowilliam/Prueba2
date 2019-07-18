using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public abstract class Empleado
    {

     
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public double SueldoPorHora { get; set; }
        public int HorasTrabajadas { get; set; }
        
        public  double Salario { get; set; }
        public abstract double CalcularSalario();
    }
}
