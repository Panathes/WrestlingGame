using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GladiatorApi.Dto;
using GladiatorLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GladiatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattleController : ControllerBase
    {
        private readonly IGame _game;

        public BattleController(IGame game)
        {
            _game = game;
        }

        [HttpPost]
        public Task<IActionResult> Create()
        {
            Guid battleId = _game.StartBattle();

            IActionResult ret = Ok(battleId);
            Task<IActionResult> test = Task.FromResult(ret);
            return test;

        }

        [HttpGet("list")]
        public IActionResult ListBattle()
        {
            List<Guid> battleList = _game.ListBattle();
            return Ok(battleList);
        }

        [HttpPost("{id}/register")]
        public Task<IActionResult> RegisterPlayerInBattle(Guid id, [FromBody] GameRegisterPlayerRequestDto request)
        {

            Guid gladiatorId = _game.RegisterPlayerInBattle(id, request.GladiatorName);

            IActionResult test = Ok(gladiatorId);
            Task<IActionResult> test1 = Task.FromResult(test);
            return test1;
        }

        [HttpPost("{id}/action")]
        public IActionResult ChooseAction(Guid id, [FromBody] PlayerChooseActionRequestDto request)
        {
            try
            {
                _game.ChooseAction(request.PlayerId, request.Action, id);
            }
            catch (PlayerFightLowStaminaException e)
            {
                return BadRequest(new { HasError = true, Message = "Not enough stamina." });
            }

            return Ok();
        }

        [HttpGet("{id}/playerlist")]
        public IActionResult ShowPlayerInBattle(Guid id)
        {

            List<Gladiator> playerNumber = _game.ShowPlayerInBattle(id);
            List<GladiatorDto> response = new List<GladiatorDto>();

            for (int i = 0; i < playerNumber.Count; i++)
            {
                var toto = new GladiatorDto();
                toto.Name = playerNumber[i].Name;
                toto.Pv = playerNumber[i].Pv;
                toto.Stamina = playerNumber[i].Stamina;
                toto.GladiatorId = playerNumber[i].GladiatorId;
                response.Add(toto);
            }

            return Ok(response);
            //            return Ok(playerNumber);
        }

        [HttpPost("{id}/fight")]
        public IActionResult RunBattle(Guid id)
        {

                bool isBattleFinish = _game.RunBattle(id);

                List<Gladiator> players = _game.ShowPlayerInBattle(id);
                List<PlayerInfoDto> playerInfoDtos = new List<PlayerInfoDto>();
                GameInfoDto gameInfoDto = new GameInfoDto();


                foreach (var player in players)
                {
                    var playerInfoDto = new PlayerInfoDto
                    {
                        Name = player.Name,
                        Pv = player.Pv,
                        Stamina = player.Stamina,
                        PlayerId = player.GladiatorId
                    };
                    playerInfoDtos.Add(playerInfoDto);
                }

                gameInfoDto.Gladiators = playerInfoDtos;
                gameInfoDto.IsBattleFinish = isBattleFinish;

                if (isBattleFinish)
                {
                    gameInfoDto.GladiatorId = players.Single(s => s.Pv > 0).GladiatorId;
                }
                return Ok(gameInfoDto);

        }

        [HttpGet("{id}/winner")]
        public IActionResult GetWinner(Guid id)
        {
            Gladiator playerWinner = _game.ShowPlayerWinner(id);
            PlayerInfoDto playerInfoDto = new PlayerInfoDto
            {
                PlayerId = playerWinner.GladiatorId,
                Name = playerWinner.Name,
                Pv = playerWinner.Pv,
                Stamina = playerWinner.Stamina
            };
            return Ok(playerInfoDto);
        }
    }
}

//                foreach (var player in playerNumber.Where(i => i.Pv > 0 && playerNumber.Count == 1))
//                {
//                    response.Clear();
//                    player.Name = playerNumber[i].Name;
//                    player.Pv = playerNumber[i].Pv;
//                    player.Stamina = playerNumber[i].Stamina;
//                    player.PlayerId = playerNumber[i].GladiatorId;
//                    response.Add(player);
//                }