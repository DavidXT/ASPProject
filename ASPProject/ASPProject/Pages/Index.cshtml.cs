using ASPProject.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPProject.Pages
{
    public class IndexModel : PageModel
    {
        public List<Game> GameList = new List<Game>();
        public List<String> GameTypeList = new List<String>();
        public string CurrentType;
        public void OnGet()
        {
            Game game = new Game();
            GameList = game.GetAllGame();
            GameTypeList = game.GetAllGameType();
        }

        public void OnPost()
        {
            string gameType = Request.Form["GameTypeSelected"];
            CurrentType = gameType;
            Game game = new Game();
            if (gameType == "0")
            {
                GameList = game.GetAllGame();
            }
            else
            {
                GameList = game.GetGameFromType(gameType);
            }
            GameTypeList = game.GetAllGameType();
        }
    }
}