using biteminds.promote.api.Services;
using biteminds.promote.data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace biteminds.promote.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : ControllerBase
    {
        readonly PromocionService _service;

        public PromocionController(PromocionService promocionService)
        {
            this._service = promocionService;
        }
        // GET: api/<PromocionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET api/<PromocionController>/5
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var promocion = await _service.GetByIdAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }
            return Ok(promocion);
        }

        // POST api/<PromocionController>
        [HttpPost]
        public async Task<IActionResult> Create(Promocion promocion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _service.CreateAsync(promocion);
            return Ok(promocion.Id);
        }

        // PUT api/<PromocionController>/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Promocion promocionIn)
        {
            var promocion = await _service.GetByIdAsync(id);
            if (promocionIn == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(id, promocionIn);
            return NoContent();
        }

        // DELETE api/<PromocionController>/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var promocion = await _service.GetByIdAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(promocion.Id);
            return NoContent();
        }
    }
}
