using NSubstitute.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NSubstitute.Test
{
    public class UserNotificationServiceTest
    {
        private UserNotificationService service;
        private IUserRepository userRepository;
        private INotifier notifier;


        [Fact]
        public void Notification_notsend_to_User()
        {
            //Arrange
            userRepository = Substitute.For<IUserRepository>();
            notifier = Substitute.For<INotifier>();
            var service = Substitute.For<UserNotificationService>(userRepository, notifier);

            //Act
            var result = service.NotifyUser(10);

            //Assert
            Assert.False(result == 1);
        }

        [Fact]
        public void Notification_send_to_User()
        {
            //Arrange
            userRepository = Substitute.For<IUserRepository>();
            notifier = Substitute.For<INotifier>();
            var service = Substitute.For<UserNotificationService>(userRepository, notifier);

            //Act
            userRepository.Received<IUserRepository>();
            var result = service.NotifyUser(10);

            //Assert
            Assert.True(result == 1);            
        }

        [Fact]
        public void Notification_send_to_user_exception()
        {
            //Arrange
            userRepository = Substitute.For<IUserRepository>();
            notifier = Substitute.For<INotifier>();
            var service = Substitute.For<UserNotificationService>(userRepository, notifier);

            //Act
            var result = service.NotifyUser(0);

            //Assert
            Assert.True(result == -1, "Exception");
        }

    }
}
