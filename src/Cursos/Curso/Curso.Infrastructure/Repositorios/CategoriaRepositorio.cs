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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        public CategoriaRepositorio(CursoDbContext cursoDbContext)
        {
            _cursoDbContext = cursoDbContext;
        }

        public async Task<CategoriaModel> BuscarCategoriaPorId(int idCategoria)
        {
            return await _cursoDbContext.Categorias.FirstOrDefaultAsync(x => x.IdCategoria == idCategoria);
        }

        public async Task<CategoriaModel> BuscarCategoriaPorDescricao(string descricaoCategoria)
        {
            return await _cursoDbContext.Categorias.FirstOrDefaultAsync(x => x.Descricao == descricaoCategoria);
        }

        public async Task<List<CategoriaModel>> BuscarTodasCategorias()
        {
            return await _cursoDbContext.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> Adicionar(CategoriaRequest categoriaRequest)
        {
            CategoriaModel categoriaModel = new CategoriaModel
            {
                Descricao = categoriaRequest.Descricao
            };

            await _cursoDbContext.Categorias.AddAsync(categoriaModel);
            await _cursoDbContext.SaveChangesAsync();

            return categoriaModel;
        }
        public async Task<CategoriaModel> Atualizar(CategoriaRequest categoriaRequest, int idCategoria)
        {
            CategoriaModel categoriaPorId = await BuscarCategoriaPorId(idCategoria);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria não encontrada. Id: {idCategoria}");
            }

            categoriaPorId.Descricao = categoriaRequest.Descricao;

            _cursoDbContext.Categorias.Update(categoriaPorId);
            await _cursoDbContext.SaveChangesAsync();

            return categoriaPorId;
        }

        public async Task<bool> Apagar(int idCategoria)
        {
            CategoriaModel categoriaPorId = await BuscarCategoriaPorId(idCategoria);

            if (categoriaPorId == null)
            {
                throw new Exception($"Categoria não encontrada. Id: {idCategoria}");
            }

            _cursoDbContext.Categorias.Remove(categoriaPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }

    }
}
