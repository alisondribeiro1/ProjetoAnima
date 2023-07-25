using Curso.Domain.Models;
using Curso.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> BuscarTodasCategorias();
        Task<CategoriaModel> BuscarCategoriaPorId(int idCategoria);
        Task<CategoriaModel> Adicionar(CategoriaRequest categoriaRequest);
        Task<CategoriaModel> Atualizar(CategoriaRequest categoriaRequest, int idCategoria);
        Task<bool> Apagar(int idCategoria);
    }
}
