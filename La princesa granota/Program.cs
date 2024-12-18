using System.Collections.Generic;
using Heirloom;
using Heirloom.Desktop;

namespace La_princesa_granota;

class Program
{
    private static Window finestra;
    private static Cavaller cavaller;
    private static List<Granota> granotes;
    private static Image fondo; 
    private static Image missatgePrincesa;
    

    static void Main()
    {
        byte[] imageData = File.ReadAllBytes("Imatges\\mapa.png");
        fondo = new Image(imageData);
        

        granotes = new List<Granota>
        {
            new Granota(new Vector(400, 100), true),
            new Granota(new Vector(800, 100), false),
            new Granota(new Vector(1200, 100), false),
            new Granota(new Vector(400, 400), false),
            new Granota(new Vector(800, 400), true),
            new Granota(new Vector(1200, 400), false),
            new Granota(new Vector(400, 700), false),
            new Granota(new Vector(800, 700), false),
            new Granota(new Vector(1200, 700), true),
        };

        Application.Run(() =>
        {
            finestra = new Window("La finestra", (800, 600));
            missatgePrincesa = new Image("Imatges\\princesa.png");
            finestra.MoveToCenter();
            cavaller = new Cavaller(10, 10);
            var loop = GameLoop.Create(finestra.Graphics, OnUpdate);
            loop.Start();
        });
    }

    private static void OnUpdate(GraphicsContext gfx, float dt)
    {
        var rectangleFinestra = new Rectangle(0, 0, finestra.Width, finestra.Height);

        gfx.DrawImage(fondo, rectangleFinestra);

        Granota eliminar = null;

        cavaller.Mou(rectangleFinestra);
        cavaller.Pinta(gfx);

        foreach (var granota in granotes)
        {
            granota.Pinta(gfx);
        }

        for (int i = 0; i < granotes.Count; i++)
        {
            var granota = granotes[i];
            if (CaballerEnContactoCon(granota))
            {
                if (granota.EsPrincesa)
                {
                    granota.MostrarPrincesa(missatgePrincesa);
                }
                else
                {
                    eliminar = granota;
                }
               
            }
        }

        if (eliminar != null)
        {
            granotes.Remove(eliminar);
        }
        {
            
        }
    }
    private static bool CaballerEnContactoCon(Granota granota)
    {
        var rectCaballer = new Rectangle(cavaller.Posicio.X, cavaller.Posicio.Y, 32, 32); 
        var rectGranota = new Rectangle(granota.Posicio.X, granota.Posicio.Y, 32, 32);  

        return rectCaballer.X < rectGranota.X + rectGranota.Width &&
               rectCaballer.X + rectCaballer.Width > rectGranota.X &&
               rectCaballer.Y < rectGranota.Y + rectGranota.Height &&
               rectCaballer.Y + rectCaballer.Height > rectGranota.Y;
    }
    
   
}


