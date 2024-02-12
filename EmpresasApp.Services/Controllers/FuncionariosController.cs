using AutoMapper;
using EmpresasApp.Domain.Entities;
using EmpresasApp.Domain.Interfaces.Services;
using EmpresasApp.Domain.Services;
using EmpresasApp.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpresasApp.Services.Controllers
{
    /// <summary>
    /// Classe de controle para o ENDPOINT de serviço de funcionarios da API
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
     
    {
        private readonly IFuncionarioDomainService? _funcionarioDomainService;
        private readonly IMapper? _mapper;

        public FuncionariosController(IFuncionarioDomainService? funcionarioDomainService, IMapper? mapper)
        {
            _funcionarioDomainService = funcionarioDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Método para cadastrar funcionarios.
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] FuncionariosPostModel model)
        {
            try
            {
                var funcionario = _mapper?.Map<Funcionario>(model);
                _funcionarioDomainService?.Cadastrar(funcionario);

                return StatusCode(201, new
                {
                    mensagem = "Funcionario cadastrado com sucesso.",
                    Id = funcionario.Id
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
        /// Método para atualizar funcionario.
        /// </summary>
        [HttpPut]
        public IActionResult Put([FromBody] FuncionariosPutModel model, Guid id)
        {
            {
                try
                {
                    var funcionario = _mapper?.Map<Funcionario>(model);
                    _funcionarioDomainService?.Atualizar(funcionario);

                    return StatusCode(200, new
                    {
                        mensagem = "Funcionario atualizado com sucesso.",
                        Id = funcionario.Id
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
        }

        /// <summary>
        /// Método para exclusão de funcionario.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _funcionarioDomainService?.Excluir(id);
                return StatusCode(200, new
                {
                    mensagem = "Funcionario excluída com sucesso.",
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
        /// Método para consulta de tarefas.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var funcionarios = _mapper.Map<List<FuncionariosGetModel>>(_funcionarioDomainService?.Consultar());
            return Ok(funcionarios);
        }
        /// <summary>
        /// Método para consultar 1 funcionario através do ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var tarefa = _mapper?.Map<FuncionariosGetModel>(_funcionarioDomainService?.ObterPorId(id));
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
