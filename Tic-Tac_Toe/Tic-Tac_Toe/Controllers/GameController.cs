using Microsoft.AspNetCore.Mvc;
using Tic_Tac_Toe.Models;

namespace Tic_Tac_Toe.Controllers
{
    [ApiController]
    [Route("api/_game")]
    public class GameController : Controller
    {
       private static GameModel _game = new GameModel();

        [HttpGet("board")]
        public ActionResult GetBoard()
        {
            return Ok(new { board =  _game.Board, currentPlayer = _game.CurrentPlayer });
        }

        [HttpPost("move")]
        public IActionResult MakeMove([FromBody] MoveRequest move)
        {
            if (move.Row < 0 || move.Row >= 3 || move.Col < 0 || move.Col >= 3)
                return BadRequest("invalid moce position");

            if (_game.Board[move.Row, move.Col] != ' ')
                return BadRequest("Cell is alreadu occupied");

            _game.MakeMove(move.Row, move.Col);

            if (_game.CheckWin())
                return Ok(new { message = $"{_game.CurrentPlayer} Wins!", board = _game.Board });

            return Ok(new { board = _game.Board, currentPlayer = _game.CurrentPlayer });
        }

        [HttpPost("reset")]
        public IActionResult ResetGame()
        {
            _game = new GameModel();
            return Ok(new { message = "Game reset!", board = _game.Board, currentPlayer = _game.CurrentPlayer });
        }

        
    }

    public class MoveRequest
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}
