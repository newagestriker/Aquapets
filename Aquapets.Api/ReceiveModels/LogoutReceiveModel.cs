namespace Aquapets.Shared.Api.ReceiveModels
{
    public class LogoutReceiveModel
    {
        public string Message { get; set; }

        public LogoutReceiveModel(string message)
        {
            this.Message = message;
        }
    }
}
