using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateImagesController : ControllerBase
    {
        ICertificateImageService _certificateImageService;

        public CertificateImagesController(ICertificateImageService certificateImageService)
        {
            _certificateImageService = certificateImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CertificateImage certificateImage)
        {
            var result = _certificateImageService.Add(file, certificateImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var certificateImage = _certificateImageService.Get(id).Data;
            var result = _certificateImageService.Delete(certificateImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var certificateImage = _certificateImageService.Get(Id).Data;
            var result = _certificateImageService.Update(file, certificateImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _certificateImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _certificateImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycertificateid")]
        public IActionResult GetImagesByBlogId(int certificateId)
        {
            var result = _certificateImageService.GetImagesByCertificateId(certificateId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }







    }
}
