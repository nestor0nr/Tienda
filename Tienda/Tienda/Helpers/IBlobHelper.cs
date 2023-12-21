namespace Tienda.Helpers
{
    public interface IBlobHelper
    { // https://www.youtube.com/watch?v=gcsq9-A3eiQ
        Task<Guid> UploadBlobAsync(IFormFile file, string containerName);

        Task<Guid> UploadBlobAsync(byte[] file, string containerName);

        Task<Guid> UploadBlobAsync(string image, string containerName);

        Task DeleteBlobAsync(Guid id, string containerName);
    }
}

