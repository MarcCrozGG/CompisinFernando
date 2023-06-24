import ply.yacc as yacc
from lex import tokens
from sys import stdin

precedence = (
    ('right', 'ASSIGN'),
    ('right', 'UPDATE'),
    ('left', 'NE'),
    ('left', 'LT', 'LTE', 'GT', 'GTE'),
    ('left', 'PLUS', 'MINUS'),
    ('left', 'TIMES', 'DIVIDE'),
    ('right', 'ODD'),
    ('left', 'LPARENT', 'RPARENT'),
)


def p_program(p):
    '''program : block'''
    print("program")


def p_block(p):
    '''block : constDecl varDecl procDecl statement'''
    print("block")


def p_constDecl(p):
    '''p_constDecl : CONST constAssignmentList SEMMICOLOM'''
    print("constDecl")


def p_constDeclEmpty(p):
    '''p_constDecl : empty'''
    print("nulo")


def p_constAssignmentlist1(p):
    '''constAssignmentlist : ID ASSIGN NUMBER'''
    print("constAssignmentList 1")


def p_constAssignmentlist2(p):
    '''constAssignmentlist : constAssignmentlist COMMA ID ASSIGN NUMBER'''
    print("constAssignmentList 2")


def p_varDecl1(p):
    '''varDecl : VAR  identlist SEMMICOLOM'''
    print("varDecl 1")


def p_varDeclEmpty(p):
    '''varDecl : empty'''
    print("nulo")


def p_identList1(p):
    '''identlist : ID'''
    print("identList 1")


def p_identlist2(p):
    '''identList : identList COMMA ID'''
    print("identList 2")


def p_procDecl1(p):
    '''procDecl : procdecl PROCEDURE ID SEMMICOLOM  block SEMMICOLOM'''
    print("procDecl 1")


def p_procDeclEmpty(p):
    '''procDecl : empty'''
    print("nulo")


def p_statement1(p):
    '''statement : ID UPDATE expression'''
    print("statement 1")


def p_statement2(p):
    '''statement : CALL ID'''
    print("statement 2")


def p_statement3(p):
    '''statement : BEGIN statementList END'''
    print("statement 3")


def p_statement4(p):
    '''statement : IF condition THEN statement'''
    print("statement 4")


def p_statement5(p):
    '''statement : WHILE condition DO statement'''
    print("statement 5")


def p_statementEmpty(p):
    '''statement : empty'''
    print("nulo")


def p_statementList1(p):
    '''statementList : statement'''
    print("statementList 1")


def p_statementList2(p):
    '''statementList : statementList SEMMICOLOM statement'''
    print("statementList 2")


def p_condition1(p):
    '''condition : ODD expression'''
    print("condition 1")


def p_condition2(p):
    '''condition : expression relation expression'''
    print("condition 2")


def p_relation1(p):
    '''relation : ASSIGN'''
    print("relation 1")


def p_relation2(p):
    '''relation : NE'''
    print("relation 2")


def p_relation3(p):
    '''relation : LT'''
    print("relation 3")


def p_relation4(p):
    '''relation : GT'''
    print("relation 4")


def p_relation5(p):
    '''relation : LTE'''
    print("relation 5")


def p_relation6(p):
    '''relation : GTE'''
    print("relation 6")


def p_expression1(p):
    '''expression : term'''
    print("expresion 1")


def p_expression2(p):
    '''expression : addingOperator term'''
    print("expresion 2")


def p_expression3(p):
    '''expresion : expression addingOperator term'''
    print("expresion 3")


def p_addingOperator1(p):
    '''addingOperator : PLUS'''
    print("addingOperator 1")


def p_addingOperator2(p):
    '''addingOperator : MINUS'''
    print("addingOperator 1")


def p_term1(p):
    '''term : factor'''
    print("term 1")


def p_term2(p):
    '''term : term multiplyingOperator factor'''
    print("term 1")


def p_multiplyingOperator1(p):
    '''multiplyingOperator : TIMES'''
    print("multiplyingOperator 1")


def p_multiplyingOperator2(p):
    '''multiplyingOperator : DIVIDE'''
    print("multiplyingOperator 2")


def p_factor1(p):
    '''factor : ID'''
    print("factor 1")


def p_factor2(p):
    '''factor : NUMBER'''
    print("factor 1")


def p_factor3(p):
    '''factor : LPARENT expression RPARENT'''
    print("factor 1")


def p_empty(p):
    '''empty : '''
    pass


def p_error(p):
    print("Error de sintaxis ", p)


parser = yacc.yacc()
resultado = parser.parse(stdin.read(), lexer=parser.lexer)

print(resultado)
