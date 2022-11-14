namespace DocConverter.ApplicationCore.Common.Interfaces
{
    public interface IConverter
    {
        Task<byte[]> Convert();
    }
}
