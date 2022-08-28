namespace Aquapets.Shared.Api.ReceiveModels
{
    public class PasswordResetEmailConfirmationReceiveModel
    {
        public PasswordResetEmailConfirmationReceiveModel(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}
