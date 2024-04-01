using Npgsql;
using UF2_test.model;

namespace UF2_test.cruds;

public class AsignaturasCRUD
{
    static NpgsqlConnection conn;

    public void InsertarNuevosProductos()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "INSERT INTO productos(prod_num, descripcion) VALUES(@prodNum, @descripcion)";

        using var cmd = new NpgsqlCommand(sql, conn);

        // Primer nuevo producto
        cmd.Parameters.AddWithValue("prodNum", 300388);
        cmd.Parameters.AddWithValue("descripcion", "RH GUIDE TO PADDLE");
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        // Segundo nuevo producto
        cmd.Parameters.Clear(); // Limpiar los parámetros para reutilizar el comando
        cmd.Parameters.AddWithValue("prodNum", 400552);
        cmd.Parameters.AddWithValue("descripcion", "RH GUIDE TO BOX");
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        // Tercer nuevo producto
        cmd.Parameters.Clear(); // Limpiar los parámetros para reutilizar el comando
        cmd.Parameters.AddWithValue("prodNum", 400333);
        cmd.Parameters.AddWithValue("descripcion", "ACE TENNIS BALLS-10 PACK");
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Nuevos productos insertados");

        // Cerrar conexión
        conn.Close();
    }

    public void InsertarNuevosEmpleados()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "INSERT INTO empleados(emp_no, cognom, ofici, cap, data_alta, salari, comissio, dept_no) " +
                  "VALUES(@empNo, @cognom, @ofici, @cap, @dataAlta, @salari, @comissio, @deptNo)";

        using var cmd = new NpgsqlCommand(sql, conn);

        // Primer nuevo empleado
        cmd.Parameters.AddWithValue("empNo", 4885);
        cmd.Parameters.AddWithValue("cognom", "BORREL");
        cmd.Parameters.AddWithValue("ofici", "EMPLEAT");
        cmd.Parameters.AddWithValue("cap", 7902);
        cmd.Parameters.AddWithValue("dataAlta", new DateTime(1981, 12, 25));
        cmd.Parameters.AddWithValue("salari", 104000);
        cmd.Parameters.AddWithValue("comissio", DBNull.Value); // Si es NULL se usa DBNull.Value
        cmd.Parameters.AddWithValue("deptNo", 30);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        // Segundo nuevo empleado
        cmd.Parameters.Clear(); // Limpiar los parámetros para reutilizar el comando
        cmd.Parameters.AddWithValue("empNo", 8772);
        cmd.Parameters.AddWithValue("cognom", "PUIG");
        cmd.Parameters.AddWithValue("ofici", "VENEDOR");
        cmd.Parameters.AddWithValue("cap", 7698);
        cmd.Parameters.AddWithValue("dataAlta", new DateTime(1990, 1, 23));
        cmd.Parameters.AddWithValue("salari", 108000);
        cmd.Parameters.AddWithValue("comissio", DBNull.Value); // Si es NULL se usa DBNull.Value
        cmd.Parameters.AddWithValue("deptNo", 30);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        // Tercer nuevo empleado
        cmd.Parameters.Clear(); // Limpiar los parámetros para reutilizar el comando
        cmd.Parameters.AddWithValue("empNo", 9945);
        cmd.Parameters.AddWithValue("cognom", "FERRER");
        cmd.Parameters.AddWithValue("ofici", "ANALISTA");
        cmd.Parameters.AddWithValue("cap", 7698);
        cmd.Parameters.AddWithValue("dataAlta", new DateTime(1988, 5, 17));
        cmd.Parameters.AddWithValue("salari", 169000);
        cmd.Parameters.AddWithValue("comissio", 39000);
        cmd.Parameters.AddWithValue("deptNo", 20);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Nuevos empleados insertados");

        // Cerrar conexión
        conn.Close();
    }

    public void ActualizarLimitCredit()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "UPDATE clients SET limit_credit = @limitCredit WHERE client_cod = @clientCod";

        using var cmd = new NpgsqlCommand(sql, conn);

        // Primer cliente
        cmd.Parameters.AddWithValue("limitCredit", 20000);
        cmd.Parameters.AddWithValue("clientCod", 104);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        // Segundo cliente
        cmd.Parameters.Clear(); // Limpiar los parámetros para reutilizar el comando
        cmd.Parameters.AddWithValue("limitCredit", 12000);
        cmd.Parameters.AddWithValue("clientCod", 106);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        // Tercer cliente
        cmd.Parameters.Clear(); // Limpiar los parámetros para reutilizar el comando
        cmd.Parameters.AddWithValue("limitCredit", 20000);
        cmd.Parameters.AddWithValue("clientCod", 107);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Límites de crédito actualizados");

        // Cerrar conexión
        conn.Close();
    }

    public void MostrarDatosCliente106()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "SELECT * FROM clients WHERE client_cod = @clientCod";

        using var cmd = new NpgsqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("clientCod", 106);
        cmd.Prepare();

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("Client cod: {0}", reader.GetInt32(0));
            Console.WriteLine("Client nom: {0}", reader.GetString(1));
            Console.WriteLine("Client ciutat: {0}", reader.GetString(2));
            Console.WriteLine("Client limit_credit: {0}", reader.GetInt32(3));
        }

        // Cerrar conexión
        conn.Close();
    }

    public void EliminarCliente109()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "DELETE FROM clients WHERE client_cod = @clientCod";

        using var cmd = new NpgsqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("clientCod", 109);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Cliente eliminado");

        // Cerrar conexión
        conn.Close();
    }

    public void EliminarEmpleado4885()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "DELETE FROM empleados WHERE emp_no = @empNo";

        using var cmd = new NpgsqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("empNo", 4885);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Empleado eliminado");

        // Cerrar conexión
        conn.Close();
    }

    public void EliminarProducto400552()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "DELETE FROM productos WHERE prod_num = @prodNum";

        using var cmd = new NpgsqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("prodNum", 400552);
        cmd.Prepare();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Producto eliminado");

        // Cerrar conexión
        conn.Close();
    }

    public void MostrarEmpleados()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "SELECT cognom, salari FROM empleados";

        using var cmd = new NpgsqlCommand(sql, conn);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("Cognom: {0}", reader.GetString(0));
            Console.WriteLine("Salari: {0}", reader.GetInt32(1));
        }

        // Cerrar conexión
        conn.Close();
    }

    public void MostrarDatosEmpleado7788()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "SELECT * FROM empleados WHERE emp_no = @empNo";

        using var cmd = new NpgsqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("empNo", 7788);
        cmd.Prepare();

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("Emp no: {0}", reader.GetInt32(0));
            Console.WriteLine("Cognom: {0}", reader.GetString(1));
            Console.WriteLine("Ofici: {0}", reader.GetString(2));
            Console.WriteLine("Cap: {0}", reader.GetInt32(3));
            Console.WriteLine("Data alta: {0}", reader.GetDateTime(4));
            Console.WriteLine("Salari: {0}", reader.GetInt32(5));
            Console.WriteLine("Comissio: {0}", reader.GetValue(6));
            Console.WriteLine("Dept no: {0}", reader.GetInt32(7));
        }

        // Cerrar conexión
        conn.Close();
    }

    public void MostrarDatosProducto101860()
    {
        CloudConnection db = new CloudConnection();
        var conn = db.GetConnection();

        var sql = "SELECT * FROM productos WHERE prod_num = @prodNum";

        using var cmd = new NpgsqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("prodNum", 101860);
        cmd.Prepare();

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("Prod num: {0}", reader.GetInt32(0));
            Console.WriteLine("Descripción: {0}", reader.GetString(1));
        }

        // Cerrar conexión
        conn.Close();
    }
}