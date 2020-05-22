using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osteovitae_Paciente
{
    class Consultas
    {
        private String _Medico;
        private String _TipoConsulta;
        private String _Data;
        private String _Hora;

        public Consultas() : base() { }

        public String Medico
        {
            get { return _Medico; }
            set { _Medico = value; }
        }
        public String TipoConsulta
        {
            get { return _TipoConsulta; }
            set { _TipoConsulta = value; }
        }
        public String Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        public String Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

    }
}
