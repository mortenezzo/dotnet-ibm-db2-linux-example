using IBM.Data.Db2;

var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__Db2Connection");

try
{
    using (var conn = new DB2Connection(connectionString))
    {
        conn.Open();
        Console.WriteLine("¡Conexión exitosa a Db2!");

        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT 'Hola desde Db2' FROM SYSIBM.SYSDUMMY1";
        var result = cmd.ExecuteScalar();
        Console.WriteLine(result);
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}

Console.WriteLine("Presiona Ctrl+C para salir...");
AutoResetEvent waitHandle = new(false);
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    waitHandle.Set();
};
waitHandle.WaitOne();