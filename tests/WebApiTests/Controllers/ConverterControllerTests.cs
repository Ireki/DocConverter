using Xunit;

namespace WebApiTests.Controllers
{
    public class ConverterControllerTests
    {
        [Fact]
        public async Task ConvertFileReturnsFile()
        {
            //using var fileStream = new FileStream(@"Files/payslip.xlsx", FileMode.Open);
            //var convertibleItem = new ConvertibleItem(new FormFile(fileStream, 0, fileStream.Length, "file", fileStream.Name), ) { File = new FormFile(fileStream, 0, fileStream.Length, "file", fileStream.Name) };
            //var controller = new ConverterController();
            //var result = await controller.ConvertFile(convertibleItem);
        }
    }
}
