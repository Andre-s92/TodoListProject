using System;
using System.ComponentModel.DataAnnotations;

namespace todoAPI.Models
{
    public class ToDo
    {
        public ToDo()
        {
            
        }
        public ToDo(int id, string descricao, string prioridade, bool completado,DateTime prazo)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Prioridade = prioridade;
            this.Completado = completado;
            this.Prazo = prazo;

        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public bool Completado { get; set; }
        public DateTime Prazo { get; set; } 
        

        
}
}