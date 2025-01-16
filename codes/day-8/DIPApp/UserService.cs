namespace DIPApp
{
    public class UserService
    {
        //pass reference of an instance of a class whihc implements IMessageService
        //private IMessageService messageService;
        private readonly IMessageService messageService;
        public UserService(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        // public IMessageService MessageService
        // {
        //     get { return messageService; }
        //     set { messageService = value; }
        // }
        public void RegisterUser(string email, string strongPassword)
        {
            if (!messageService.Validate(email))
            {
                throw new Exception($"{email} is invalid mail id");
            }
            messageService.SendMessage("Happy New Year 2025...", email);
        }
    }
}
