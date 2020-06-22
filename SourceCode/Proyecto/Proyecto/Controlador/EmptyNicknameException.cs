using System;

namespace Proyecto.Controlador
{
    public class EmptyNicknameException : Exception
    {
        public EmptyNicknameException(string message) : base(message)
        {
        }
    }
}