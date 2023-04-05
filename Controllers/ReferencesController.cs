using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using cv_fresher_api.Models;
namespace cv_fresher_api.Controllers;

[ApiController]
[Route("ref")]

public class ReferencesController : ControllerBase, IController<Reference>
{
    CvGenerateContext db = new CvGenerateContext();

     [HttpGet]
    [Route("get")]
    public string Get(string userid, string employerName)
    {
        Reference requestedContent = new Reference();
        var lsRef = db.References.Where(x => x.UserId == userid).ToArray();
       for(int i = 0; i < lsRef.Count(); i++){
        if(lsRef[i].EmployerName == employerName){
            return JsonSerializer.Serialize(lsRef[i]);;
        }
       }
       return null;
    }

    [HttpDelete]
    [Route("delete")]
    public string Delete(string userid)
    {
        var r = db.References.FirstOrDefault(x => x.UserId == userid);
        db.References.Remove(r);
        db.SaveChanges();
        return "Reference deleted";
    }

   

 
    [HttpPost]
    [Route("add")]
    public string Post(Reference obj)
    {
        throw new NotImplementedException();
    }
}