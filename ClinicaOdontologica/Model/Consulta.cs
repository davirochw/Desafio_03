using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Model
{
    public class Consulta
    {
        public int Id { get; set; }
        public string DataConsulta { get; private set; }
        public string HoraInicial { get; private set; }
        public string HoraFinal { get; private set; }
        public string Cpf { get; private set; }

        public Consulta(string cpf, string dataConsulta, string horaInicial, string horaFinal)
        {
            Cpf = cpf;
            DataConsulta = dataConsulta;
            HoraInicial = horaInicial;
            HoraFinal = horaFinal;
        }
    }
}
