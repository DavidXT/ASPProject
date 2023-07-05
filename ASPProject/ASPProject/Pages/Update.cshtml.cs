using ASPProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPProject.Pages
{
    public class UpdateModel : PageModel
    {
        public List<Game> GameList = new List<Game>();
        public void OnGet()
        {
            Game game = new Game();
            GameList = game.GetAllGame();
        }

        public void OnPost()
        {
            string gameName = Request.Form["GameNameSelected"];
            string newGameName = Request.Form["GameName"];
            string newUrl = Request.Form["URL"];
            string newDescription = Request.Form["Description"];

            Game game = new Game();
            game.UpdateGame(gameName,newGameName,newUrl,newDescription);
            GameList = game.GetAllGame();
        }
    }
}
