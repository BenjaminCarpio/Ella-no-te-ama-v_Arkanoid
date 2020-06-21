namespace Proyecto
{
    public static class DatosJuego
    {
        public static bool juegoIniciado = false;
        public static double ticksRealizados = 0;
        public static int dirX = 10, dirY = -dirX,vidas = 3, puntajes=0;
        public static void InicializarJuego()
        {
            juegoIniciado = false;
            ticksRealizados = 0;
            vidas = 3;
            puntajes = 0;
        }
    }
}