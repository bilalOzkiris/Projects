#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <stdbool.h>
int main()
{
    FILE *psiPtr;
    if ( ( psiPtr = fopen( "code.psi.txt", "r" ) ) == NULL )
    {
       printf( "File could not be opened.\n" );
    }
    else
    {
        FILE *lexPtr;
        if ( ( lexPtr = fopen( "code.lex.txt", "w" ) ) == NULL )
        {
            printf( "File could not be opened.\n" );
        }
        else
        {
            char keywords[18][10] = {"break", "case", "char", "const", "continue",
                                    "do", "else", "enum", "float", "for", "goto",
                                    "if", "int", "long", "record", "return", "static",
                                    "while"};
            char lPar[] = "LeftPar", rPar[] = "RightPar", lSBracket[] = "LeftSquareBracket";
            char rSBracket[] = "RightSquareBracket", lCBracket[] = "LeftCurlyBracket", rCBracket[] = "RightCurlyBracket";
            char eOfLine[] = "EndOfLine";
            char error1[] = "Error!!! Maximum identifier size must be 20 characters.";
            char error2[] = "Error!!! Maximum integer size must be 10 digits.";
            char error3[] = "Error!!! Invalid operator.";
            char error4[] = "Error!!! Comment did not terminate before the file end.";
            char error5[] = "Error!!! String constant did not terminate before the file end.";
            int i = 0, j = 0, k = 0;
            char ch, chPointMan, identOrKeyword[30], identOrKeywordCopy[30], intConst[20], opertr[5];
            ch = fgetc( psiPtr );
            while ( true )
            {
                if ( ch == EOF )
                    break;
                if ( isalpha( ch ) )
                {
                    identOrKeyword[i] = ch;
                    identOrKeywordCopy[i] = ch;
                    chPointMan = fgetc( psiPtr );
                    while ( ( isalpha( chPointMan )) || ( isdigit( chPointMan ) ) || ( chPointMan == '_' ) )
                    {
                        ch = chPointMan;
                        i++;
                        identOrKeyword[i] = ch;
                        identOrKeywordCopy[i] = ch;
                        chPointMan = fgetc( psiPtr );
                    }
                    ch = chPointMan;
                    if ( i > 19 )
                    {
                        fprintf( lexPtr, "%s\n", error1 );

                    }
                    else
                    {
                        for ( int q = 0; q < strlen( identOrKeywordCopy ); q++ )
                        {
                            tolower( identOrKeywordCopy[q] );
                        }
                        bool flag = false;
                        for ( int w = 0; w < 18; w++ )
                        {
                            if ( ( strcmp( identOrKeywordCopy, keywords[w] ) ) == 0 )
                            {
                                fprintf( lexPtr, "Keyword(%s)\n", keywords[w] );
                                flag = true;
                                break;
                            }
                        }
                        if ( !flag )
                        {
                            fprintf( lexPtr, "Identifier(%s)\n", identOrKeyword );
                        }
                    }
                    memset( identOrKeyword, '\0', (i + 1) );
                    memset( identOrKeywordCopy, '\0', (i + 1) );
                    i = 0;
                }
                if ( isdigit( ch ) )
                {
                    intConst[j] = ch;
                    chPointMan = fgetc( psiPtr );
                    while ( isdigit( chPointMan ) )
                    {
                        ch = chPointMan;
                        j++;
                        intConst[j] = ch;
                        chPointMan = fgetc( psiPtr );
                    }
                    ch = chPointMan;
                    if ( j > 9 )
                    {
                        fprintf( lexPtr, "%s\n", error2 );
                    }
                    else
                    {
                        fprintf( lexPtr, "IntConst(%s)\n", intConst );
                    }
                    j = 0;
                }
                if ( ch == '+' || ch == '-' || ch == '*' || ch == '/' || ch == ':' || ch == '=' )
                {
                    opertr[k] = ch;
                    chPointMan = fgetc( psiPtr );

                    while ( chPointMan == '+' || chPointMan == '-' || chPointMan == '*' || chPointMan == '/' || chPointMan == ':' || chPointMan == '=' )
                    {
                        ch = chPointMan;
                        k++;
                        opertr[k] = ch;
                        chPointMan = fgetc( psiPtr );
                    }
                    ch = chPointMan;
                    if ( k > 1 )
                    {
                        fprintf( lexPtr, "%s\n", error3 );
                    }
                    else if ( k == 1 )
                    {
                        if ( opertr[0] == '+' && opertr[1] == '+' )
                        {
                            fprintf( lexPtr, "Operator(%s)\n", opertr );
                        }
                        else if ( opertr[0] == '-' && opertr[1] == '-' )
                        {
                            fprintf( lexPtr, "Operator(%s)\n", opertr );
                        }
                        else if ( opertr[0] == ':' && opertr[1] == '=' )
                        {
                            fprintf( lexPtr, "Operator(%s)\n", opertr );
                        }
                        else
                        {
                            fprintf( lexPtr, "%s\n", error3 );
                        }
                    }
                    else
                    {
                        if ( opertr[0] == ':' || opertr[0] == '=' )
                        {
                            fprintf( lexPtr, "%s\n", error3 );
                        }
                        else
                        {
                            fprintf( lexPtr, "Operator(%s)\n", opertr );
                        }
                    }
                    k = 0;
                    for ( int a = 0; a < 2; a++ )
                        opertr[a] = '\0';
                }
                if ( ch == '(' || ch == ')' || ch == '[' || ch == ']' || ch == '{' || ch == '}' )
                {
                    if ( ch == '(' )
                    {
                        ch = fgetc( psiPtr );
                        if ( ch == '*' )
                        {
                            ch = fgetc( psiPtr );
                            while ( true )
                            {
                                if ( ch == EOF )
                                {
                                    fprintf( lexPtr, "%s\n", error4 );
                                    break;
                                }
                                chPointMan = fgetc( psiPtr );
                                if ( ch == '*' && chPointMan == ')' )
                                {
                                    ch = fgetc( psiPtr );
                                    break;
                                }
                                ch = chPointMan;
                            }
                        }


                        else
                        {

                            fprintf( lexPtr, "%s\n", lPar );

                        }
                    }
                    else if ( ch == ')' )
                    {
                        fprintf( lexPtr, "%s\n", rPar );
                        ch = fgetc( psiPtr );
                    }
                    else if ( ch == '[' )
                    {
                        fprintf( lexPtr, "%s\n", lSBracket );
                        ch = fgetc( psiPtr );
                    }
                    else if ( ch == ']' )
                    {
                        fprintf( lexPtr, "&s\n", rSBracket );
                        ch = fgetc( psiPtr );
                    }
                    else if ( ch == '{' )
                    {
                        fprintf( lexPtr, "%s\n", lCBracket );
                        ch = fgetc( psiPtr );
                    }
                    else
                    {
                        fprintf( lexPtr, "%s\n", rCBracket );
                        ch = fgetc( psiPtr );
                    }
                }
                if ( ch == '"' )
                {
                    while ( ( chPointMan = fgetc( psiPtr ) ) != '"' )
                    {
                        if ( chPointMan == '\0' )
                        {
                            fprintf( lexPtr, "%s\n", error5 );
                            break;
                        }
                    }
                    ch = chPointMan;
                }
                if ( ch == ';' )
                {
                    fprintf( lexPtr, "%s\n", eOfLine );
                    ch = fgetc( psiPtr );
                }
                if ( isspace( ch ) )
                {
                    ch = fgetc( psiPtr );
                }
            }
            fclose( lexPtr );
        }
        fclose( psiPtr );
    }
    return 0;
}
