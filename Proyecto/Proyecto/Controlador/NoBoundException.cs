using System;

namespace Proyecto.Controlador
{
    public class NoBoundException : Exception
    {
        public NoBoundException(string message) : base(message)
        {
        }
    }
}