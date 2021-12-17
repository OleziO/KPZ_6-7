using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using ComputerCompany.DAL.Repositories.Interfaces;
using ComputerCompany.DTOs;
using ComputerCompany.Models;
using ComputerCompany.ViewModels;

namespace ComputerCompany.Controllers
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all clients
        /// </summary>
        /// <returns>IEnumerable of <see cref="ClientViewModel"/></returns>
        [HttpGet, Route("getAll")]
        public IEnumerable<ClientViewModel> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return _mapper.Map<IEnumerable<ClientViewModel>>(clients);
        }

        /// <summary>
        /// Gets the client with specified id
        /// </summary>
        /// <param name="id">id of the client</param>
        /// <returns><see cref="ClientViewModel"/></returns>
        [HttpGet, Route("getById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var client = _clientRepository.GetById(id);

            if (client is null)
            {
                return NotFound();
            }

            var clientViewModel = _mapper.Map<ClientViewModel>(client);
            return new OkObjectResult(clientViewModel);
        }

        /// <summary>
        /// Creates and adds new client to database
        /// </summary>
        /// <param name="clientDto">new client object</param>
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = _mapper.Map<Client>(clientDto);
            _clientRepository.Add(client);

            return Ok();
        }

        /// <summary>
        /// Changes the properties of the specified client in db
        /// </summary>
        /// <param name="clientDto">the changed version of the client</param>
        [HttpPut, Route("change/{id:int}")]
        public IActionResult Change(int id, [FromBody] ClientDto clientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_clientRepository.GetById(clientDto.Id) is null)
            {
                return NotFound();
            }

            var client = _mapper.Map<Client>(clientDto);
            _clientRepository.Change(client);

            return Ok();
        }

        /// <summary>
        /// Removes the client with specified id from the db
        /// </summary>
        /// <param name="id">id of the specified client</param>
        /// <returns>the deleted <see cref="ClientViewModel"/> object</returns>
        [HttpDelete, Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var deletedClient = _clientRepository.DeleteById(id);

            if (deletedClient is null)
            {
                return NotFound();
            }

            return new OkObjectResult(deletedClient);
        }
    }
}
