using DocConverter.ApplicationCore.Common.Constants;
using DocConverter.ApplicationCore.Common.Interfaces;
using DocConverter.Domain.Entities;
using DocConverter.Infrastructure.Utilities;

namespace DocConverter.Infrastructure.Services
{
    public class LibreConverter : IConverter
    {
        private string СonversionСommand => $" --headless --convert-to {_convertibleItem.ConvertTo}";
        private readonly ConvertibleItem _convertibleItem;

        public LibreConverter(ConvertibleItem convertibleItem)
        {
            _convertibleItem = convertibleItem;
        }

        public virtual async Task<byte[]> Convert()
        {
            await FileHelpers.SaveFileAsync(_convertibleItem.File, _convertibleItem.UniqueFileName, AppSettings.WorkingDirectory);
            await ProcessRunner.RunProcessAsync(
                AppSettings.AppConverter, 
                $"{СonversionСommand} \"{_convertibleItem.UniqueFileName}\"",
                AppSettings.WorkingDirectory);

            var outPath = Path.Combine(AppSettings.WorkingDirectory, $"{_convertibleItem.UniqueFileNameWithoutExtension}.{_convertibleItem.ConvertTo}");
            var result = await FileHelpers.GetFileInBuffer(outPath);

            ClearFiles(Path.Combine(AppSettings.WorkingDirectory, _convertibleItem.UniqueFileName), outPath);

            return result;
        }

        private static void ClearFiles(string inFile, string outFile)
        {
            File.Delete(inFile);
            File.Delete(outFile);
        }
    }
}
