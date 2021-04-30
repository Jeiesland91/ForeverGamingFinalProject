using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ForeverGaming.Controllers;
using ForeverGaming.Models;
using Microsoft.EntityFrameworkCore;

namespace ForeverGamingTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var controller = TestSetUp();

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);
        }

        private HomeController _controller = null;

       
        private HomeController TestSetUp()
        {
            var options = new DbContextOptionsBuilder<GameContext>()
                .UseInMemoryDatabase(databaseName: "ForeverGaming")
                .Options;

            var rnd = new Random();
            var id = rnd.Next(10000, 11000);
            var context = new GameContext(options);
            context.Games.Add(new Game()
            {
                GameId = id,
                Name = "The Witcher",
                GenreId = "RPG",
                TypeId = "Role-Play ",
                FormatId = "PC",
                RatingId = "A",
                PublisherId = "Blizz",
                GameImage = "TheWitcher.png",
            });

            context.SaveChanges();

            _controller = new HomeController(context);
            return _controller;
        }
    }
}
