//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public int IdHorario { get; set; }
        public string turno { get; set; }
        public Nullable<int> IdAlumno { get; set; }
    
        public virtual Alumno Alumno { get; set; }
    }
}