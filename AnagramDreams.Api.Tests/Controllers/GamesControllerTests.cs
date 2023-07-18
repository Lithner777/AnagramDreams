using AnagramDreams.Api.Controllers;
using AnagramDreams.Api.Dtos;
using AnagramDreams.DataAccess.Model;
using AnagramDreams.DataAccess.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace AnagramDreams.Api.Tests.Controllers
{
    public class GamesControllerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<IGameService> gameServiceMock = new();
        private readonly GamesController cut;

        public GamesControllerTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AnagramDreams.Api.AutoMapperProfile>();
            });

            mapper = config.CreateMapper();
            gameServiceMock.Setup(c => c.NewGame(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new DataAccess.Model.Game()
                {
                    GameWords = new List<GameWord>(),
                    GameTime = 100
                });

            cut = new GamesController(mapper, gameServiceMock.Object);
        }

        [Fact]
        public async Task NewGameReturnsOK()
        {
            var reqBody = new GameReq(){};

            var result = await cut.NewGame(reqBody);
            var okObjectResult = (OkObjectResult)result.Result!;
            var game = (GameResp)okObjectResult.Value!;
            okObjectResult.ShouldNotBeNull();
            game.GameTime.ShouldBe(100);
        }
    }
}
