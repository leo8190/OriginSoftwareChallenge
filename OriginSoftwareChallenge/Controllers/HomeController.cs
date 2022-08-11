using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private RepositorioTarjeta _repositorioTarjeta;
        public HomeController(RepositorioTarjeta repositorioTarjeta)
        {
            _repositorioTarjeta = repositorioTarjeta;
        }
        
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("nroDeIntentos", 4);
            return View();
        }
        
        [HttpPost]
        public IActionResult ValidarNroTarjeta(string nroTarjeta)
        {
            nroTarjeta = nroTarjeta.Replace("-", "");
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _repositorioTarjeta.EncontrarTarjetaDesbloqueada(nroTarjetaDecimal);

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

            var tarjeta = _repositorioTarjeta.EsPINCorrecto(PINInt, nroTarjetaDecimal);

            if (tarjeta != null)
                return View("Operaciones", tarjeta);
            else
            {
                HttpContext.Session.SetInt32("nroDeIntentos", (int)(HttpContext.Session.GetInt32("nroDeIntentos") - 1));
                
                ErrorViewModel error = new ErrorViewModel();
                error.Message = "Le quedan " + HttpContext.Session.GetInt32("nroDeIntentos") + " intentos.";
                if(HttpContext.Session.GetInt32("nroDeIntentos") <= 0)
                {
                    _repositorioTarjeta.BloquearTarjeta(nroTarjetaDecimal);
                    return View("ErrorTarjetaBloqueada");
                }
                return View("ErrorPINIncorrecto", error);
            }
        }

        public IActionResult Balance(string nroTarjeta)
        {
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _repositorioTarjeta.GetTarjeta(nroTarjetaDecimal);

            return View("Balance", tarjeta);
        }

        public IActionResult Retiro(string nroTarjeta)
        {
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _repositorioTarjeta.GetTarjeta(nroTarjetaDecimal);
            return View("Retiro", tarjeta);
        }

        public IActionResult RetirarDinero(string nroTarjeta, decimal montoARetirar)
        {
            decimal nroTarjetaDecimal = Convert.ToDecimal(nroTarjeta);
            var tarjeta = _repositorioTarjeta.GetTarjeta(nroTarjetaDecimal);

            if (tarjeta.Balance >= montoARetirar)
            {
                var operacion = _repositorioTarjeta.RetirarDinero(tarjeta, montoARetirar);
                return View("ResultadoOperacion", operacion);
            }
            else
                return View("ErrorNoHaySuficienteSaldo");
        }
    }
}
