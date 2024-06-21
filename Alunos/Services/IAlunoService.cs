using Alunos.Models;
//Na interface não tem implementação 
//Basicamente deixa descrito os métodos que vão existir na api
namespace Alunos.Services
{
    public interface IAlunoService
    {
        //A classe Task signifca uma operação assincrona
        //as informações que estiverem dentro de <> são o tipo de info
        //que deve ser retornado no método
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<IEnumerable<Aluno>> GetAlunosByNome(string nome);
        Task CreateAluno(Aluno aluno);
        Task UpdateAluno(Aluno aluno);
        Task DeleteAluno(Aluno aluno);

    }
}
