using OriginSoftwareChallenge.Models;

namespace OriginSoftwareChallenge.Interfaces
{
    public interface INroTarjetaRepositorio
    {
        Tarjeta ExisteNroTarjeta(string nroTarjeta);
    }
}
