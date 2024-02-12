using AutoMapper;
using EmpresasApp.Domain.Entities;
using EmpresasApp.Domain.Interfaces.Services;
using EmpresasApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpresasApp.Services.Controllers
{
    /// <summary>
    /// Classe de controle para o ENDPOINT de serviço de empresas da API
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaDomainService? _empresaDomainService;
        private readonly IMapper? _mapper;

        public EmpresasController(IEmpresaDomainService? empresaDomainService, IMapper? mapper)
        {
            _empresaDomainService = empresaDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Método para cadastrar empresa.
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] EmpresasPostModel model)
        {
            try
            {
                var empresa = _mapper?.Map<Empresa>(model);
                _empresaDomainService?.Cadastrar(empresa);

                return StatusCode(201, new
                {
                    mensagem = "Empresa cadastrada com sucesso.",
                    Id = empresa.Id
                });

            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    mensagem = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }

        /// <summary>
        /// Método para atualizar empresa.
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] EmpresasPutModel model, Guid id)
        {
            try
            {
                var empresa = _mapper?.Map<Empresa>(model);
                _empresaDomainService?.Atualizar(empresa);

                return StatusCode(200, new
                {
                    mensagem = "Empresa atualizada com sucesso.",
                    Id = empresa.Id
                });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    mensagem = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }

        /// <summary>
        /// Método para exclusão de empresa.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _empresaDomainService?.Excluir(id);
                return StatusCode(200, new
                {
                    mensagem = "Empresa excluída com sucesso.",
                    Id = id
                });
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new
                {
                    mensagem = e.Message
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }
            
        /// <summary>
        /// Método para consulta de empresa.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
                var empresas = _mapper.Map<List<EmpresasGetModel>>(_empresaDomainService?.Consultar());
            return Ok(empresas);
        }

        /// <summary>
        /// Método para consultar 1 empresa através do ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var tarefa = _mapper?.Map<EmpresasGetModel>(_empresaDomainService?.ObterPorId(id));
                return StatusCode(200, tarefa);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    mensagem = e.Message
                });
            }
        }
    }
}
