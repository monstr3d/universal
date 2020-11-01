using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor.Drawing
{
    public class DrawableConverter : IMathSymbolConverter
    {

        private static IMathSymbolConverter converter;

        public static readonly DrawableConverter Object = new DrawableConverter();

        public static readonly string Drawable = "Drawable";


        public static readonly string Serializable = "Serializable";

        static IMathSymbolConverter Converter
        {
            get
            {
                return converter;
            }
            set
            {
                converter = value;
            }
        }
            

        private DrawableConverter()
        {
        }

        #region IMathSymbolConverter Members

        public MathSymbol Convert(MathSymbol symbol)
        {
            Type t = symbol.GetType();
            string type = t.ToString();
            if (type.Contains(Serializable))
            {
                type = type.Substring(0, type.Length - Serializable.Length);
            }
            if (type.Length > Drawable.Length)
            {
                if (type.Substring(type.Length - Drawable.Length).Equals(Drawable))
                {
                    type = type.Substring(0, type.Length - Drawable.Length);
                }
            }
            if (type.Contains("FormulaEditor.Symbols."))
            {
                type = type.Substring("FormulaEditor.Symbols.".Length);
            }
            string typeDrawable = "FormulaEditor.Drawing.Symbols." + type + Drawable;
            typeDrawable = typeDrawable.Replace(".FormulaEditor.", ".");
            Type tDrawable = Type.GetType(typeDrawable);
            System.Reflection.ConstructorInfo c = tDrawable.GetConstructor(new Type[] { t });
            MathSymbol sym = c.Invoke(new object[] { symbol }) as MathSymbol;
            return sym;
        }

        #endregion
    }
}
