using System;

namespace Proyecto.Controlador
{
    public class NoMoreLifesException : Exception
    {
        public NoMoreLifesException(string message) : base(message)
        {
        }
    }
}