using Curso.Domain.Models;
using Curso.Domain.Requests;
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
        Task<CursoOfertaResponse> BuscarCursoOfertaPorId(int idCursoOferta);
        Task<CursoOfertaResponse> Adicionar(string cursoRequest,
                                            string categoriaRequest,
                                            string modeloRequest,
                                            string turnoRequest);
        Task<CursoOfertaResponse> Atualizar(string cursoRequest,
                                            string categoriaRequest,
                                            string modeloRequest,
                                            string turnoRequest,
                                            int idCursoOferta);
        Task<bool> Apagar(int idCursoOferta);
    }
}
