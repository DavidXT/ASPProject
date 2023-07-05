using ASPProject.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPProject.Pages
{
    public class IndexModel : PageModel
    {
        public List<Game> GameList = new List<Game>();
        public void OnGet()
        {
            Game game = new Game();
            GameList = game.GetAllGame();
        }
    }
}