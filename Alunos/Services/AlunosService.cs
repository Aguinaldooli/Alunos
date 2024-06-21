using Alunos.Context;
using Alunos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Alunos.Services
{
    public class AlunosService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro! Reveja a documentação.", ex);
            }
        }

        public async Task<Aluno> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                throw new Exception("Aluno não encontrado.");
            }
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByNome(string nome)
        {
            IEnumerable<Aluno> alunos;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                alunos = await _context.Alunos.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                alunos = await GetAlunos();
            }

            return alunos;
        }

        public async Task CreateAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar aluno. Reveja a documentação.", ex);
            }
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            try
            {
                _context.Entry(aluno).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar aluno. Reveja a documentação.", ex);
            }
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            try
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar aluno. Reveja a documentação.", ex);
            }
        }
    }
}
