import re
import os
import sys
import codecs

# Lista de tokens
tokens = [
    'ID',
    'NUMBER',
    'STRING',
    'PLUS',
    'MINUS',
    'TIMES',
    'DIVIDE',
    'EQUALS',
    'LPAREN',
    'RPAREN',
    'LBRACE',
    'RBRACE',
    'SEMICOLON',
    'COMMA',
    'DOT',
    'EQ',
    'NE',
    'LT',
    'LE',
    'GT',
    'GE',
    'COMMENT',
]

# Lista de palabras reservadas
reserved = {
    'if': 'IF',
    'else': 'ELSE',
    'for': 'FOR',
    'var': 'VAR',
    'print': 'PRINT',
    'return': 'RETURN',
    'while': 'WHILE',
    'class': 'CLASS',
}

# Expresiones regulares para tokens simples
t_PLUS = r'\+'
t_MINUS = r'-'
t_TIMES = r'\*'
t_DIVIDE = r'/'
t_EQUALS = r'='
t_LPAREN = r'\('
t_RPAREN = r'\)'
t_LBRACE = r'\{'
t_RBRACE = r'\}'
t_SEMICOLON = r';'
t_COMMA = r','
t_DOT = r'\.'
t_EQ = r'=='
t_NE = r'!='
t_LT = r'<'
t_LE = r'<='
t_GT = r'>'
t_GE = r'>='

# Expresiones regulares con acciones para tokens más complejos
def t_ID(t):
    r'[a-zA-Z_][a-zA-Z0-9_]*'
    t.type = reserved.get(t.value, 'ID')
    return t

def t_NUMBER(t):
    r'\d+(\.\d+)?'
    t.value = float(t.value) if '.' in t.value else int(t.value)
    return t

def t_COMMENT(t):
    r'\#.*'
    pass  # Ignorar comentarios

# Expresión regular para ignorar espacios y saltos de línea
t_ignore = ' \t\r\n'

# Expresión regular para contar el número de líneas
def t_newline(t):
    r'\n+'
    t.lexer.lineno += len(t.value)

# Expresión regular para manejar errores
def t_error(t):
    print(f"Error: Caracter inesperado '{t.value[0]}'")
    t.lexer.skip(1)

def buscarFicheros(directorio):
    ficheros = []
    numArchivo = ''
    respuesta = False
    cont = 1

    for base, dirs, files in os.walk(directorio):
        ficheros.append(files)

    for file in files:
        print(f"{cont}. {file}")
        cont += 1

    while not respuesta:
        numArchivo = input('\nNumero de prueba: ')
        if file == files[int(numArchivo)-1]:
            respuesta = True
            break

    print(f"Has escogido \"{files[int(numArchivo)-1]}\"")
    return files[int(numArchivo)-1]

directorio = './prueba'
archivo = buscarFicheros(directorio)
test = directorio
fp = codecs.open(os.path.join(directorio, archivo), "r", encoding="utf-8")
cadena = fp.read()

# Analizador léxico manual
def lex(input_string):
    token_regex = '|'.join(f'(?P<{t}>{getattr(sys.modules[__name__], t)})' for t in tokens)
    line_number = 1
    for match in re.finditer(token_regex, input_string):
        token_type = match.lastgroup
        token_value = match.group(token_type)
        if token_type == 'COMMENT':
            line_number += 1
        else:
            yield token_type, token_value, line_number

# Ejecución del analizador léxico
for token in lex(cadena):
    print(token)

fp.close()

