// See https://aka.ms/new-console-template for more information
using DataWarehouse;
using DataWarehouse.Classes;
using DataWarehouse.Interfaces;
using PostgreSQLWarehouse;
using PostgreSQLWarehouse.Models;
//BA(); Console.WriteLine("Finish"); return;
//var t = CopyToDatabse1();



var t = CopyToFile();
await t;
Task.WaitAll(t.Result);
Console.WriteLine("Press key");
Console.ReadLine();
return;

PostgreSQLConsoleApp.A.TestA();

//var k = Test3();

/*
 DELETE FROM public."BinaryTree"
 WHERE "Id" <> "ParentId";
*/
return;

async Task EntityDebug()
{
    var x = new DataWarehouse.SQLServer.EntityFramework.DataWarehouse();
}

async Task<List<Task>> CopyToDatabse()
{
    var tasks = new List<Task>();

    try
    {
        var ct = new CancellationToken();
        var p = new Performer();
        var cs = "Host=127.0.0.1;Database=BusinessAnalisys;Username=postgres;Password=GREM0nP0";
        var ext = ".cfa";
        var extp = ".business_analisys";
        var dir = @"c:\0\dir1";
        var t = p.Copy(cs, dir, ext, extp, tasks, ct);
        await t;
        tasks.Add(t);
    }
    catch (Exception e)
    {

    }
    return tasks;

}



async Task<List<Task>> CopyToDatabse1()
{
    var tasks = new List<Task>();

    try
    {
        var ct = new CancellationToken();
        var p = new Performer();
        var cs = "Host=127.0.0.1;Database=BusinessAnalisys;Username=postgres;Password=GREM0nP0";
        var ext = ".cft";
        var extp = ".business_analisys";
        var dir = @"c:\0\dir";
        var t = p.Copy(cs, dir, ext, extp, tasks, ct);
        await t;
        tasks.Add(t);
    }
    catch (Exception e)
    {

    }
    return tasks;

}

void BA()
{
    var connection = "Host=127.0.0.1;Database=BusinessAnalisys;Username=postgres;Password=GREM0nP0";
    var c = new PostgreSQLWarehouseInterface(connection);
    c.CreateRootsPublic();
}

    async Task<List<Task>> CopyToFile()
{
    var tasks = new List<Task>();
    try
    {
        var ct = new CancellationToken();
        var p = new Performer();
        var cs = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Trading_Analytics;Integrated Security=True;Encrypt=False";
        var dir = @"c:\0\dir";
        var ext = ".cft";
        var t = p.Copy(cs, dir, ext, tasks, ct);
        await t;
        tasks.Add(t);

    }
    catch (Exception e)
    {

    }
    return tasks;
}

    async Task<List<Task>> CopyToFile1()
    {
        var tasks = new List<Task>();
        try
        {
        var ct = new CancellationToken();
        var p = new Performer();
            var cs = "Host=127.0.0.1;Database=PostgreSQL_Warehouse;Username=postgres;Password=GREM0nP0";
            var dir = @"c:\0\dir1";
            var ext = ".cfa";
            var t = p.Copy(cs, dir, ext, tasks, ct);
            await t;
            tasks.Add(t);

        }
        catch (Exception e)
        {

        }
        return tasks;
    }

    void Test()
    {
        var c = new DatabaseCoordinatorCollection(false);

        IDatabaseCoordinator coord = c;

        c.LoadDirectory();

        var from = coord[@"Data Source=IVANKOV\SQLEXPRESS;Initial Catalog=AstronomyExpress;Integrated Security=True;Encrypt=False"];
        var to = coord["Host=127.0.0.1;Database=PostgreSQL_Warehouse;Username=postgres;Password=GREM0nP0"];
        //var to = coord["Dsn=MySQL"];
        var p = new DataWarehouse.Performer();

        p.Copy(from, to);
    }


int Test3()
    {
        var cs = "Server=localhost;User ID=root;Password=SQj0Myhnks!12;Database=mysqlwarehouse";
        using var conn = new MySqlConnector.MySqlConnection(cs);
        conn.Open();
        using var command = conn.CreateCommand();
        command.CommandType = System.Data.CommandType.StoredProcedure;
        //command.CommandText = "fiction";
        command.CommandText = $"`mysqlwarehouse`.`fiction`";
        var ll = command.ExecuteNonQuery();
        return ll;
    }




async Task<int> Test1()
{
 var cs = "Server=localhost;User ID=root;Password=SQj0Myhnks!12;Database=mysqlwarehouse";
 using var conn = new MySqlConnector.MySqlConnection(cs);
 conn.Open();
 using var command = conn.CreateCommand();
 command.CommandType = System.Data.CommandType.StoredProcedure;
 //command.CommandText = "fiction";
 command.CommandText = $"`mysqlwarehouse`.`fiction`";
 var ll = command.ExecuteNonQueryAsync();
 await ll;
 return ll.Result;
}


void Test2()
{

 var adapter = new PostgreSqlWarehouseContext();

 var tables = adapter.BinaryTrees.ToArray();

 int i = 0;
}

void Test4()
{

 var adapter = new PostgreSqlWarehouseContext();

 var tables = adapter.BinaryTrees.ToArray();

 int i = 0;
}
