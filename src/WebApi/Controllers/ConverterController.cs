﻿using DocConverter.Domain.Entities;
using DocConverter.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocConverter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {

        private readonly ILogger<ConverterController> _logger;

        public ConverterController(ILogger<ConverterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]  
        public async Task<IActionResult> ConvertFile(IFormFile file, string convertTo = "pdf")
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var convertibleItem = new ConvertibleItem(file, convertTo);
            var convertedFile = await new LibreConverter(convertibleItem).Convert();
            var newFileName = $"{convertibleItem.FileNameWithoutExtension}.{convertibleItem.ConvertTo}";

            return File(convertedFile, $"application/{convertibleItem.ConvertTo}", newFileName);
        }

    }

}
