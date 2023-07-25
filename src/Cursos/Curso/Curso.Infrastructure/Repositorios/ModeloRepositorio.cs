using Curso.Domain.Models;
using Curso.Domain.Requests;
using Curso.Infrastructure.Data;
using Curso.Infrastructure.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        public ModeloRepositorio(CursoDbContext cursoDbContext)
        {
            _cursoDbContext = cursoDbContext;
        }
        public async Task<ModeloModel> BuscarModeloPorId(int idModelo)
        {
            return await _cursoDbContext.Modelos.FirstOrDefaultAsync(x => x.IdModelo == idModelo);
        }

        public async Task<List<ModeloModel>> BuscarTodosModelos()
        {
            return await _cursoDbContext.Modelos.ToListAsync();
        }
        public async Task<ModeloModel> Adicionar(ModeloRequest modeloRequest)
        {
            ModeloModel modeloModel = new ModeloModel
            {
                Descricao = modeloRequest.Descricao
            };

            await _cursoDbContext.Modelos.AddAsync(modeloModel);
            await _cursoDbContext.SaveChangesAsync();

            return modeloModel;
        }
        public async Task<ModeloModel> Atualizar(ModeloRequest modeloRequest, int idModelo)
        {
            ModeloModel modeloPorId = await BuscarModeloPorId(idModelo);

            if (modeloPorId == null)
            {
                throw new Exception($"Modelo não encontrado. Id: {idModelo}");
            }

            modeloPorId.Descricao = modeloRequest.Descricao;

            _cursoDbContext.Modelos.Update(modeloPorId);
            await _cursoDbContext.SaveChangesAsync();

            return modeloPorId;
        }

        public async Task<bool> Apagar(int idModelo)
        {
            ModeloModel modeloPorId = await BuscarModeloPorId(idModelo);

            if (modeloPorId == null)
            {
                throw new Exception($"Curso não encontrado. Id: {idModelo}");
            }

            _cursoDbContext.Modelos.Remove(modeloPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }
        
    }
}
