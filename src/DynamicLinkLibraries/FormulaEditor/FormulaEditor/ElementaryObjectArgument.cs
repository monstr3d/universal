using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace FormulaEditor
{
    /// <summary>
    /// Argument of real function
    /// </summary>
    public class ElementaryObjectArgument
    {
        /// <summary>
        /// Table of variables
        /// </summary>
        private Dictionary<object, List<object>> table = new Dictionary<object, List<object>>();

        /// <summary>
        /// Constructor
        /// </summary>
        public ElementaryObjectArgument()
        {
        }

        /// <summary>
        /// Adds tree
        /// </summary>
        /// <param name="tree">Tree to add</param>
        public void Add(ObjectFormulaTree tree)
        {
         /*   if (tree.Operation is ElementaryRealVariable)
            {
                ElementaryRealVariable v = tree.Operation as ElementaryRealVariable;
                ArrayList l = null;
                object s = v.Symbol;
                if (table.ContainsKey(s))
                {
                    l = table[s] as ArrayList;
                }
                else
                {
                    l = new ArrayList();
                    table[s] = l;
                }
                l.Add(v);
            }*/
            if (tree.Operation is ElementaryObjectVariable)
            {
                ElementaryObjectVariable v = tree.Operation as ElementaryObjectVariable;
                List<object> l = null;
                object s = v.Symbol;
                if (table.ContainsKey(s))
                {
                    l = table[s];
                }
                else
                {
                    l = new List<object>();
                    table[s] = l;
                }
                l.Add(v);
            }
            for (int i = 0; i < tree.Count; i++)
            {
                Add(tree[i]);
            }
        }

        /// <summary>
        /// Clears itself
        /// </summary>
        public void Clear()
        {
            table.Clear();
        }

        /// <summary>
        /// Adds trees
        /// </summary>
        /// <param name="trees">Trees to add</param>
        public void Add(ObjectFormulaTree[] trees)
        {
            foreach (ObjectFormulaTree tree in trees)
            {
                Add(tree);
            }
        }

        /// <summary>
        /// Access to value
        /// </summary>
        public object this[object s]
        {
            set
            {
                if (!table.ContainsKey(s))
                {
                    return;
                    //throw new Exception("Variable does not exist");
                }
                List<object> l = table[s] as List<object>;
                foreach (object x in l)
                {
                    if (x is ElementaryObjectVariable)
                    {
                        ElementaryObjectVariable o = x as ElementaryObjectVariable;
                        o.Value = value;
                        if (value.IsDBNull())
                        {
                            o.Value = null;
                        }
                        continue;
                    }
   /*                 if (x is ElementaryRealVariable &
                        !value.GetType().FullName.Equals("System.Double"))
                    {
                        goto replace;
                    }
                    {
                        ElementaryRealVariable r = x as ElementaryRealVariable;
                        if (value == null | value is DBNull)
                        {
                            r.Value = null;
                            continue;
                        }
                        r.Value = (double)value;
                        continue;
                    }
                    return;
                replace:
                    char c = (char)s;
                    for (int i = 0; i < c; i++)
                    {
                        ElementaryObjectVariable v = new ElementaryObjectVariable(c);
                        v.Value = value;
                        l[i] = v;
                    }*/
                }
            }
        }

        /// <summary>
        /// Checks whether argument contains symbol
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>True if argument contains symbol and false otherwise</returns>
        public bool Contains(object s)
        {
            return table.ContainsKey(s);
        }

        /// <summary>
        /// Variables
        /// </summary>
        public string Variables
        {
            get
            {
                string s = "";
                foreach (object o in table.Keys)
                {
                    if (o is Char)
                    {
                        char c = (char)o;
                        s += c;
                    }
                }
                return s;
            }
        }

    }
}
