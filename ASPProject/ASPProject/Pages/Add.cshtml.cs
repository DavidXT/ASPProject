using ASPProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ASPProject.Pages
{
    public class AddModel : PageModel
    {
        public void OnPost()
        {
            string gamename = Request.Form["GameName"];
            string gameURL = Request.Form["URL"];
            string gameDescription = Request.Form["Description"];

            string connectionString = StaticVar.ServerName + ";Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";

            string sqlQuery = "INSERT INTO Game (name,url_image,description) VALUES ('" + gamename + "','" + gameURL + "','" + gameDescription + "')";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
