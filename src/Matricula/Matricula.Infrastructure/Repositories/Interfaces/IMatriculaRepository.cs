﻿using Matricula.Domain.Models;

namespace Matricula.Infrastructure.Repositories.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<List<MatriculaModel>> GetAll();
        Task<MatriculaModel> GetById(int idmatricula);
        Task<MatriculaModel> Create(MatriculaModel matricula);
        Task<MatriculaModel> Update(MatriculaModel matricula, int idmatricula);
        Task<bool> DeleteById(int idmatricula);
    }
}
