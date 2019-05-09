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
    public class GameController : ControllerBase
    {
        private readonly IGame _game; 

        public GameController(IGame game)
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

        [HttpPost("register")]
        public Task<IActionResult> RegisterPlayerInBattle([FromBody] GameRegisterPlayerRequestDto request)
        {

            Guid gladiatorId = _game.RegisterPlayerInBattle(request.BattleId, request.Gladiator);

            IActionResult test = Ok(gladiatorId);
            Task<IActionResult> test1 = Task.FromResult(test);
            return test1;
        }

        [HttpPost("action")]
        public Task<IActionResult> ChooseAction([FromBody] PlayerChooseActionRequestDto request)
        {
            _game.ChooseAction(request.PlayerId, request.Action, request.BattleId);

            IActionResult ok = Ok();
            Task<IActionResult> nothingToSend = Task.FromResult(ok);
            return nothingToSend;
        }

        [HttpPost("battle")]
        public Task<IActionResult> RunBattle([FromBody] RunningBattleRequestDto request)
        {
            bool runBattle = _game.RunBattle(request.BattleId);
            string winner = _game.FinishBattle(request.BattleId);

            if (runBattle == true) 
            {
                IActionResult finish = Ok(winner);
                Task<IActionResult> ItsOver = Task.FromResult(finish);
                return ItsOver;
            }

            IActionResult ok = Ok();
            Task<IActionResult> nothingToSend = Task.FromResult(ok);
            return nothingToSend;
        }

    }
}