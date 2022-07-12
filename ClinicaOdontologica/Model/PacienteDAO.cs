using ClinicaOdontologica.Controller.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Model
{
    public class PacienteDAO
    {
        private readonly MainContexto contexto;

        public PacienteDAO()
        {
            this.contexto = new MainContexto();
        }

        public void Add(Paciente paciente)
        {
            contexto.Pacientes.Add(paciente);
            contexto.SaveChanges();
        }

        public void Remove(string cpf)
        {
            var pacienteVerificar = ConsultarPorCpf(cpf);

            if (pacienteVerificar != null)
            {
                contexto.Pacientes.Remove(pacienteVerificar);
                contexto.SaveChanges();
            }
        }

        public bool Contains(Paciente paciente)
        {
            return contexto.Pacientes.Contains(paciente);
        }

        public Paciente? ConsultarPorCpf(string cpf)
        {
            var query = from p in contexto.Pacientes
                        where p.Cpf.Contains(cpf)
                        select p;
            foreach (var paciente in query)
            {
                return paciente;
            }

            return null;
        }

        public List<Paciente> CpfsOrdenados()
        {
            return contexto.Pacientes.OrderBy(p => p.Cpf).ToList();
        }

        public List<Paciente> NomesOrdenados()
        {
            return contexto.Pacientes.OrderBy(p => p.Nome).ToList();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
