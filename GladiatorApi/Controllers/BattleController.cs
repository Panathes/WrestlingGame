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

        [HttpPost("{id}/register")]
        public Task<IActionResult> RegisterPlayerInBattle(Guid id, [FromBody] GameRegisterPlayerRequestDto request)
        {

            Guid gladiatorId = _game.RegisterPlayerInBattle(id, request.Gladiator);

            IActionResult test = Ok(gladiatorId);
            Task<IActionResult> test1 = Task.FromResult(test);
            return test1;
        }

        [HttpPost("{id}/action")]
        public Task<IActionResult> ChooseAction(Guid id, [FromBody] PlayerChooseActionRequestDto request)
        {
            _game.ChooseAction(request.PlayerId, request.Action, id);

            IActionResult ok = Ok();
            Task<IActionResult> nothingToSend = Task.FromResult(ok);
            return nothingToSend;
        }

        [HttpPost("{id}/fight")]
        public Task<IActionResult> RunBattle(Guid id)
        {
            bool runBattle = _game.RunBattle(id);
            string winner = _game.FinishBattle(id);

            if (runBattle) 
            {
                IActionResult finish = Ok(winner);
                Task<IActionResult> itsOver = Task.FromResult(finish);
                return itsOver;
            }

            IActionResult ok = Ok();
            Task<IActionResult> nothingToSend = Task.FromResult(ok);
            return nothingToSend;
        }

    }
}