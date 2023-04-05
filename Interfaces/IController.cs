using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using cv_fresher_api.Models;

namespace cv_fresher_api;

public interface IController<T>
{
    public string Get(string userid, string employerName = "name");
    public string Post(T obj);
    public string Delete(string userid);
    
}