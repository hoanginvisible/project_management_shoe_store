namespace QuanLyCuaHangBanGiay.Controllers;

public class Reponse
{
    public string message { get; set; }
    public Boolean state { get; set; }

    public Reponse(string message, bool state)
    {
        this.message = message;
        this.state = state;
    }
}