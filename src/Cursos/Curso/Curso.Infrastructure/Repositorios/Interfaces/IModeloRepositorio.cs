using Curso.Domain.Models;
using Curso.Domain.Requests;
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
        Task<ModeloModel> Adicionar(ModeloRequest modeloRequest);
        Task<ModeloModel> Atualizar(ModeloRequest modeloRequest, int idModelo);
        Task<bool> Apagar(int idModelo);
    }
}
