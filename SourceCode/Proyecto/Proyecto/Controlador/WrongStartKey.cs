using System;

namespace Proyecto.Controlador
{
    public class WrongStartKey : Exception    
    {
        public WrongStartKey(string message) : base(message)
        {
        }
    }
}