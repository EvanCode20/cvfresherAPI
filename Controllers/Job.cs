using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using cv_fresher_api.Models;
namespace cv_fresher_api.Controllers;

[ApiController]
[Route("job")]

public class JobsController : ControllerBase, IController<Job>
{
     CvGenerateContext db = new CvGenerateContext();

     [HttpDelete]
     [Route("delete")]
    public string Delete(string userid)
    {
        var job = db.Jobs.FirstOrDefault(x => x.UserId == userid); 
        db.Jobs.Remove(job);
        db.SaveChanges();
        return "Job Deleted";
    }

    [HttpGet]
    [Route("get")]
    public string Get(string userid, string employerName = "name")
    {
       Job job = db.Jobs.FirstOrDefault(x => x.UserId == userid);
       string jsonString = JsonSerializer.Serialize(job);
       return jsonString;
    }

   

    [HttpPost]
    [Route("post")]
    public string Post(Job obj)
    {
       db.Jobs.Add(obj);
       db.SaveChanges();
       return "Job added";
    }
}