﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.OfferDtos;
using Multishop.Catalog.Services.Abstract;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService offerService;
        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet("Offers")]
        public async Task<IActionResult> Offers()
        {
            var offerDtos = await offerService.GetAllAsync();
            if (offerDtos is null) return NotFound("In system, offer has not been yet !");

            return Ok(offerDtos);
        }

        [HttpGet("GetBy/{offerId}")]
        public async Task<IActionResult> GetBy(string offerId)
        {
            var offerDto = await offerService.GetFirstOrDefaultAsync(offer => offer.Id == offerId);
            if (offerDto is null) return NotFound();

            return Ok(offerDto);
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(OfferAddDto offerAddDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or incorrect entry !");

            await offerService.AddAsync(offerAddDto);
            return Ok($"{offerAddDto.Title} was added successfully !");
        }

        [Authorize]
        [HttpDelete("Delete/{offerId}")]
        public async Task<IActionResult> Delete(string offerId)
        {
            if (string.IsNullOrWhiteSpace(offerId)) return BadRequest("Missing or incorrect entry !");

            await offerService.DeleteAsync(offerId);
            return Ok("This offer was deleted successfully !");
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(OfferUpdateDto offerUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest("Missing or inccorect entry !");

            await offerService.UpdateAsync(offerUpdateDto);
            return Ok($"{offerUpdateDto.Title} was updated successfully !");
        }
    }
}