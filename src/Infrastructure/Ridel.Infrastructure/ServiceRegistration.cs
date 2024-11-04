using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ridel.Application.Interfaces.Services;
using Ridel.Infrastructure.Services.AWS;
using System.Data.Entity;

namespace Ridel.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection? awsSettings = configuration.GetSection("AWS");




            #region AWSS3
            var awsOptions = new AWSOptions
            {
                Credentials = new BasicAWSCredentials(awsSettings["AccessKey"], awsSettings["SecretKey"]),
                Region = RegionEndpoint.GetBySystemName(awsSettings[key: "Region"])
            };
            services.AddAWSService<IAmazonS3>(awsOptions);

            services.AddDefaultAWSOptions(configuration.GetAWSOptions());

            services.AddScoped<IStorageService, S3StorageService>(sp =>
            {
                var s3Client = sp.GetRequiredService<IAmazonS3>();
                var bucketName = awsSettings["BucketName"];
                return new S3StorageService(s3Client, bucketName);
            });
       
       

            #endregion

        }
    }
}
