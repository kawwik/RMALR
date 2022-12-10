grammar lexis;

start
    : EOF 
    | (token NEWLINE*)* EOF;

token: TOKEN_NAME ':' patterns ';';
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

TOKEN_NAME: [A-Z][A-Za-z_]*;
REGEXP: QUOTE .+? QUOTE;

QUOTE: '\'';

WHITESPACES: ' '+ -> skip;
NEWLINE: '\r'? '\n';