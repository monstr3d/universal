using System;
using System.Collections.Generic;
using System.Text;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;

namespace FormulaEditor
{
    /// <summary>
    /// Converter of string to math formula
    /// </summary>
    public abstract class MathFormulaStringConverter : IFormulaStringConverter
    {
        /// <summary>
        /// Separator symbol
        /// </summary>
        protected const char Separator = '\u0410';

        /// <summary>
        /// Begin separator symbol
        /// </summary>
        protected const char BeginSeparator = '(';

        /// <summary>
        /// End separator symbol
        /// </summary>
        protected const char EndSeparator = ')';

        /// <summary>
        /// Shift
        /// </summary>
        protected const int Shift = 2;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MathFormulaStringConverter()
        {
        }



        /// <summary>
        /// Converts string to formula
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <param name="sizes">Sizes of formula characters</param>
        /// <returns>The formula</returns>
        public MathFormula Convert(string str, int[] sizes)
        {
            return new MathFormula(0, sizes, str, 0, str.Length, this);
        }

        /// <summary>
        /// Converts formula to string
        /// </summary>
        /// <param name="formula">Formula to convert</param>
        /// <returns>String representation of formula</returns>
        public string Convert(MathFormula formula)
        {
            string s = "";
            for (int i = 0; i < formula.Count; i++)
            {
                s += Convert(formula[i]);
            }
            return s;
        }

        /// <summary>
        /// Converts formula symbol to string
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <returns>String representation of symbol</returns>
        public abstract string Convert(MathSymbol symbol);


        /// <summary>
        /// Chooses symbol from string
        /// </summary>
        /// <param name="str">The string</param>
        /// <param name="b">The begin position</param>
        /// <param name="e">The end position</param>
        /// <returns>The chosen symbol</returns>
        public abstract MathSymbol ChooseSymbol(string str, int b, int e);

        /// <summary>
        /// Gets position of next symbol
        /// </summary>
        /// <param name="str">The string vector</param>
        /// <param name="n">The current symbol position</param>
        /// <returns>position of next symbol</returns>
        public int Next(string str, int n)
        {
            int s = str.Length;
            if (str[n] == '\u2220')
            {
                for (int i = n + 1; i < str.Length - 1; i++)
                {
                    if ((str[i] == Separator) & (str[i + 1] == BeginSeparator))
                    {
                        int mm = 1;
                        for (int j = i + Shift; j < str.Length; j++)
                        {
                            if ((str[j] == Separator) & (str[j + 1] == BeginSeparator))
                            {
                                ++mm;
                                ++j;
                                continue;
                            }
                            if ((str[j] == Separator) & (str[j + 1] == EndSeparator))
                            {
                                --mm;
                                if (mm != 0)
                                {
                                    ++j;
                                    continue;
                                }
                                j += 2;
                                if (j >= str.Length)
                                {
                                    return -1;
                                }
                                return j;
                            }
                        }
                    }
                }
            }
            if (n >= s - 1)
            {
                return -1;
            }
            if (n + Shift >= (s - 1))
            {
                return -1;
            }
            char b = str[n + 1];
            if ((str[n + Shift] != Separator) | (str[n + Shift + 1] != BeginSeparator))
            {
                return n + Shift;
            }
            int m = 0;
            for (int i = n + Shift; i < s - 2; i++)
            {
                if (str[i] == Separator & str[i + 1] == BeginSeparator)
                {
                    m++;
                }
                else if (str[i] == Separator & str[i + 1] == EndSeparator)
                {
                    m--;
                }
                if (m == 0)
                {
                    if (i < s - 4)
                    {
                        if (str[i + 2] == Separator & str[i + 3] == BeginSeparator)
                        {
                            ++m;
                            i += 2;
                            continue;
                        }
                    }
                    if ((i + 1) == (s - 1))
                    {
                        return -1;
                    }
                    else
                    {
                        return i + 2;
                    }
                }
                if ((i + 1) == (s - 1))
                {
                    return -1;
                }
            }
            return -1;
        }

        /// <summary>
        /// Creates symbol from fragment of string
        /// </summary>
        /// <param name="f">Formula for setting symbol</param>
        /// <param name="str">The string</param>
        /// <param name="b">Fragment begin</param>
        /// <param name="e">Fragment end</param>
        /// <returns>The symbol</returns>
        public MathSymbol CreateSymbol(MathFormula f, string str, int b, int e)
        {
            char c = str[b];
            char by = str[b + 1];
            char cb = (char)by;
            MathSymbol s = ChooseSymbol(str, b, e);
            if (s == null)
            {
                return null;
            }
            s.Append(f);
            MathSymbol symb = f.Last;
            int j = b + Shift;
            if (str[b] == '\u2220')
            {
                for (; j < str.Length; j++)
                {
                    if (str[j] == Separator)
                    {
                        break;
                    }
                }
            }
            if (symb.Count > 0)
            {
                for (int i = 0; i < symb.Count; i++)
                {
                    int m = 0;
                    for (int k = j; k < str.Length; k++)
                    {

                        char bt = str[k];
                        if (k > str.Length - 2)
                        {
                            break;
                        }
                        if (k < str.Length - 1)
                        {
                            if (bt == Separator & str[k + 1] == BeginSeparator)
                            {
                                m++;
                            }
                            else if (bt == Separator & str[k + 1] == EndSeparator)
                            {
                                m--;
                            }
                        }
                        if (m <= 0 & k > j)
                        {
                            if (symb[i] != null)
                            {
                                int bd = (str[j] == Separator) ? 1 : 0;
                                int ed = (str[k] == EndSeparator) ? 1 : 0;
                                if (i > 0)
                                {
                                    //	bd++;
                                    ed--;
                                }
                                MathFormula formula = new MathFormula(symb[i].Level,
                                    f.Sizes, str, j + bd + 1, k - ed - 1, this);
                                symb[i] = formula;
                                j = k + 1;
                                if (str[j] == EndSeparator)
                                {
                                    ++j;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return symb;
        }
    }

}
