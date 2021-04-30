using System.Collections.Generic;
using System.Threading.Tasks;
using ForeverGaming.Controllers;
using ForeverGaming.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ForeverGamingTests
{
    public class AccountControllerTests
    {

        public Mock<FakeUserManager> userManagerMock;
        public Mock<FakeSignInManager> signInManagerMock;
        public AccountController controller;
        public RegisterViewModel regModel;
        public LoginViewModel logModel;
        public User user;

        public AccountControllerTests()
        {
            var list = new List<string> {"admin"};
            user = new User {Firstname = "Bob", Lastname = "Foster", RoleNames = list};

            userManagerMock = new Mock<FakeUserManager>();
            signInManagerMock = new Mock<FakeSignInManager>();
            controller = new AccountController(userManagerMock.Object, signInManagerMock.Object);
            regModel = new RegisterViewModel
            {
                Username = "Bfoster", Firstname = "Bob", Lastname = "Foster", Email = "BFoster99@gmail.com", Password = "Sesame99"
            };
            logModel = new LoginViewModel
            {
                Username = "Bfoster", Password = "Sesame99", RememberMe = false, ReturnUrl = string.Empty
            };

        }

        [Fact]
        public void RegisterActionMethod_ReturnsAViewResult()
        {
            // arrange

            // act
            var result = controller.Register();

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void RegisterActionMethod_InvalidModelErrorReturnsARegisterViewResult()
        {
            // arrange
            controller.ModelState.AddModelError("Password", "Required");

            var resultTask = controller.Register(regModel);
            resultTask.Wait();
            var result = resultTask.Result;

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void RegisterActionMethod_ValidModelReturnsARegisterViewResult()
        {
            // arrange

            // act
            var resultTask = controller.Register(regModel);
            resultTask.Wait();
            var result = resultTask.Result;

            // assert
            Assert.Null(result);
        }


        [Fact]
        public void LogoutActionMethod_ReturnsARedirectToActionAsync()
        {
            // act
            var resultTask = controller.LogOut();
            resultTask.Wait();
            var result = resultTask.Result;
            //var model = (List<Client>)((ViewResult)result).Model;

            //Assert
            Assert.IsType<RedirectToActionResult>(result);
            //Assert.AreEqual(2, model.Count());
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
        public void LoginActionMethod_ReturnsAIActionResult_Model()
        {
            // arrange

            // act
            var result = controller.LogIn(logModel);

            // assert
            Assert.IsType<Task<IActionResult>>(result);
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
