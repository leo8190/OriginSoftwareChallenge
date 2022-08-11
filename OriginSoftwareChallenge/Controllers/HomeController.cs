using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OriginSoftwareChallenge.Interfaces;
using OriginSoftwareChallenge.Models;
using OriginSoftwareChallenge.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OriginSoftwareChallenge.Controllers
{
    public class HomeController : Controller
    {
        private RepositorioNroTarjeta _nroTarjetaRepositorio;
        public HomeController(RepositorioNroTarjeta nroTarjetaRepositorio)
        {
            _nroTarjetaRepositorio = nroTarjetaRepositorio;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ValidarNroTarjeta(string nroTarjeta)
        {
            nroTarjeta = nroTarjeta.Replace("-", "");
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _nroTarjetaRepositorio.ExisteNroTarjetaDesbloqueada(nroTarjetaDecimal);

            if (tarjeta != null)
                return View("IngresarPIN", tarjeta);
            else
                return View("ErrorTarjetaInexistenteOBloqueada");
        }

        [HttpPost]
        public IActionResult IngresarPIN(string PIN, string nroTarjeta)
        {
            var PINInt = Convert.ToInt32(PIN);
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);

            var tarjeta = _nroTarjetaRepositorio.EsPINCorrecto(PINInt, nroTarjetaDecimal);

            if (tarjeta != null)
                return View("Operaciones", tarjeta);
            else
                return View("ErrorPINIncorrecto");
        }

        public IActionResult Balance(string nroTarjeta)
        {
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _nroTarjetaRepositorio.GetTarjeta(nroTarjetaDecimal);

            return View("Balance", tarjeta);
        }

        public IActionResult Retiro(string nroTarjeta)
        {
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _nroTarjetaRepositorio.GetTarjeta(nroTarjetaDecimal);
            return View("Retiro", tarjeta);
        }

        public IActionResult RetirarDinero(string nroTarjeta, decimal montoARetirar)
        {
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _nroTarjetaRepositorio.GetTarjeta(nroTarjetaDecimal);

            if (tarjeta.Balance >= montoARetirar)
            {
                var operacion = _nroTarjetaRepositorio.RetirarDinero(tarjeta, montoARetirar);
                return View("ResultadoOperacion", operacion);
            }
            else
                return View("ErrorNoHaySuficienteSaldo");
        }
    }
}
