using Heirloom;

namespace La_princesa_granota;

public class Granota
{
    private Image _imatge;
    public Vector Posicio { get; private set; }
    public bool EsPrincesa { get; private set; }

    public Granota(Vector posicio, bool esPrincesa)
    {
        Posicio = posicio;
        EsPrincesa = esPrincesa;
        _imatge = new Image(esPrincesa ? "Imatges\\princesa-granota.png" : "Imatges\\granota.png");
    }

    public void Pinta(GraphicsContext gfx)
    {
        gfx.DrawImage(_imatge, Posicio);
    }

    public void MostrarPrincesa(Image Princesa)
    {
        _imatge = Princesa;
    }
}

