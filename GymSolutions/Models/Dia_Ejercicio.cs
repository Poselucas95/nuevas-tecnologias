//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymSolutions.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dia_Ejercicio
    {
        public int ID_DIA_EJERCICIO { get; set; }
        public int ID_DIA { get; set; }
        public int ID_EJERCICIO { get; set; }
        public string repeticion { get; set; }
    
        public virtual Dias_Rutina Dias_Rutina { get; set; }
        public virtual Ejercicio Ejercicio { get; set; }
    }
}