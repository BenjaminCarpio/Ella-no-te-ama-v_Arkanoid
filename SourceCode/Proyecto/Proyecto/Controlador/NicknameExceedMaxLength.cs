using System;

namespace Proyecto.Controlador
{
    public class NicknameExceedMaxLength : Exception
    {
        public NicknameExceedMaxLength(string message) : base(message)
        {
        }
    }
}