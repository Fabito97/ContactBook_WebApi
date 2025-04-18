﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DGNET002_Week9_10_Task.Helper;
using DGNET002_Week9_10_Task.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;

namespace DGNET002_Week9_10_Task.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile imageFile)
        {               
            try
            {
                var uploadResult = new ImageUploadResult();

                using var stream = imageFile.OpenReadStream();

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, stream),
                    Transformation = new Transformation().Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult;
            }
            catch (Exception ex)
            {
                throw new Exception("Image upload failed " + ex.Message);
            }           
           
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
