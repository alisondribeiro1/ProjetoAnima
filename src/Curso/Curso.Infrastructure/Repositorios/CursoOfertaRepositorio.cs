using Curso.Domain.Models;
using Curso.Domain.Requests;
using Curso.Domain.Responses;
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
    public class CursoOfertaRepositorio : ICursoOfertaRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IModeloRepositorio _modeloRepositorio;
        private readonly ITurnoRepositorio _turnoRepositorio;

        public CursoOfertaRepositorio(CursoDbContext cursoDbContext,
                                    ICursoRepositorio cursoRepositorio,
                                    ICategoriaRepositorio categoriaRepositorio,
                                    IModeloRepositorio modeloRepositorio,
                                    ITurnoRepositorio turnoRepositorio)
        {
            _cursoDbContext = cursoDbContext;
            _cursoRepositorio = cursoRepositorio;
            _categoriaRepositorio = categoriaRepositorio;
            _modeloRepositorio = modeloRepositorio;
            _turnoRepositorio = turnoRepositorio;
        }
        public async Task<CursoOfertaResponse> BuscarCursoOfertaPorId(int idCursoOferta)
        {
            var cursoOferta = await (
               from co in _cursoDbContext.CursosOfertas
               join cu in _cursoDbContext.Cursos on co.IdCurso equals cu.idCurso
               join tu in _cursoDbContext.Turnos on co.IdTurno equals tu.IdTurno
               join ca in _cursoDbContext.Categorias on co.IdCategoria equals ca.IdCategoria
               join mo in _cursoDbContext.Modelos on co.IdModelo equals mo.IdModelo
               where co.IdCursoOferta == idCursoOferta
               select new CursoOfertaResponse
               {
                   IdCursoOferta = co.IdCursoOferta,
                   IdCurso = co.IdCurso,
                   Curso = cu.Nome,
                   CargaHoraria = cu.CargaHoraria,
                   IdTurno = co.IdTurno,
                   Turno = tu.Descricao,
                   IdCategoria = co.IdCategoria,
                   Categoria = ca.Descricao,
                   IdModelo = co.IdModelo,
                   Modelo = mo.Descricao
               })
               .FirstOrDefaultAsync();

            return cursoOferta;
        }

        public async Task<List<CursoOfertaResponse>> BuscarTodosCursosOfertas()
        {
            var cursosOfertas = await (
               from co in _cursoDbContext.CursosOfertas
               join cu in _cursoDbContext.Cursos on co.IdCurso equals cu.idCurso
               join tu in _cursoDbContext.Turnos on co.IdTurno equals tu.IdTurno
               join ca in _cursoDbContext.Categorias on co.IdCategoria equals ca.IdCategoria
               join mo in _cursoDbContext.Modelos on co.IdModelo equals mo.IdModelo
               select new CursoOfertaResponse
               {
                   IdCursoOferta = co.IdCursoOferta,
                   IdCurso = co.IdCurso,
                   Curso = cu.Nome,
                   CargaHoraria = cu.CargaHoraria,
                   IdTurno = co.IdTurno,
                   Turno = tu.Descricao,
                   IdCategoria = co.IdCategoria,
                   Categoria = ca.Descricao,
                   IdModelo = co.IdModelo,
                   Modelo = mo.Descricao
               })
               .ToListAsync();

            return cursosOfertas;
        }
      
        public async Task<CursoOfertaResponse> Adicionar(string cursoRequest,
                                                         string categoriaRequest,
                                                         string modeloRequest,
                                                         string turnoRequest)
        {
            CursoModel cursoModel = await _cursoRepositorio.BuscarCursoPorNome(cursoRequest);
            if(cursoModel == null)
            {
                throw new Exception($"Curso não encontrado. Nome: {cursoRequest}");
            }

            CategoriaModel categoriaModel = await _categoriaRepositorio.BuscarCategoriaPorDescricao(categoriaRequest);
            if (categoriaModel == null)
            {
                throw new Exception($"Categoria não encontrada. Descricao: {categoriaRequest}");
            }

            ModeloModel modeloModel = await _modeloRepositorio.BuscarModeloPorDescricao(modeloRequest);
            if(modeloModel == null)
            {
                throw new Exception($"Modelo não encontrado. Descricao: {modeloRequest}");
            }

            TurnoModel turnoModel = await _turnoRepositorio.BuscarTurnoPorDescricao(turnoRequest);
            if(turnoModel == null)
            {
                throw new Exception($"Turno não encontrado. Descricao:{turnoRequest}");
            }

            CursoOfertaModel cursoOferta = new CursoOfertaModel
            {
                IdCurso = cursoModel.idCurso,
                IdTurno = turnoModel.IdTurno,
                IdCategoria = categoriaModel.IdCategoria,
                IdModelo = modeloModel.IdModelo
            };

            await _cursoDbContext.CursosOfertas.AddAsync(cursoOferta);
            await _cursoDbContext.SaveChangesAsync();

            CursoOfertaResponse cursoOfertaResponse = await BuscarCursoOfertaPorId(cursoOferta.IdCursoOferta);

            return cursoOfertaResponse;
        }
        public async Task<CursoOfertaResponse> Atualizar(string cursoRequest,
                                                         string categoriaRequest,
                                                         string modeloRequest,
                                                         string turnoRequest,
                                                         int idCursoOferta)
        {
            CursoModel cursoModel = await _cursoRepositorio.BuscarCursoPorNome(cursoRequest);
            if (cursoModel == null)
            {
                throw new Exception($"Curso não encontrado. Nome: {cursoRequest}");
            }

            CategoriaModel categoriaModel = await _categoriaRepositorio.BuscarCategoriaPorDescricao(categoriaRequest);
            if (categoriaModel == null)
            {
                throw new Exception($"Categoria não encontrada. Descricao: {categoriaRequest}");
            }

            ModeloModel modeloModel = await _modeloRepositorio.BuscarModeloPorDescricao(modeloRequest);
            if (modeloModel == null)
            {
                throw new Exception($"Modelo não encontrado. Descricao: {modeloRequest}");
            }

            TurnoModel turnoModel = await _turnoRepositorio.BuscarTurnoPorDescricao(turnoRequest);
            if (turnoModel == null)
            {
                throw new Exception($"Turno não encontrado. Descricao:{turnoRequest}");
            }

            CursoOfertaModel cursoOfertaPorId = await _cursoDbContext.CursosOfertas.FirstOrDefaultAsync(x => x.IdCursoOferta == idCursoOferta);

            if (cursoOfertaPorId == null)
            {
                throw new Exception($"Curso Oferta não encontrado. Id: {idCursoOferta}");
            }

            cursoOfertaPorId.IdCurso = cursoModel.idCurso;
            cursoOfertaPorId.Curso = cursoModel;
            cursoOfertaPorId.IdModelo = modeloModel.IdModelo;
            cursoOfertaPorId.Modelo = modeloModel;
            cursoOfertaPorId.IdCategoria = categoriaModel.IdCategoria;
            cursoOfertaPorId.Categoria = categoriaModel;
            cursoOfertaPorId.IdTurno = turnoModel.IdTurno;
            cursoOfertaPorId.Turno = turnoModel;

            _cursoDbContext.CursosOfertas.Update(cursoOfertaPorId);
            await _cursoDbContext.SaveChangesAsync();

            CursoOfertaResponse cursoOfertaResponse = await BuscarCursoOfertaPorId(cursoOfertaPorId.IdCursoOferta);

            return cursoOfertaResponse;
        }

        public async Task<bool> Apagar(int idCursoOferta)
        {
            CursoOfertaModel cursoOfertaPorId = await _cursoDbContext.CursosOfertas.FirstOrDefaultAsync(x => x.IdCursoOferta == idCursoOferta);

            if (cursoOfertaPorId == null)
            {
                throw new Exception($"Curso Oferta não encontrado. Id: {idCursoOferta}");
            }

            _cursoDbContext.CursosOfertas.Remove(cursoOfertaPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }
    }
}
