﻿using HotelAPI.Services;
using ManageHotels.Interfaces;
using ManageHotels.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationAndLogin.Model;

namespace ManageHotels.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IRepo<int, Hotels> _repo;

        public HotelsController(IRepo<int, Hotels> repo)
        {
                 _repo = repo;  
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Hotels> Add([FromBody] Hotels hotel)
        {
            var addHotel = _repo.Add(hotel);
            if (addHotel == null)
            {
                return BadRequest("Unable to add");
            }
            return Created("Welcome", addHotel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> Update([FromBody] Hotels hotel)
        {
            var updateHotel = _repo.Update(hotel);
            if (updateHotel == null)
            {
                return BadRequest("Unable to update");
            }
            return Ok(updateHotel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> Get([FromBody] int key)
        {
            var getOneHotel = _repo.Get(key);
            if (getOneHotel == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getOneHotel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> GetAll()
        {
            var getAllHotel = _repo.GetAll();
            if (getAllHotel == null)
            {
                return BadRequest("Unable to fetch");
            }
            return Ok(getAllHotel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Hotels>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Hotels> Delete(int key)
        {
            var getAllHotel = _repo.Delete(key);
            if (getAllHotel == null)
            {
                return BadRequest("Unable to delete");
            }
            return Ok(getAllHotel);
        }
    }
}
