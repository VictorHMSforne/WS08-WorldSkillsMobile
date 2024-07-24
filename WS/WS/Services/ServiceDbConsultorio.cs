using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WS.Models;

namespace WS.Services
{
    public class ServiceDbConsultorio
    {
        SQLiteConnection conn;

        public ServiceDbConsultorio(string dbPath) // um metodo para abrir com o parâmetro do caminho do banco
        {
            if (dbPath == "")
                dbPath = App.DbPath; // se o caminho do banco estiver vazio ele irá receber da Classe App a var Dbpath;

            conn = new SQLiteConnection(dbPath); // recebe uma nova conexão com o banco
            conn.CreateTable<Medico>(); // cria uma Tabela baseando-se no Médico
        }

        public void Inserir(Medico medico) // Método de Inserção no banco
        {
            try
            {
                conn.Insert(medico);
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }

        public List<Medico> Listar() //Método de Listagem dos Médicos
        {
            List<Medico> li = new List<Medico>();
            try
            {
                li = conn.Table<Medico>().ToList();  
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            return li;
        }

        public void Atualizar(Medico medico) // Método de Atualizar os Dados
        {
            try
            {
                if (medico.Id == 0)
                {
                    throw new Exception("O Id do médico não pode ser zero.");
                }
               int result = conn.Update(medico);
                if (result == 0)
                {
                    throw new Exception("Nenhum registro foi atualizado!");
                }
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
        }
    }
}
