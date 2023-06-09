namespace Framework.OprationRes;

public class OprationResult
{

    public string Message { get; set; }
    public bool IsSuccedded { get; set; }

    public OprationResult()
    {
        IsSuccedded = false;
    }
    public OprationResult Successed(string message = "عملیات با موفقیت انجام شد") {
        this.Message = message;
        this.IsSuccedded = true;
        return this;
    }
    public OprationResult Failed(string message = "عملیات با شکست مواجهه شد") {
        this.Message = message;
        this.IsSuccedded = false;
        return this;
    }
}