using DocConverter.Domain.Entities;
using DocConverter.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Xunit;

namespace WebApiTests.Controllers
{
    public class ConverterTests
    {
        [Fact]
        public async Task ConvertFileReturnsFile()
        {
            using var fileStream = new FileStream(Path.Combine("Files", "payslip.xlsx"), FileMode.Open);
            var convertibleItem = new ConvertibleItem(new FormFile(fileStream, 0, fileStream.Length, "file", fileStream.Name));
            await new LibreConverter(convertibleItem).Convert();
        }
    }
}
