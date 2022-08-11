using Microsoft.EntityFrameworkCore;
using OriginSoftwareChallenge.Data;
using OriginSoftwareChallenge.Interfaces;
using OriginSoftwareChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginSoftwareChallenge.Repositorios
{
    public class RepositorioNroTarjeta : ApplicationDbContext
    {
        DbContextOptions _options;
        public RepositorioNroTarjeta(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public Tarjeta ExisteNroTarjetaDesbloqueada(decimal nroTarjeta)
        {
            Tarjeta tarjeta;
            using (var db = new ApplicationDbContext(_options))
            {
                tarjeta = db.Tarjetas.FirstOrDefault<Tarjeta>(t => t.Nro == nroTarjeta && t.IsBlocked == false);                                
            }
            return tarjeta;
        }

        public Tarjeta EsPINCorrecto(int PIN, decimal nroTarjeta)
        {
            Tarjeta tarjeta;
            using (var db = new ApplicationDbContext(_options))
            {
                tarjeta = db.Tarjetas.FirstOrDefault<Tarjeta>(t => t.Nro == nroTarjeta && t.PIN == PIN);                    
            }
            return tarjeta;
        }

        public Tarjeta GetTarjeta(decimal nroTarjeta)
        {
            Tarjeta tarjeta;
            using (var db = new ApplicationDbContext(_options))
            {
                tarjeta = db.Tarjetas.FirstOrDefault<Tarjeta>(t => t.Nro == nroTarjeta);
            }
            return tarjeta;
        }

        public Operacion RetirarDinero(Tarjeta tarjeta, decimal montoARetirar)
        {
            Operacion operacion;
            using (var db = new ApplicationDbContext(_options))
            {
                tarjeta.Balance = tarjeta.Balance - montoARetirar;
                db.Tarjetas.Update(tarjeta);

                operacion = new Operacion(); ;
                operacion.IdTarjeta = tarjeta.Id;
                operacion.FechaYHora = DateTime.Now;
                operacion.DineroRetirado = montoARetirar;
                operacion.DineroRestante = tarjeta.Balance;
                operacion.NroTarjeta = tarjeta.Nro;
                Random rnd = new Random();
                int codigoOperacion;
                do
                {
                    codigoOperacion = rnd.Next(9999);
                } while (db.Operaciones.FirstOrDefault<Operacion>(t => t.Codigo == codigoOperacion) != null);
                operacion.Codigo = codigoOperacion;

                db.Operaciones.Add(operacion);

                db.SaveChanges();
            }
            return operacion;
        }
    }
}
