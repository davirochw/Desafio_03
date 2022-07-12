using ClinicaOdontologica.Controller.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Model
{
    public class ConsultaDAO : IDisposable
    {
        private MainContexto contexto;

        public ConsultaDAO()
        {
            this.contexto = new MainContexto();
        }

        public void Add(Consulta consulta)
        {
            contexto.Consultas.Add(consulta);
            contexto.SaveChanges();
        }

        public bool Remove(string cpf, string dataConsulta, string horaInicial)
        {
            var consultaFutura = ConsultaFutura(cpf, dataConsulta, horaInicial);

            if (consultaFutura != null)
            {
                contexto.Consultas.Remove(consultaFutura);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Contains(Consulta consulta)
        {
            return contexto.Consultas.Contains(consulta);
        }

        public Consulta? ConsultaFutura(string cpf, string dataConsulta, string horaInicial)
        {
            var consultaFiltradaPorCpf = ConsultarPorCpf(cpf);

            var diaAtual = DateTime.Now.Date;
            var dataDaConsulta = Convert.ToDateTime(consultaFiltradaPorCpf.DataConsulta);
            var horaAtual = DateTime.Now.ToLocalTime();
            var horaDaConsulta = Convert.ToDateTime(consultaFiltradaPorCpf.HoraInicial);

            var verificaDataFutura = dataDaConsulta < diaAtual || dataDaConsulta == diaAtual && horaDaConsulta < horaAtual;

            if (consultaFiltradaPorCpf != null && verificaDataFutura)
            {
                return consultaFiltradaPorCpf;
            }
            return null;
        }

        public Consulta? ConsultaFutura(string cpf)
        {
            var consultaFiltradaPorCpf = ConsultarPorCpf(cpf);

            var diaAtual = DateTime.Now.Date;
            var dataDaConsulta = Convert.ToDateTime(consultaFiltradaPorCpf.DataConsulta);
            var horaAtual = DateTime.Now.TimeOfDay;
            var horaDaConsulta = TimeSpan.Parse((consultaFiltradaPorCpf.HoraInicial).Replace(":", "").Insert(2, ":"));

            var verificaDataFutura = dataDaConsulta < diaAtual || dataDaConsulta == diaAtual && horaDaConsulta < horaAtual;

            if (consultaFiltradaPorCpf != null && verificaDataFutura)
            {
                return consultaFiltradaPorCpf;
            }
            return null;
        }

        public Consulta? ConsultarPorCpf(string cpf)
        {
            var query = from c in contexto.Consultas
                        where c.Cpf.Contains(cpf)
                        select c;
            foreach (var consulta in query)
            {
                return consulta;
            }

            return null;
        }

        public IList<Consulta> Consultas()
        {
            return contexto.Consultas.ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
