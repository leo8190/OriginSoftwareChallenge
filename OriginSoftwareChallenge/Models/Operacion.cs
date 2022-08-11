using System;

namespace OriginSoftwareChallenge.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public int IdTarjeta { get; set; } 
        public DateTime FechaYHora { get; set; }
        public int Codigo { get; set; }
        public decimal DineroRetirado { get; set; }
        public decimal DineroRestante { get; set; }
        public decimal NroTarjeta { get; set; }
    }
}
