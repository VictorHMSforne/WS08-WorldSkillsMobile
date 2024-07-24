using SQLite; // Adicionado a biblioteca do SQLite
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Models
{
    public class Medico // Criando as propriedades do Construtor
    {
        [PrimaryKey,AutoIncrement,NotNull]
        public int Id { get; set; }
        public string Nome { get; set; }
        public TimeSpan HorarioEntrada { get; set; }
        public TimeSpan HorarioSaida { get; set; }

        public Medico() { // ajudando o BD a ler o Construtor
            this.Id = 0;
            this.Nome = "";
            this.HorarioEntrada = TimeSpan.Zero;
            this.HorarioSaida = TimeSpan.Zero;
        }
    }
}
