// See https://aka.ms/new-console-template for more information

using DataWarehouse.Classes;
using DataWarehouse.Interfaces;

var c = new DatabaseCoordinatorCollection(false);

IDatabaseCoordinator coord = c;

c.LoadDirectory();

var from = coord[@"Data Source=IVANKOV\SQLEXPRESS;Initial Catalog=AstronomyExpress;Integrated Security=True;Encrypt=False"];
var to = coord["Host=127.0.0.1;Database=PostgreSQL_Warehouse;Username=postgres;Password=GREM0nP0"];
var p = new DataWarehouse.Performer();

p.Copy(from, to);

//var from = new SQLServerWarehouse.DataWarehouseContext()