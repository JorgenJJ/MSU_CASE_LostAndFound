using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MSU_Case_LostAndFound.Areas.Identity.Data;
using MSU_Case_LostAndFound.Model;


namespace MSU_Case_LostAndFound.Pages
{
    public class RegisterFoundModel : PageModel
    {
        //COMMENT:declaration of ApplicationDbContext for an instance of our //database context.
        private readonly RescuteDBContext _db;
        //private readonly AzureStorageConfig _storageConfig;
        private readonly AzureStorageConfig _storageConfig = null;
        private readonly UserManager<ApplicationUser> _userManager;
            

    public RegisterFoundModel(RescuteDBContext db, IOptions<AzureStorageConfig> config, UserManager<ApplicationUser> userManager)
    {
            _db = db;
            _storageConfig = config.Value;
        _userManager = userManager;

    }


    [BindProperty]
        public AnimalsFound AnimalsFound { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(IFormCollection form)
        {
            

            if (ModelState.IsValid)
            {
                var file = form.Files.FirstOrDefault();

                using (Stream stream = file.OpenReadStream())
                {
                    // Create a URI to the blob
                    String stringUrl = "https://" +
                                          _storageConfig.AccountName +
                                          ".blob.core.windows.net/" +
                                          _storageConfig.ImageContainer +
                                          "/" + file.FileName;
                    Uri blobUri = new Uri(stringUrl);

                    // Create StorageSharedKeyCredentials object by reading
                    // the values from the configuration (appsettings.json)
                    StorageSharedKeyCredential storageCredentials =
                        new StorageSharedKeyCredential(_storageConfig.AccountName, _storageConfig.AccountKey);

                    // Create the blob client.
                    BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

                    // Upload the file
                    await blobClient.UploadAsync(stream);

                    AnimalsFound.ImageUrl = stringUrl;

                }

                if (User.Identity.IsAuthenticated)
                {
                    AnimalsFound.UserId = _userManager.GetUserId(HttpContext.User);
                }
                await _db.AnimalsFound.AddAsync(AnimalsFound);
                await _db.SaveChangesAsync();

                //COMMENT:if we got this far, it was successful so let's tell the user.
                //set a tempData variable to a success string. we will use this //variable after the redirect to the gallery.
                TempData["SuccessMessage"] = "Image upload success!";

                return RedirectToPage("Found");

            }
            else
            {
                return Page();
            }
        }
    }
}
