using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace SistemaAgenda.Datos
{
    // Modelo que representa el horario laboral de una estilista para un día
    public class HorarioEstilista
    {
        public int Id { get; set; }
        public int IdEstilista { get; set; }
        public byte DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        public HorarioEstilista() { }
        public HorarioEstilista(int Id, int IdEstilista, byte DiaSemana, TimeSpan HoraInicio, TimeSpan HoraFin)
        {
            this.Id = Id;
            this.IdEstilista = IdEstilista;
            this.DiaSemana = DiaSemana;
            this.HoraInicio = HoraInicio;
            this.HoraFin = HoraFin;
        }
    }
}
