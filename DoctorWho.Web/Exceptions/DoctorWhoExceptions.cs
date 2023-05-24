using System.Net;

namespace DoctorWho.Web.Exceptions;

public class DoctorWhoExceptions : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
}