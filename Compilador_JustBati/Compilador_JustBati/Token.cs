uusing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compilador_JustBati;

namespace Compilador_JustBati
{
    internal class Token
    {
        Lex lexema = new Lex();
        string[] memo = lex.Get_lines(@"./prueba.txt");

        public void declaration(string[] memo, int Num_linea, int Num_palabra)
        {
            string[] aux = lex.Get_words(memo[Num_linea]);
          if (lexema.Is_class(aux[0]))
          {
               Class_declaration(memo, Num_linea, Num_palabra + 1);
          }
          else if(lexema.Is_Fun(aux[0]))
          {
                Functions(memo, Num_linea, Num_palabra + 1);
            }
          else if (lexema.Is_Var(aux[0]))
          {
               Var_declaration(memo, Num_linea, Num_palabra +1);
          }
          else if (memo[Num_linea]=="\n")
            {
                declaration(memo, Num_linea + 1, 0);
            }
          else
            {
                Statement_declaratiom(memo, Num_linea, 0)
            }
        }

        public void Class_declaration(string[] memo, int Num_linea, int Num_palabra)
        {
            string[] aux = lex.Get_words(memo[Num_linea]);
            if (lexema.Is_ID(aux[Num_palabra]))
            {
                Class_inher(memo, Num_linea, Num_palabra + 1);
            }
            else if (lexema.Is_key_o(aux[Num_palabra]))
            {
                Functions(memo, Num_linea, Num_palabra + 1);
            }
        }

        public void Class_inher(string[] memo, int Num_linea, int Num_palabra)
        {
            string[] aux = lex.Get_words(memo[Num_linea]);
            if (lexema.Is_LT(aux[Num_palabra]) and lexema.Is_ID(aux[Num_palabra+1]))
            {
                Functions(memo, Num_linea, Num_palabra + 1);
            }
            else if (lexema.Is_key_c(aux[Num_palabra]))
            {
                Functions(memo, Num_linea, Num_palabra + 1);
            }
            else
            {
                Functions(memo, Num_linea, Num_palabra + 1);
            }
        }

        public void Var_declaration(string[] memo, int Num_linea, int Num_palabra)
        {
            string[] aux = lex.Get_words(memo[Num_linea]);
            if (lexema.Is_ID(aux[Num_palabra]))
            {
                Var_init(memo, Num_linea, Num_palabra + 1);
            }
            else
            {
                console.writeline("Error en la linea: " + Num_linea + " palabra: " + Num_palabra);
            }
        }
        public void Var_init(string[] memo, int Num_linea, int Num_palabra)
        {
            string[] aux = lex.Get_words(memo[Num_linea]);
            if (lexema.Is_asign(aux[Num_palabra]))
            {
                Exp(memo, Num_linea, Num_palabra + 1);
            }
            else if (lexema.IS_semicolon(aux[Num_palabra]))
            {
                declaration(memo, Num_linea, Num_palabra + 1);
            }
            else
            {
                console.writeline("Error en la linea: " + Num_linea + " palabra: " + Num_palabra);
            }
        }    
        
        public void Functions(string[] memo, int Num_linea, int Num_palabra)
        {
            string[] aux = lex.Get_words(memo[Num_linea]);
            if (lexema.Is_ID(aux[Num_palabra]))
            {
                Functions_param(memo, Num_linea, Num_palabra + 1);
            }
            else
            {
                console.writeline("Error en la linea: " + Num_linea + " palabra: " + Num_palabra);
            }
        }   
    }
}
