using Curso.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios.Interfaces
{
    public interface IModeloRepositorio
    {
        Task<List<ModeloModel>> BuscarTodosModelos();
        Task<ModeloModel> BuscarModeloPorId(int idModelo);
        Task<ModeloModel> Adicionar(ModeloModel modelo);
        Task<ModeloModel> Atualizar(ModeloModel modelo, int idModelo);
        Task<bool> Apagar(int idModelo);
    }
}
