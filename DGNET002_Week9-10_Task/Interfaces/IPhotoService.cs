using CloudinaryDotNet.Actions;

namespace DGNET002_Week9_10_Task.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile imageFile);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}