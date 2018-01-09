using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioWeb
{
    public class ElementoHash
    {
        public string nickname;
        public int eliminado;

        public ElementoHash(string nickname)
        {
            this.nickname = nickname;
            this.eliminado = 0;
        }
    }
}