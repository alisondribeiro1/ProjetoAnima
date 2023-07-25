using Curso.Domain.Models;
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
        public async Task<ModeloModel> Adicionar(ModeloModel modelo)
        {
            await _cursoDbContext.Modelos.AddAsync(modelo);
            await _cursoDbContext.SaveChangesAsync();

            return modelo;
        }
        public async Task<ModeloModel> Atualizar(ModeloModel modelo, int idModelo)
        {
            ModeloModel modeloPorId = await BuscarModeloPorId(idModelo);

            if (modeloPorId == null)
            {
                throw new Exception($"Modelo não encontrado. Id: {idModelo}");
            }

            modeloPorId.IdModelo = modelo.IdModelo;
            modeloPorId.Descricao = modelo.Descricao;

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
