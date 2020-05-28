using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osteovitae_Medico
{
    public class Numero
    {
        public String _numero { get; set; }
        public Numero() : base() { }
        public String numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
    }
}
