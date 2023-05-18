using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoiThat.Services;

namespace NoiThat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileInFoController : ControllerBase
    {
        private readonly FileServices _fileService;

        public FileInFoController(FileServices fileService)
        {
            _fileService = fileService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }



        // download file(s) to client according path: rootDirectory/subDirectory with single zip file
        [HttpGet("Download/{subDirectory}")]
        public IActionResult DownloadFiles(string subDirectory)
        {
            try
            {
                var (fileType, archiveData, archiveName) = _fileService.FetechFiles(subDirectory);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }





        // upload file(s) to server that palce under path: rootDirectory/subDirectory
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm(Name = "file")] List<IFormFile> files, string subDirectory)
        {
            try
            {
                _fileService.SaveFile(files, subDirectory);
                return Ok(new { files.Count, Size = FileServices.SizeConverter(files.Sum(f => f.Length)) });
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }
    }
}

