namespace DoctorWho.Web.Exceptions;

public class DoctorNotFound : DoctorWhoExceptions
{
    public DoctorNotFound(string Message)
    {
        this.Message = Message;
        this.StatusCode = System.Net.HttpStatusCode.NotFound;
    } 
}
