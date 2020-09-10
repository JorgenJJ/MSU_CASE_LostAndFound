using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using MSU_Case_LostAndFound.Models;


namespace MSU_Case_LostAndFound.Pages
{
    public class RegisterModel : PageModel
    {
        //COMMENT:declaration of ApplicationDbContext for an instance of our //database context.
        private readonly RescuteDBContext _db;
        //private readonly AzureStorageConfig _storageConfig;



        //COMMENT:static declaration of the CloudBlobClient so we can //interact with our storage service.
        static CloudBlobClient blobClient;
        //COMMENT:constant to hold the blob container name
        const string BLOB_CONTAINER_NAME = "image";
        //COMMENT:static declaration of CloudBlobContainer which will store //a reference to the blobcontainer that we created earlier
        static CloudBlobContainer blobContainer;
        //COMMENT:setup our configuration so that we can have access to the //Azure storage connection string later.
        public IConfiguration _configuration;

        public RegisterModel(RescuteDBContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public static bool IsImage(IFormFile file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            return formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        [BindProperty]
        public AnimalsLost AnimalsLost { get; set; }

        public async Task OnGet()
        {
            // COMMENT:Retrieve storage account information from connection string
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_configuration.GetConnectionString("AzureStorageConnectionString"));
            // COMMENT:Create a blob client for interacting with the storage //blob service.
            blobClient = storageAccount.CreateCloudBlobClient();
            //COMMENT:this gets a reference to the container that we created earlier
            blobContainer = blobClient.GetContainerReference(BLOB_CONTAINER_NAME);
            //COMMENT:this will create a container with the name that we passed //above in the event that the container doesn't exist.
            await blobContainer.CreateIfNotExistsAsync();
            //COMMENT:set permissions to public access
            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
        }

        public async Task<IActionResult> OnPost(IFormCollection form)
        {
            //var file = form.Files.FirstOrDefault();


            //using (Stream stream = file.OpenReadStream())
            //{
            //    // Create a URI to the blob
            //    Uri blobUri = new Uri("https://" +
            //                          _storageConfig.AccountName +
            //                          ".blob.core.windows.net/" +
            //                          _storageConfig.ImageContainer +
            //                          "/" + file.FileName);

            //    // Create StorageSharedKeyCredentials object by reading
            //    // the values from the configuration (appsettings.json)
            //    StorageSharedKeyCredential storageCredentials =
            //        new StorageSharedKeyCredential(_storageConfig.AccountName, _storageConfig.AccountKey);

            //    // Create the blob client.
            //    BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            //    // Upload the file
            //    await blobClient.UploadAsync(stream);
            //}

            if (ModelState.IsValid)
            {
                //COMMENT:we are only allowing one upload, so just get the first one //in the file collection.
                var file = form.Files.FirstOrDefault();
                //COMMENT:this block will store the image into the blobContainer //container
                CloudBlockBlob blob = blobContainer.GetBlockBlobReference(file?.FileName);
                blob.Properties.ContentType = file?.ContentType;
                await blob.UploadFromStreamAsync(file?.OpenReadStream());
                //COMMENT:set the url of the image that we just uploaded
                AnimalsLost.ImageUrl = $"{blobContainer.StorageUri.PrimaryUri}/{file?.FileName}";

                await _db.AnimalsLost.AddAsync(AnimalsLost);
                await _db.SaveChangesAsync();

                //COMMENT:if we got this far, it was successful so let's tell the user.
                //set a tempData variable to a success string. we will use this //variable after the redirect to the gallery.
                TempData["SuccessMessage"] = "Image upload success!";

                return RedirectToPage("Lost");

            }
            else
            {
                return Page();
            }
        }
    }
}
