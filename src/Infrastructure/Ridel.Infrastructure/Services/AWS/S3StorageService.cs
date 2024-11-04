using Amazon.S3.Transfer;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Ridel.Application.Interfaces.Services;
using Amazon.S3.Model;

namespace Ridel.Infrastructure.Services.AWS
{
    internal class S3StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;

        public S3StorageService(IAmazonS3 s3Client, string bucketName)
        {
            _s3Client = s3Client;
            _bucketName = bucketName;
        }


        private async Task DeleteExistingProfilePhotosAsync(string userId)
        {
            var request = new ListObjectsV2Request
            {
                BucketName = _bucketName,
                Prefix = $"{userId}/profile-photo/"
            };

            var response = await _s3Client.ListObjectsV2Async(request);

            if (response.S3Objects.Count > 0)
            {
                var deleteRequest = new DeleteObjectsRequest
                {
                    BucketName = _bucketName
                };

                foreach (var s3Object in response.S3Objects)
                {
                    deleteRequest.Objects.Add(new KeyVersion { Key = s3Object.Key });
                }

                await _s3Client.DeleteObjectsAsync(deleteRequest);
            }
        }

 
        public async Task<string> UploadFileAsync(IFormFile file, string userId)
        {
   
            await DeleteExistingProfilePhotosAsync(userId);

            var key = $"{userId}/profile-photo/{Guid.NewGuid()}_{file.FileName}"; // Kullanıcıya özel fotoğraf anahtarı

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = memoryStream,
                    Key = key,
                    BucketName = _bucketName,
                    ContentType = file.ContentType,
                    CannedACL = S3CannedACL.PublicRead // Fotoğrafı herkes okuyabilsin
                };

                var transferUtility = new TransferUtility(_s3Client);
                await transferUtility.UploadAsync(uploadRequest);
            }

            return $"https://{_bucketName}.s3.amazonaws.com/{key}";
        }

 
        public async Task DeleteFileAsync(string fileUrl)
        {
            var key = fileUrl.Replace($"https://{_bucketName}.s3.amazonaws.com/", "");

            await _s3Client.DeleteObjectAsync(_bucketName, key);
        }
    }
}
