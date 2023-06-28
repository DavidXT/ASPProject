using Microsoft.Data.SqlClient;

namespace ASPProject.Model
{
    public class Game
    {
        public string GameName;
        public string Description;
        public string Url_image;
        public List<Game> GetAllGame()
        {
            string connectionString = "Data Source=DESKTOP-KSQOGO2;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string sqlQuery = "SELECT * FROM Game";

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<Game> GameList = new List<Game>(); 
            while (reader.Read())
            {
                Game game = new Game();

                game.GameName = reader["name"].ToString();
                game.Description = reader["description"].ToString();
                game.Url_image = reader["url_image"].ToString();
                GameList.Add(game);
            }

            connection.Close();
            return GameList;
        }
    }
}
