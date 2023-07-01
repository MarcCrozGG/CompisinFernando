using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compilador_JustBati
{
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
                words[i] = aux[i];
            }
            return words;
        }   
        public bool Is_ID(string word)
        {
            Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            Match match = regex.Match(word);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }   
        public bool Is_Num(string word)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            Match match = regex.Match(word);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Is_Op(string word)
        {
            Regex regex = new Regex(@"^[+|-|*|/|=|<|>|!|&]$");
            Match match = regex.Match(word);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Is_Sep(string word)
        {
            Regex regex = new Regex(@"^[,|;|(|)|{|}]$");
            Match match = regex.Match(word);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Is_Res(string word)
        {
            Regex regex = new Regex(@"^(if|else|while|do|for|switch|case|break|continue|return|true|false|void|int|float|char|bool)$");
            Match match = regex.Match(word);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Is_Com(string word)
        {
            Regex regex = new Regex(@"^\/\*.*\*\/$");
            Match match = regex.Match(word);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
