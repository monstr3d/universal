using System;
using System.Collections.Generic;
using System.Reflection;

using AssemblyService;
using DataWarehouse.Interfaces;
using ErrorHandler;


namespace DataWarehouse.Classes
{
    /// <summary>
    /// Collection of coordinators
    /// </summary>
    public class DatabaseCoordinatorCollection : IDatabaseCoordinator
    {
        List<IDatabaseCoordinator> coordinators = new List<IDatabaseCoordinator>();

        static Dictionary<string, Assembly> assemblyDictionary = new();


        protected virtual IDatabaseInterface Get(string name)
        {
            foreach (var coordinator in coordinators)
            {
                var inter = coordinator[name];
                if (inter != null)
                {
                    return inter;
                }
            }
            return null;
        }

        IDatabaseInterface IDatabaseCoordinator.this[string name] => Get(name);

        bool IDatabaseCoordinator.Create(string name)
        {
            throw new OwnNotImplemented();
        }


        public void Add(IDatabaseCoordinator coordinator)
        {
            coordinators.Add(coordinator);
        }

        void  Add(Assembly assembly, DatabaseCoordinatorCollection coordinatorCollection)
        {
            var loc = assembly.Location;
            if (assemblyDictionary.ContainsKey(loc))
            {
                return;
            }
            assemblyDictionary[loc] = assembly;
            var types = assembly.GetTypes();
            foreach (var type in types)
            {

            }

        }

        static public  IDatabaseCoordinator FromAssembly
        {
            get
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory;
                var inter = dir.GetInterfaces<IDatabaseCoordinator>();
                var coordinator = new DatabaseCoordinatorCollection();
                var assemblies =  AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    try
                    {
                        assemblyDictionary[assembly.Location] = assembly;
                        var types = assembly.GetTypes();
                    }
                    catch (Exception ex)
                    {

                    }
                }

                return coordinator;
            }

        }


    }
}
