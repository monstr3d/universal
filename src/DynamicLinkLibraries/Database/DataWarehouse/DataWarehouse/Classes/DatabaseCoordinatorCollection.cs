using System;
using System.Collections.Generic;
using System.Reflection;

using DataWarehouse.Interfaces;
using ErrorHandler;



namespace DataWarehouse.Classes
{
    /// <summary>
    /// Collection of coordinators
    /// </summary>
    public class DatabaseCoordinatorCollection : IDatabaseCoordinator
    {
        public DatabaseCoordinatorCollection(bool fiction)
        {

        }


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

        public void LoadDirectory()
        {
            var ass = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in ass)
            {
                if (assembly != GetType().Assembly)
                {
                    Add(assembly);
                }
                else
                {

                }
            }
            string[] fn =  System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var lt = new List<string>();
            foreach (var file in fn)
            {
                if (assemblyDictionary.ContainsKey(file))
                {
                    continue;
                }
                try
                {
                    var assembly = Assembly.LoadFrom(file);
                    Add(assembly);
                }
                catch
                {
                    continue;
                }
                
            }

        }

        void  Add(Assembly assembly)
        {
            var loc = assembly.Location;
            if (assemblyDictionary.ContainsKey(loc))
            {
                return;
            }
            assemblyDictionary[loc] = assembly;
            try
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    var tt = new List<Type>(type.GetInterfaces());
                    if (!tt.Contains(typeof(IDatabaseCoordinator)))
                    {
                        continue;
                    }
                    var constr = type.GetConstructor([]);
                    if (constr != null)
                    {
                        var intt = constr.Invoke([]) as IDatabaseCoordinator;
                        Add(intt);
                    }
                }
            }
            catch
            {

            }
        }



    }
}
