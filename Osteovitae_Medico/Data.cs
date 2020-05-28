using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osteovitae_Medico
{
    class Data
    {
        private String _Nome;
        private String _Apelido;
        private String _Contacto;
        private String _Email;
        private String _Pass;
        private String _Tipo;

        public Data() : base() { }

        public String Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public String Apelido
        {
            get { return _Apelido; }
            set { _Apelido = value; }
        }

        public String Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }

        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public String Pass
        {
            get { return _Pass; }
            set { _Pass = value; }
        }
        public String Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
    }
}
