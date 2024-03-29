lexer grammar RMALR_lexer;

IDENTIFIER: [a-z][A-Za-z_]*;

TOKEN_NAME: [A-Z][A-Za-z_]*;
REGEXP: QUOTE .+? QUOTE;

SEMICOLON: ';';
COLON: ':';
OPTION_MARK: '|';
COMMA: ',';
LEFT_PAR: '(';
RIGHT_PAR: ')';
LEFT_SQUARE: '[';
RIGHT_SQUARE: ']';
ARROW: '->';
DOLLAR: '$';
DOT: '.';

RETURNS: '@returns';

QUESTION_MARK: '?';
PLUS: '+';
MULTIPLY: '*';

QUOTE: '"';

SKIP_RULE: '@skip';

WHITESPACES: ' '+ -> skip;
NEWLINE: '\r'? '\n' -> skip;

OPEN_BRACE: '{' -> pushMode(ACTION);

mode ACTION;
CLOSE_BRACE: '}' -> popMode;
CODE: ([ a-zA-Z0-9.=-] | '+' | '*' | '/' | ';' | '$' | '(' | ')' | '"' | '_' | '\r' | '\n' | '<')+;