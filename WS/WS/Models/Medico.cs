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
        public string HorarioEntrada { get; set; }
        public string HorarioSaida { get; set; }

        public Medico() { // ajudando o BD a ler o Construtor
            Id = 0;
            Nome = "";
            HorarioEntrada = "";
            HorarioSaida = "";
        }
    }
}
