using ASPProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPProject.Pages
{
    public class UpdateModel : PageModel
    {
        public List<Game> GameList = new List<Game>();
        public List<String> GameTypeList = new List<String>();

        public void OnGet()
        {
            Game game = new Game();
            GameList = game.GetAllGame();
            GameTypeList = game.GetAllGameType();
        }

        public void OnPost()
        {
            string gameName = Request.Form["GameNameSelected"];
            string newGameName = Request.Form["GameName"];
            string newGameType = Request.Form["GameTypeSelected"];
            string newUrl = Request.Form["URL"];
            string newDescription = Request.Form["Description"];

            Game game = new Game();
            game.UpdateGame(gameName,newGameName,newUrl,newDescription, newGameType);
            GameList = game.GetAllGame();
        }
    }
}
