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

        public void DeleteGame(string gameName)
        {
            string connectionString = "Data Source=DESKTOP-KSQOGO2;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";

            string sqlQuery = "DELETE FROM Game WHERE name = '" + gameName + "'";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void UpdateGame(string gameName, string newGameName, string newURL, string newDescription)
        {
            string connectionString = "Data Source=DESKTOP-KSQOGO2;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";

            string sqlQuery = "UPDATE Game SET name='"+newGameName+"', url_image='"+newURL+"', description='"+newDescription+"' WHERE name='"+gameName+"'";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
