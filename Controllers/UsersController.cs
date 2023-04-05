using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using cv_fresher_api.Models;
namespace cv_fresher_api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase, IController<User>
{
    CvGenerateContext db = new CvGenerateContext();

    [HttpGet]
    [Route("get")]
    public string Get(string userid, string employerName = "name"){
        User user = db.Users.FirstOrDefault(x => x.UserId == userid);
        string jsonString = JsonSerializer.Serialize(user);
        return jsonString; 
    }
    
    [HttpPost]
    [Route("add")]
    public string Post(User user){
        db.Users.Add(user);
        db.SaveChanges();
        return "User added.";
    }

    [HttpDelete]
    [Route("delete")]
    public string Delete(string userid){
        var user = db.Users.FirstOrDefault(x => x.UserId == userid); 
        db.Users.Remove(user);
        db.SaveChanges();
        return "User Deleted.";
    }

   
}

