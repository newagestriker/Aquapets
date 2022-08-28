namespace Aquapets.Shared.Api.ReceiveModels
{
    public class UserIdReceiveModel
    {
        public UserIdReceiveModel(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; set; }
    }
}
