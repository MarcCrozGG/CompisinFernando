using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compilador_JustBati
{
    //clase para analizar los lexemas y gestionar la existencia del lenguaje dentro del archivo
    internal class Lex
    {
        //Metodo para obtener la informacion del archivo y separarla en lineas
        public string[] Get_lines(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }
        //metodo para separar las lineas en palabras
        public string[] Get_words(string[] lines)
        {
            string[] words = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string[] aux = lines[i].Split(' ');
                foreach (var item in aux)
                {
                    words[i] = item;
                }
            }
            return words;
        }
        public bool Is_ID(string word)
        {
            Regex regex = new Regex(@"^[A-Za-z_][A-Za-z0-9_]*$");
            return regex.IsMatch(word);
        }
        public bool Is_Num(string word)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(word);
        }
        public bool Is_Op(string word)
        {
            Regex regex = new Regex(@"^[+|-|*|/|=|<|>|!|&]$");
            return regex.IsMatch(word);
        }
        public bool Is_Sep(string word)
        {
            Regex regex = new Regex(@"^[,|;|(|)|{|}]$");
            return regex.IsMatch(word);
        }
        public bool Is_Res(string word)
        {
            Regex regex = new Regex(@"^(if|else|while|do|for|switch|case|break|continue|return|true|false|void|int|float|char|bool)$");
            return regex.IsMatch(word);
        }
        public bool Is_Com(string word)
        {
            Regex regex = new Regex(@"^\/\*.*\*\/$");
            return regex.IsMatch(word);
        }

        // New methods
        public bool Is_Begin(string word)
        {
            Regex regex = new Regex(@"^begin$");
            return regex.IsMatch(word);
        }

        public bool Is_End(string word)
        {
            Regex regex = new Regex(@"^end$");
            return regex.IsMatch(word);
        }

        public bool Is_Then(string word)
        {
            Regex regex = new Regex(@"^then$");
            return regex.IsMatch(word);
        }

        public bool Is_Call(string word)
        {
            Regex regex = new Regex(@"^call$");
            return regex.IsMatch(word);
        }

        public bool Is_Const(string word)
        {
            Regex regex = new Regex(@"^const$");
            return regex.IsMatch(word);
        }

        public bool Is_Var(string word)
        {
            Regex regex = new Regex(@"^var$");
            return regex.IsMatch(word);
        }

        public bool Is_Procedure(string word)
        {
            Regex regex = new Regex(@"^procedure$");
            return regex.IsMatch(word);
        }

        public bool Is_Out(string word)
        {
            Regex regex = new Regex(@"^out$");
            return regex.IsMatch(word);
        }

        public bool Is_In(string word)
        {
            Regex regex = new Regex(@"^in$");
            return regex.IsMatch(word);
        }

        public bool Is_For(string word)
        {
            Regex regex = new Regex(@"^for$");
            return regex.IsMatch(word);
        }

        public bool Is_If(string word)
        {
            Regex regex = new Regex(@"^if$");
            return regex.IsMatch(word);
        }

        public bool Is_else(string word)
        {
            Regex regex = new Regex(@"^else$");
            return regex.IsMatch(word);
        }

        public bool Is_And(string word)
        {
            Regex regex = new Regex(@"^and$");
            return regex.IsMatch(word);
        }

        public bool Is_Print(string word)
        {
            Regex regex = new Regex(@"^print$");
            return regex.IsMatch(word);
        }

        public bool Is_Return(string word)
        {
            Regex regex = new Regex(@"^return$");
            return regex.IsMatch(word);
        }

        public bool Is_While(string word)
        {
            Regex regex = new Regex(@"^while$");
            return regex.IsMatch(word);
        }

        public bool Is_Block(string word)
        {
            Regex regex = new Regex(@"^block$");
            return regex.IsMatch(word);
        }

        public bool Is_Fun(string word)
        {
            Regex regex = new Regex(@"^fun$");
            return regex.IsMatch(word);
        }

        public bool Is_Tab(string word)
        {
            Regex regex = new Regex(@"^\t$");
            return regex.IsMatch(word);
        }

        public bool Is_Plus(string word)
        {
            Regex regex = new Regex(@"^\+$");
            return regex.IsMatch(word);
        }

        public bool Is_Minus(string word)
        {
            Regex regex = new Regex(@"^-$");
            return regex.IsMatch(word);
        }

        public bool Is_Times(string word)
        {
            Regex regex = new Regex(@"^\*$");
            return regex.IsMatch(word);
        }

        public bool Is_Divide(string word)
        {
            Regex regex = new Regex(@"^/$");
            return regex.IsMatch(word);
        }

        public bool Is_Odd(string word)
        {
            Regex regex = new Regex(@"^ODD$");
            return regex.IsMatch(word);
        }

        public bool Is_Assign(string word)
        {
            Regex regex = new Regex(@"^=$");
            return regex.IsMatch(word);
        }

        public bool Is_NE(string word)
        {
            Regex regex = new Regex(@"^<>$");
            return regex.IsMatch(word);
        }

        public bool Is_LT(string word)
        {
            Regex regex = new Regex(@"^<$");
            return regex.IsMatch(word);
        }

        public bool Is_LTE(string word)
        {
            Regex regex = new Regex(@"^<=$");
            return regex.IsMatch(word);
        }

        public bool Is_GT(string word)
        {
            Regex regex = new Regex(@"^>$");
            return regex.IsMatch(word);
        }

        public bool Is_GTE(string word)
        {
            Regex regex = new Regex(@"^>=$");
            return regex.IsMatch(word);
        }

        public bool Is_LPARENT(string word)
        {
            Regex regex = new Regex(@"^\($");
            return regex.IsMatch(word);
        }

        public bool Is_RPARENT(string word)
        {
            Regex regex = new Regex(@"^\)$");
            return regex.IsMatch(word);
        }

        public bool Is_Comma(string word)
        {
            Regex regex = new Regex(@"^,$");
            return regex.IsMatch(word);
        }

        public bool Is_Semicolom(string word)
        {
            Regex regex = new Regex(@"^;$");
            return regex.IsMatch(word);
        }

        public bool Is_Dot(string word)
        {
            Regex regex = new Regex(@"^\.$");
            return regex.IsMatch(word);
        }

        public bool Is_Update(string word)
        {
            Regex regex = new Regex(@"^:=$");
            return regex.IsMatch(word);
        }
    }
}
