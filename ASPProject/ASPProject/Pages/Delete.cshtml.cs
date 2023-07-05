using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPProject.Model;

namespace ASPProject.Pages
{
    public class DeleteModel : PageModel
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
            Game game = new Game();
            game.DeleteGame(gameName);
            GameList = game.GetAllGame();
        }
    }
}
