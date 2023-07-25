using Curso.Domain.Models;
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
        Task<CategoriaModel> Adicionar(CategoriaModel categoria);
        Task<CategoriaModel> Atualizar(CategoriaModel categoria, int idCategoria);
        Task<bool> Apagar(int idCategoria);
    }
}
