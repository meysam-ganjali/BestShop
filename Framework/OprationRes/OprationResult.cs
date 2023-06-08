namespace Framework.OprationRes;

public class OprationResult
{

    public string Message { get; set; }
    public bool IsSucces { get; set; }

    public OprationResult()
    {
        IsSucces = false;
    }
    public OprationResult Successed(string message = "عملیات با موفقیت انجام شد") {
        this.Message = message;
        this.IsSucces = true;
        return this;
    }
    public OprationResult Failed(string message = "عملیات با شکست مواجهه شد") {
        this.Message = message;
        this.IsSucces = false;
        return this;
    }
}