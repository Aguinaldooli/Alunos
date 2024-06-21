using Alunos.Models;
using Microsoft.EntityFrameworkCore;


//Classe que faz o contexto do modelo com o banco de dados
namespace Alunos.Context
{
    //portanto ela tem que herdar da classe dbcontext do framework
    public class AppDbContext : DbContext
    {
        //Definindo um construtor

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        //indicando qual modelo vai ser mapeado para qual tabela
        public DbSet<Aluno> Alunos { get; set; }
    }
}
