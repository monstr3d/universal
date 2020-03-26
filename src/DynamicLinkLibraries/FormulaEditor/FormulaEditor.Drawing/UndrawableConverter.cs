using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor.Drawing
{
    public class UndrawableConverter : IMathSymbolConverter
    {
        public static readonly UndrawableConverter Object = new UndrawableConverter();

        public static readonly string Drawable = "Drawable";



        private UndrawableConverter()
        {
        }

        #region IMathSymbolConverter Members

        public MathSymbol Convert(MathSymbol symbol)
        {
            Type t = symbol.GetType();
            string type = t.ToString();
            if (type.Length > Drawable.Length)
            {
                if (type.Substring(type.Length - Drawable.Length).Equals(Drawable))
                {
                    type = type.Substring(0, type.Length - Drawable.Length);
                }
            }
            type = type.Replace("Drawing.Symbols.", "Symbols.");
            string ass = typeof(MathFormula).Assembly.FullName;
            Type ty = Type.GetType(String.Format("{0}, {1}", type, ass));
            System.Reflection.ConstructorInfo c = ty.GetConstructor(new Type[] { ty });
            MathSymbol sym = c.Invoke(new object[] { symbol }) as MathSymbol;
            return sym;
        }

        #endregion
    }
}
