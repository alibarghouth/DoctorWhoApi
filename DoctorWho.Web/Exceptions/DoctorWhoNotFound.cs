namespace DoctorWho.Web.Exceptions;

public class DoctorWhoNotFound : DoctorWhoExceptions
{
    public DoctorWhoNotFound(string Message)
    {
        this.Message = Message;
        this.StatusCode = System.Net.HttpStatusCode.NotFound;
    } 
}
