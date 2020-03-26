using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Security.Permissions;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{

    public class StandardSaver : IFormulaSaver
    {
        /// <summary>
        /// Formatter
        /// </summary>
        static private readonly BinaryFormatter formatter = new BinaryFormatter();



        static public readonly IFormulaSaver Saver = new StandardSaver();

        private IFormulaSaver saver = new XmlFormulaSaver(new StandardXmlSymbolCreator());

        private StandardSaver()
        {
            formatter.Binder = VersionBinderFormula.Binder;
        }


        MathFormula Deserialize(string str)
        {
            byte[] b = new byte[str.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)(str[i]);
            }
            System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
            MathFormula form = formatter.Deserialize(stream) as MathFormula;
            form.Post();
            return form;

        }

        #region IFormulaSaver Members

        MathFormula IFormulaSaver.Load(string str)
        {
            MathFormula f = null;
            try
            {
                //string[] s = str.Split(byteSep);
                byte[] b = new byte[str.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = (byte)(str[i]);
                }
                
                System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
                MathFormula form = formatter.Deserialize(stream) as MathFormula;
                form.Post();
                return form;
            }
            catch (Exception eee)
            {
                string sm = eee.StackTrace;
                sm = null;
              //  throw eee;
            }
            try
            {
                return saver.Load(str);
            }
            catch (Exception ex)
            {
            }
            try
            {

                f = new MathFormula(0, MathSymbolFactory.Sizes, str, 0, str.Length,
                    ElementaryFormulaStringConverter.Object);
                ObjectFormulaTree.CreateTree(f.FullTransform(null));
                return f;
            }
            catch (Exception)
            {
                List<byte[]> list = new List<byte[]>();
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    byte[] b = new byte[] { (byte)c };
                    list.Add(b);
                }
                try
                {
                    MathFormula fo = new MathFormula(0, MathSymbolFactory.Sizes, list, 0, str.Length);
                    //new ObjectFormulaTree(fo.FullTransform);
                    return fo;
                }
                catch (Exception)
                {
                }
            }
            //return f;
            return Deserialize(str);
        }

        string IFormulaSaver.Save(MathFormula formula)
        {
            return saver.Save(formula);
           /* try
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                formatter.Serialize(stream, this);
                byte[] bytes = stream.GetBuffer();
                string s = "";
                foreach (byte b in bytes)
                {
                    s += (char)b;
                }
                return s;
            }
            catch (Exception eee)
            {
                string s = eee.StackTrace;
                s = "";
            }
            try
            {
                return ElementaryFormulaStringConverter.Object.Convert(formula);
            }
            catch (Exception)
            {
                ArrayList list = formula.ToArray();
                string s = "";
                for (int i = 0; i < list.Count; i++)
                {
                    char c = (char)(((byte[])list[i])[0]);
                    s += c;
                }
                return s;
            }*/
        }

        #endregion
    }

    static class Static
    {
        static internal void SaveChildren(this List<MathFormula> children, SerializationInfo info)
        {
            ArrayList l = new ArrayList();
            foreach (MathFormula s in children)
            {
                l.Add(s);
            }
            info.AddValue("Children", l, typeof(ArrayList));
        }

        static internal void Sync(this ArrayList l, ref List<MathFormula> f)
        {
            if (l == null)
            {
                return;
            }
            if (l.Count == 0)
            {
                return;
            }
            if (f == null)
            {
                f = new List<MathFormula>();
            }
            if (f.Count == 0)
            {
                foreach (MathFormula form in l)
                {
                    f.Add(form);
                }
            }
            
        }
    }

    
    class VersionBinderFormula : SerializationBinder
    {
        internal static readonly SerializationBinder Binder = new VersionBinderFormula();
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly assF = typeof(MathFormula).Assembly;
            Assembly assS = typeof(VersionBinderFormula).Assembly;
            string an = assemblyName;
            string typ = typeName;
            bool bo = typeName.Contains("FormulaEditor");
            if (bo & !assemblyName.Contains("Serializable") &  !(typeName.Contains("FormulaEditor.Symbols.MathSymbol") | typeName.Contains("FormulaEditor.MathSymbol")))
            {
                an = assS.FullName;
                typ = typeName + "Serializable";
            }
            else
            {
                //an = an;
            }
            if (typeName.Contains("System.Collections.Generic.List`1[[FormulaEditor.MathSymbol"))
            {
                return typeof(List<MathSymbol>);
            }
            Type t = Type.GetType(String.Format("{0}, {1}", typ, an));
            if (t == null)
            {
                if (typ.Contains("FormulaEditor."))
                {
                    typ = "FormulaEditor.Symbols." + typ.Substring("FormulaEditor.".Length);
                    t = Type.GetType(String.Format("{0}, {1}", typ, an));
                }
            }
            return t;
        }
    }

    public abstract class MathSymbolSerializable : MathSymbol, ISerializable
    {
        ArrayList ch;

        public MathSymbolSerializable(SerializationInfo info, StreamingContext context)
        {
            ch  = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));

        }


        #region ISerializable Members

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
        }

        #endregion
        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }


    }

    [Serializable()]
    public class MathFormulaSerializable : MathFormula, ISerializable
    {

        public MathFormulaSerializable(SerializationInfo info, StreamingContext context) :
            base((byte)0)
        {
            temp = info.GetValue("Temp", typeof(List<MathSymbol>)) as List<MathSymbol>;
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            temp = new List<MathSymbol>();
            foreach (MathSymbol s in symbols)
            {
                temp.Add(s);
            }
            info.AddValue("Temp", temp, typeof(List<MathSymbol>));
        }

         #endregion



    }

    [Serializable()]
    public class SimpleSymbolSerializable : SimpleSymbol, ISerializable
    {


        ArrayList ch;
        public SimpleSymbolSerializable(SerializationInfo info, StreamingContext context) : base('0')
        {
            ch  = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion


    }

    [Serializable()]
    public class BracketsSymbolSerializable : BracketsSymbol, ISerializable
    {
        ArrayList ch;
        public BracketsSymbolSerializable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
           ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion


    }

    [Serializable()]
    public class RootSymbolSerializable : RootSymbol, ISerializable
    {
        ArrayList ch;
        public RootSymbolSerializable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion


    }

    [Serializable()]
    public class SeriesSymbolSerializable : SeriesSymbol, ISerializable
    {
        ArrayList ch;
        protected SeriesSymbolSerializable(SerializationInfo info, StreamingContext context)
            : base(0)
        {
            try
            {
              ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            }
            catch (Exception)
            {
                ch = new ArrayList();
            }
            symbol = 'f';
            italic = true;
            s = "f";
            type = (byte)FormulaConstants.Series;
            try
            {
                level = (byte)info.GetValue("Level", typeof(byte));
            }
            catch (Exception)
            {
            }
            bold = true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }

    [Serializable()]
    public class FractionSymbolSerializable : FractionSymbol, ISerializable
    {
        ArrayList ch;
        public FractionSymbolSerializable(SerializationInfo info, StreamingContext context)
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }

    [Serializable()]
    public class BinarySymbolSerializable : BinarySymbol, ISerializable
    {
        ArrayList ch;
        public BinarySymbolSerializable(SerializationInfo info, StreamingContext context)
            : base('0')
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }

    [Serializable()]
    public class IndexedSymbolSerializable : IndexedSymbol, ISerializable
    {
        ArrayList ch;

        public IndexedSymbolSerializable(SerializationInfo info, StreamingContext context)
            : base('0')
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));

        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }


    [Serializable()]
    public class DateTimeSymbolSerializable : DateTimeSymbol, ISerializable
    {
        ArrayList ch;
        public DateTimeSymbolSerializable(SerializationInfo info, StreamingContext context)
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));
            dt = (DateTime)info.GetValue("DateTime", typeof(DateTime));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
            info.AddValue("DateTime", dt, typeof(DateTime));
        }

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion


    }

    [Serializable()]
    public class FieldSymbolSerializable : FieldSymbol, ISerializable
    {
        ArrayList ch;
        public FieldSymbolSerializable(SerializationInfo info, StreamingContext context)
            : base("")
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }

    [Serializable()]
    public class SubscriptedSymbolSerializable : SubscriptedSymbol, ISerializable
    {
        ArrayList ch;
        public SubscriptedSymbolSerializable(SerializationInfo info, StreamingContext context) :
         base("", "")   
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            sub = info.GetValue("Sub", typeof(string)) + "";
            pair = new StringPair(s, sub);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
            info.AddValue("Sub", sub, typeof(string));
        }

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }

    [Serializable()]
    public class BinaryFunctionSymbolSerializable : BinaryFunctionSymbol, ISerializable
    {
        ArrayList ch;
        public BinaryFunctionSymbolSerializable(SerializationInfo info, StreamingContext context)
            : base('0', "0")
        {
            ch = info.GetValue("Children", typeof(ArrayList)) as ArrayList;
            symbol = (char)info.GetValue("Symbol", typeof(char));
            s = info.GetValue("S", typeof(string)) + "";
            type = (byte)info.GetValue("Type", typeof(byte));
            index = (int)info.GetValue("Index", typeof(int));
            level = (byte)info.GetValue("Level", typeof(byte));
            doubleValue = (double)info.GetValue("DoubleValue", typeof(double));
            ulongValue = (ulong)info.GetValue("UlongValue", typeof(ulong));
            sb = info.GetValue("Sb", typeof(string)) + "";
            italic = (bool)info.GetValue("Italic", typeof(bool));
            bold = (bool)info.GetValue("Bold", typeof(bool));
        }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
             children.SaveChildren(info);
            info.AddValue("Symbol", symbol, typeof(char));
            info.AddValue("S", s, typeof(string));
            info.AddValue("Type", type, typeof(byte));
            info.AddValue("Index", index, typeof(int));
            info.AddValue("Level", level, typeof(byte));
            info.AddValue("DoubleValue", doubleValue, typeof(double));
            info.AddValue("UlongValue", ulongValue, typeof(ulong));
            info.AddValue("Sb", sb, typeof(string));
            info.AddValue("Italic", italic, typeof(bool));
            info.AddValue("Bold", bold, typeof(bool));
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Post serialization method
        /// </summary>
        public override void Post()
        {
            ch.Sync(ref children);
            base.Post();
        }

        #endregion

    }
}