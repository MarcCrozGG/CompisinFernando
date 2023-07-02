using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador_JustBati;

namespace Compilador_JustBati
{
    internal class AnalizadorLexico
    {
        Lex lexema = new Lex();
        public bool Is_on_rule(string word)
        {
            if (lexema.Is_ID(word) || lexema.Is_Num(word) || lexema.Is_Op(word) || lexema.Is_Sep(word) || lexema.Is_Res(word) || lexema.Is_Com(word))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Run_Lex()
        {
            int error = 0;
            string[] words = lexema.Get_words(lexema.Get_lines(@"./prueba.txt"));
            foreach (var item in words)
            {
                if (Is_on_rule(item))
                {
                    Console.WriteLine(item + " es valido");
                }
                else
                {
                    Console.WriteLine(item + " no es valido");
                }
            }
        }
    }
}
