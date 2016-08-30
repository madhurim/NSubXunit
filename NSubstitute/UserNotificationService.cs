using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubstitute.Code
{
    public class UserNotificationService
    {
        private readonly IUserRepository userRepository;
        private readonly INotifier notifier;        

        public UserNotificationService(IUserRepository userRepository, INotifier notifier)
        {
            userRepository = userRepository;
            notifier = notifier;
        }
        
        public int NotifyUser(int userId)
        {
            User user;

            try
            {
                user = userRepository.GetById(userId);
            }
            catch (Exception ex)
            {                
                return -1;
            }

            if (user.HasActivatedNotification)
            {
                notifier.Notify(user);
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
