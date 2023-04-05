using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using cv_fresher_api.Models;
namespace cv_fresher_api.Controllers;

[ApiController]
[Route("skill")]

public class SkillsController : ControllerBase, IController<Skill>
{
     CvGenerateContext db = new CvGenerateContext();

    [HttpGet]
    [Route("get")]
    public string Get(string userid, string employerName = "name"){
       Skill skill = db.Skills.FirstOrDefault(x => x.UserId == userid);
       string jsonString = JsonSerializer.Serialize(skill);
       return jsonString;
    }

    [HttpPost]
    [Route("add")]
    public string Post(Skill skill){
        db.Skills.Add(skill);
        db.SaveChanges();
        return "Skills added";
    }

    [HttpDelete]
    [Route("delete")]
    public string Delete(string userid){
        var user = db.Users.FirstOrDefault(x => x.UserId == userid); 
        db.Skills.Remove(db.Skills.FirstOrDefault(e => e.UserId == user.UserId));
        db.SaveChanges();
        return "Skills Deleted.";
    }


    
}