using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeverGaming.Controllers;
using ForeverGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ForeverGamingTests
{
    public class AccountControllerTests
    {

        public Mock<FakeUserManager> userManagerMock;
        public Mock<FakeSignInManager> signInManagerMock;
        public RegisterViewModel regModel;
        public LoginViewModel logModel;
        //public User user;

        private AccountController controller { get; }

        public AccountControllerTests()
        {
            var list = new List<string> {"admin"};
            var users = new List<User>
            {
                new User
                {
                    UserName = "Test",
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@test.it"
                }

            }.AsQueryable();

            //user = new User {Firstname = "Bob", Lastname = "Foster", RoleNames = list};

            userManagerMock = new Mock<FakeUserManager>();
            signInManagerMock = new Mock<FakeSignInManager>();
            userManagerMock.Setup(x => x.Users)
                .Returns(users);

            userManagerMock.Setup(x => x.DeleteAsync((It.IsAny<User>())))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            userManagerMock.Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            
            //var mapper = (IMapper)fixture.Server.Host.Services.GetService(typeof(IMapper));
            //var errorHandler = (IErrorHandler)fixture.Server.Host.Services.GetService(typeof(IErrorHandler));
            //var passwordhasher = (IPasswordHasher<AppUser>)fixture.Server.Host.Services.GetService(typeof(IPasswordHasher<AppUser>));

            var uservalidator = new Mock<IUserValidator<User>>();
            uservalidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<User>>(), It.IsAny<User>()))
                .ReturnsAsync(IdentityResult.Success);

            var passwordvalidator = new Mock<IPasswordValidator<User>>();
            passwordvalidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<User>>(), It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            signInManagerMock.Setup(
                    x => x.PasswordSignInAsync(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(SignInResult.Success);
          
            controller = new AccountController(userManagerMock.Object, signInManagerMock.Object);
            regModel = new RegisterViewModel
            {
                Username = "admin", Firstname = "Bob", Lastname = "Foster", Email = "BFoster99@gmail.com", Password = "Sesame"
            };
            logModel = new LoginViewModel
            {
                Username = "admin", Password = "Sesame", RememberMe = true, ReturnUrl = string.Empty
            };
      

        }

        [Fact]
        public void RegisterActionMethod_ReturnsAViewResult()
        {
            // arrange

            // act
            var resultTask = controller.Register();
            var result = resultTask;

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void RegisterActionMethod_InvalidModelErrorReturnsARegisterViewResult()
        {
            // arrange
            controller.ModelState.AddModelError("Password", "Required");
            var resultTask = await controller.Register(regModel);
            var result = resultTask;

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void RegisterActionMethod_ValidModelReturnsARegisterViewResult()
        {
            // arrange

            // act
            var resultTask = await controller.Register(regModel);
            var result = resultTask;

            // assert
            Assert.IsType<RedirectToActionResult>(result);
        }


        [Fact]
        public async void LogoutActionMethod_ReturnsARedirectToActionAsync()
        {
            // act
            var resultTask = await controller.LogOut();
            var result = resultTask;
           
            //Assert
            Assert.IsType<RedirectToActionResult>(result);
        }
        
        [Fact]
        public void LoginActionMethod_ReturnsAIActionResult()
        {
            // arrange

            // act
            var result = controller.LogIn();

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void LoginActionMethod_ReturnsAIActionResult_Model()
        {
            // arrange

            // act
            var resultTask = await controller.LogIn(logModel);
            var result = resultTask;

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void LoginActionMethod_InvalidModelReturnsALoginViewModel()
        {
            // arrange
            controller.ModelState.AddModelError("Password", "Required");
            // act
            var resultTask = await controller.LogIn(logModel);
            var result = resultTask;

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AccessDeniedActionMethod_ReturnsAViewResult()
        {
            // arrange

            // act
            var result = controller.AccessDenied();

            // assert
            Assert.IsType<ViewResult>(result);
        }
        
    }
}
