using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using cv_fresher_api.Models;
namespace cv_fresher_api.Controllers;

[ApiController]
[Route("edu")]
public class EducationsController : ControllerBase, IController<Education>
{
    CvGenerateContext db = new CvGenerateContext();

    [HttpGet]
    [Route("get")]
    public string Get(string userid, string employerName = "name"){
       Education edu = db.Educations.FirstOrDefault(x => x.UserId == userid);
       string jsonString = JsonSerializer.Serialize(edu);
       return jsonString;
    }

    [HttpPost]
    [Route("add")]
    public string Post(Education edu){
        db.Educations.Add(edu);
        db.SaveChanges();
        return "Education added";
    }

    [HttpDelete]
    [Route("delete")]
    public string Delete(string userid){
        var user = db.Users.FirstOrDefault(x => x.UserId == userid); 
        db.Educations.Remove(db.Educations.FirstOrDefault(e => e.UserId == user.UserId));
        db.SaveChanges();
        return "Education Deleted.";
    }


    

    
    
    
    

}