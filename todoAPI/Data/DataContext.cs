using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using todoAPI.Models;

namespace todoAPI.Data
{
    public class DataContext : DbContext
    {
     public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<ToDo> ToDos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            
            builder.Entity<ToDo>()
                .HasData(new List<ToDo>(){
                    new ToDo(1, "Analisar Requisitos", "Alta", false,DateTime.Now),
                    new ToDo(2, "Criar o Model", "Alta", false,DateTime.Now),
                    new ToDo(3, "Criar e implementar o Controller", "Alta", false,DateTime.Now),
                    new ToDo(4, "Criar a Interface Front End em Angular", "Alta", false,DateTime.Now),
                    new ToDo(5, "Terminar e Testar a Aplicação", "Alta", false,DateTime.Now)
                });

            
        
        }   
    }
}