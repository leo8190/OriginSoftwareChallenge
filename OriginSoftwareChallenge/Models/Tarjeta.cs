using System;

namespace OriginSoftwareChallenge.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public decimal Nro { get; set; }
        public int PIN { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Balance { get; set; }
    }
}
