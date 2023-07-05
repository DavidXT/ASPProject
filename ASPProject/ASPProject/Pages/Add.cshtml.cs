using ASPProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASPProject.Pages
{
    public class AddModel : PageModel
    {
        public List<String> GameTypeList = new List<String>();
        public void OnGet()
        {
            Game game = new Game();
            GameTypeList = game.GetAllGameType();
        }
        public void OnPost()
        {
            string gamename = Request.Form["GameName"];
            string gameURL = Request.Form["URL"];
            string gameDescription = Request.Form["Description"];
            string gameType = Request.Form["GameTypeSelected"];

            string connectionString = StaticVar.ServerName + ";Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";

            string sqlQuery = "INSERT INTO Game (name,url_image,description,GameType) VALUES ('" + gamename + "','" + gameURL + "','" + gameDescription + "','"+ gameType + "')";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
