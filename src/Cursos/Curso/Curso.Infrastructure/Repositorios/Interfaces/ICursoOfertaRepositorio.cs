using Curso.Domain.Models;
using Curso.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios.Interfaces
{
    public interface ICursoOfertaRepositorio
    {
        Task<List<CursoOfertaResponse>> BuscarTodosCursosOfertas();
        Task<CursoOfertaModel> BuscarCursoOfertaPorId(int idCursoOferta);
        Task<CursoOfertaModel> Adicionar(CursoOfertaModel cursoOferta);
        Task<CursoOfertaModel> Atualizar(CursoOfertaModel cursoOferta, int idCursoOferta);
        Task<bool> Apagar(int idCursoOferta);
    }
}
