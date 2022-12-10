grammar lexis;

start
    : EOF 
    | (token NEWLINE*)* EOF;

token: TOKEN_NAME ':' patterns ('->' rule+)? ';';
patterns: pattern+;
pattern: TOKEN_NAME | REGEXP;

rule: SKIP_RULE;

TOKEN_NAME: [A-Z][A-Za-z_]*;
REGEXP: QUOTE .+? QUOTE;

QUOTE: '"';

SKIP_RULE: 'skip';

WHITESPACES: ' '+ -> skip;
NEWLINE: '\r'? '\n';