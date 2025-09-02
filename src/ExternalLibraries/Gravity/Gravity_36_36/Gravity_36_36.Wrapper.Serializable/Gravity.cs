using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using ErrorHandler;
using SerializationInterface;

using Web.Interfaces;

namespace Gravity_36_36.Wrapper.Serializable
{
    /// <summary>
    /// Gravity field
    /// </summary>
    [Serializable]
    public class Gravity : Wrapper.Gravity, ISerializable
    {

        #region Fields

        private TextReader reader;

        string current;

        static private readonly char[] sep = " ".ToCharArray();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Gravity()
        {
            N0 = 36;
            NK = 36;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Url</param>
        public Gravity(string url)
            : this()
        {
            (this as IUrlConsumer).Url = url;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Gravity(SerializationInfo info, StreamingContext context)
        {
            Saver = info.Deserialize<List<object>>("Saver");
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize("Saver", Saver);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Loads itself from the text reader
        /// </summary>
        /// <param name="reader">The text reader</param>
        public void Load(TextReader reader)
        {
            this.reader = reader;
            double[] ANAi = new double[37];
            double[] Hp = new double[700];
            int N, N1;
            int N0 = 36;
            int N01 = N0 - 1;
            int NP = N01 * (N0 + 4) / 2;
            for (int i = 0; i < 700; i++)
            {
                C[i] = 0; S[i] = 0;
            }
            reader.ReadLine();
            Read(out R[1]);
            Read(out R[2]);
            Read(out R[0]);
            m200:
            int I, J; double CC, SS;
            if (!(Read(out I))) goto m300;
            if (!(Read(out J))) goto m300;
            if (!(Read(out CC))) goto m300;
            if (!(Read(out SS))) goto m300;
            if (I <= N0)
            {
                if (J < 2)
                {
                    N = N01 * J + I - 1;
                }
                else
                {
                    N = N0 - J + 1;
                    N = NP - N * (N + 1) / 2 + I - J + 1;
                }
                C[N - 1] = CC;
                S[N - 1] = SS;
            }
            goto m200;
            m300:
            reader.Close();
            N01 = N0 + 1;
            for (N = 1; N <= N0; N++) Hp[N - 1] = 1 + (double)N;
            for (N1 = 1; N1 <= N01; N1++)
            {
                N = N1 - 1;
                if (N > 3)
                    ANAi[N1 - 1] = N * (N0 - 1) + 1 - (N - 3) * (N - 2) / 2;
                else
                    ANAi[N1 - 1] = 1 + N * (N0 - 1);
            }
            for (int i = 36; i < 700; i++) Hp[i] = 0;
            for (int i = 0; i < 37; i++) Hp[222 + i] = ANAi[i];
            for (int i = 0; i < 37; i++)
            {
                HP[i] = Hp[i];
                CO[i] = Hp[i + 37];
                SI[i] = Hp[i + 2 * 37];
                AR[i] = Hp[i + 3 * 37];
                CF[i] = Hp[i + 4 * 37];
                PNK[i] = Hp[i + 5 * 37];
            }
            for (int i = 0; i < 478; i++)
            {
                ANAI[i] = Hp[i + 6 * 37];
            }
        }

        /// <summary>
        /// Loads from file
        /// </summary>
        /// <param name="filename">File name</param>
        public void LoadFromFile(string filename)
        {
            (this as IUrlConsumer).Url = "";
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    Load(reader);
                }
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
            }
        }

        #endregion

        #region Private Members

        private bool Read(out int i)
        {
            if (!Next())
            {
                i = 0;
                return false;
            }
            try
            {
                i = Int32.Parse(current);
                return true;
            }
            catch (Exception)
            {
            }
            i = 0;
            return false;
        }

        private bool Read(out double a)
        {
            if (!Next())
            {
                a = 0;
                return false;
            }
            try
            {
                a = Double.Parse(current, System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch (Exception)
            {
                a = 0;
                return false;
            }
        }

        private void Prepare()
        {
            if (inp == null)
            {
                string s = reader.ReadLine();
                inp = s.Split(sep);
                pos = 0;
            }
            current = inp[pos].Trim();
            if (current.Length == 0)
            {
            }
            ++pos;
            if (pos >= inp.Length)
            {
                inp = null;
            }
        }

        void NextLine()
        {
            string s = reader.ReadLine();
            inp = s.Split(sep);
        }

        bool Next()
        {
            if (inp == null)
            {
                string s = reader.ReadLine();
                if (s == null)
                {
                    return false;
                }
                inp = s.Split(sep);
            }
            while (true)
            {
                if (pos == inp.Length)
                {
                    pos = 0;
                    string s = reader.ReadLine();
                    if (s == null)
                    {
                        return false;
                    }
                    inp = s.Split(sep);
                }
                current = inp[pos];
                ++pos;
                if (current.Length > 0)
                {
                    break;
                }
            }
            return true;
        }


        private double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }

        private double Sqrt(int i)
        {
            return Math.Sqrt((double)i);
        }



        #endregion

    }
}