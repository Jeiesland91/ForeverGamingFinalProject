using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ForeverGaming.Controllers;
using ForeverGaming.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ForeverGamingTests
{
    public class GameControllerTests
    {
        [Fact]
        public void DetailsActionMethod_ReturnsAViewResult()
        {
            // arrange
            var controller = TestSetUp();

            // act
            var result = controller.Details(_id);

            // assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void PageSizeActionMethod_ReturnsAViewResult()
        {
            // arrange
            var controller = TestSetUp();

            // act
            var result = controller.PageSize(2);

            // assert
            Assert.IsType<ViewResult>(result);
        }


        private GameController _controller = null;
        private int _id = 0;


        private GameController TestSetUp()
        {
            var options = new DbContextOptionsBuilder<GameContext>()
                .UseInMemoryDatabase(databaseName: "ForeverGaming")
                .Options;

            var rnd = new Random();
            _id = rnd.Next(10000, 11000);
            var context = new GameContext(options);
      
            context.Games.Add(new Game()
            {
                GameId = _id,
                Name = "The Witcher",
                GenreId = "RPG",
                TypeId = "Role-Play ",
                FormatId = "PC",
                RatingId = "A",
                PublisherId = "Blizz",
                GameImage = "TheWitcher.png",
            });
           
            context.SaveChanges();

            var httpcontext = new Mock<HttpContext>();
            var session = new TestSession();

            httpcontext.Setup(Session => session);
            _controller = new GameController(context);

            return _controller;
        }
    }

    public class TestSession : ISession
    {

        public TestSession()
        {
            Values = new Dictionary<string, byte[]>();
        }

        public string Id
        {
            get
            {
                return "session_id";
            }
        }

        public bool IsAvailable
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<string> Keys
        {
            get { return Values.Keys; }
        }

        public Dictionary<string, byte[]> Values { get; set; }

        public void Clear()
        {
            Values.Clear();
        }

        public Task CommitAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            Values.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            if (Values.ContainsKey(key))
            {
                Remove(key);
            }
            Values.Add(key, value);
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            if (Values.ContainsKey(key))
            {
                value = Values[key];
                return true;
            }
            value = new byte[0];
            return false;
        }
    }
}
