//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webservice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calificaciones
    {
        public int Id_Calificaciones { get; set; }
        public int FK_Alumno { get; set; }
        public int FK_Materias { get; set; }
        public Nullable<int> Calificacion1 { get; set; }
        public Nullable<int> Calificacion2 { get; set; }
        public Nullable<int> Calificacion3 { get; set; }
        public Nullable<int> CalificacionFinal { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Materias Materias { get; set; }
    }
}
