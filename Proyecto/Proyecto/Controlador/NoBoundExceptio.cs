using System;

namespace Proyecto.Controlador
{
    public class NoBoundExceptio : Exception
    {
        public NoBoundExceptio(string message) : base(message)
        {
        }
    }
}