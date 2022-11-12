using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Urna.Classes
{
    public class Eleitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Zona { get; set; }
        public string Secao { get; set; }
    }
}