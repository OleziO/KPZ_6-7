using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using ComputerCompany.DAL.Repositories.Interfaces;
using ComputerCompany.DTOs;
using ComputerCompany.Models;
using ComputerCompany.ViewModels;

namespace ComputerCompany.Controllers
{
    [Route("api/goods")]
    public class GoodsController : Controller
    {
        private readonly IGoodsRepository _goodsRepository;
        private readonly IMapper _mapper;

        public GoodsController(IGoodsRepository goodsRepository, IMapper mapper)
        {
            _goodsRepository = goodsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all goods
        /// </summary>
        /// <returns>IEnumerable of <see cref="Goods"/></returns>
        [HttpGet, Route("getAll")]
        public IEnumerable<GoodsViewModel> GetAll()
        {
            var goods = _goodsRepository.GetAll();
            return _mapper.Map<IEnumerable<GoodsViewModel>>(goods);
        }

        /// <summary>
        /// Gets the goods with specified id
        /// </summary>
        /// <param name="id">id of the goods</param>
        /// <returns><see cref="OkObjectResult"/> or the <see cref="NotFoundResult"/></returns>
        [HttpGet, Route("getById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var goods = _goodsRepository.GetById(id);

            if (goods is null)
            {
                return NotFound();
            }

            var goodsViewModel = _mapper.Map<GoodsViewModel>(goods);
            return new OkObjectResult(goodsViewModel);
        }

        /// <summary>
        /// Creates and adds new goods to database
        /// </summary>
        /// <param name="goodsDto">new goods object</param>
        [HttpPost, Route("add")]
        public IActionResult Add([FromBody] GoodsDto goodsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var goods = _mapper.Map<Goods>(goodsDto);
            _goodsRepository.Add(goods);

            return Ok();
        }

        /// <summary>
        /// Changes the properties of the specified goods in db
        /// </summary>
        /// <param name="goodsDto">the changed version of the goods</param>
        [HttpPut, Route("change/{id:int}")]
        public IActionResult Change(int id, [FromBody] GoodsDto goodsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_goodsRepository.GetById(goodsDto.Id) is null)
            {
                return NotFound();
            }

            var goods = _mapper.Map<Goods>(goodsDto);
            _goodsRepository.Change(goods);

            return Ok();
        }

        /// <summary>
        /// Removes the goods with specified id from the db
        /// </summary>
        /// <param name="id">id of the specified goods</param>
        /// <returns>the deleted <see cref="GoodsViewModel"/> object</returns>
        [HttpDelete, Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var deletedGoods = _goodsRepository.DeleteById(id);

            if (deletedGoods is null)
            {
                return NotFound();
            }

            return new OkObjectResult(deletedGoods);
        }
    }
}
