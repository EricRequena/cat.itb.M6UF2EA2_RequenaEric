using Npgsql;

namespace UF2_test;

public class CloudConnection
{
    private String HOST = "drona.db.elephantsql.com:5432"; // Ubicació de la BD.
    private String DB = "zjvzmnhq"; // Nom de la BD.
    private String USER = "zjvzmnhq";
    private String PASSWORD = "q5ejWKvEa4evwsbA9PKPV7Q0JB7_uYsw";

    // Specify connection options and open an connection
    public NpgsqlConnection conn = null;

    /**
     * Mètode per connectar a la base de dades school
     */
    public NpgsqlConnection GetConnection()
    {
        NpgsqlConnection conn = new NpgsqlConnection(
            "Host=" + HOST + ";" + "Username=" + USER + ";" +
            "Password=" + PASSWORD + ";" + "Database=" + DB + ";"
        );
        conn.Open();
        return conn;
    }
}