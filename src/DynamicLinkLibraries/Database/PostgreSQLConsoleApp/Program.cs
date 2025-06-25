// See https://aka.ms/new-console-template for more information
using PosgreSQLWarehouse.Models;


var adapter = new PostgreSqlWarehouseContext();

var tables = adapter.BinaryTrees.ToArray();

int i = 0;
