using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_Project
{


    public class Token
    {

        public string TokenType { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return string.Format(@"<'{0}',{1}>", Value, TokenType);
        }
    }
    class Tokenizer
    {
        /**
         * Implementing DFA for identifying Tokens of "For Loop" Construct 
         **/
        public string[] TokenTypes =
        {
            "For",
            "Data_type", 
            "Identifier", 
            "Open_parenthesis",
            "Close_parenthesis",  
            "Assignment_operator",
            "Less_equal_operator", 
            "Greater_equal_operater", 
            "Not_equal_operator",
            "Equality_operator", 
            "great_then_operator",
            "less_then_operator",
            "Constant",
            "Terminator", 
            "Increment_operator",
            "Decrement_Operator",
            "Assignment_incrementOperator",
            "Assignment_decrementoperator", 
            "Assign_multiplyoperator",
            "Assign_divideoperator", 
            "Open_kurli_brace",
            "Close_kurli_brace",
            "Unidentified_Token"
        };
        List<Token> TokenList = new List<Token>();
        string SourceCode;
        int[] TokenCountHolderArray = new int[23];
        Stack<char> LexemeStack = new Stack<char>();
        public Tokenizer(string SourceCode)
        {
            this.SourceCode = SourceCode;
        }
        
        public bool IsSourceCodeEmpty()
        {
            if(string.IsNullOrEmpty(SourceCode))
            {
                return true;
            }
            return false;
        }

        Stack<char> tempStack = new Stack<char>();
        public List<Token> TryTokenize()
        {
            Token token;

            while (!string.IsNullOrEmpty(SourceCode))
            {

                StartState();
                int MaximumCount = TokenCountHolderArray.Max();
                List<int> ListOfIndexes = new List<int>();
                for (int i = 0; i < TokenCountHolderArray.Length; i++)
                {
                    if (TokenCountHolderArray[i] == MaximumCount && TokenCountHolderArray[i] != 0)
                    {
                        ListOfIndexes.Add(i);
                    }
                }
                if (ListOfIndexes.Count > 1)
                {

                    token = new Token();
                    token.TokenType = TokenTypes[ListOfIndexes.Min()];
                    for (int i=LexemeStack.Count(); i>0; i--)
                    {
                        tempStack.Push(LexemeStack.Pop());
                    }

                }
                else if(ListOfIndexes.Count==0)
                {
                    token = new Token();
                }
                else
                {
                    token = new Token();
                    token.TokenType = TokenTypes[ListOfIndexes.Min()];
                    for (int i = LexemeStack.Count(); i > 0; i--)
                    {
                        tempStack.Push(LexemeStack.Pop());
                    }
                }
                for(int i=tempStack.Count(); i>0; i--)
                {
                    token.Value += tempStack.Pop();
                }
                //Clearing the stack and Token count holder and adding token to the list
                LexemeStack.Clear();
                if(token!=null)
                TokenList.Add(token);
                for(int i=0; i<TokenCountHolderArray.Length; i++)
                {
                    TokenCountHolderArray[i] = 0;
                }
                //
            }
            return TokenList;

        }

        private void StartState()
        {
            /**
             * 1. To check for whitespace and remove it from first
             * 2. Check for first character and apply all the condition
             * 3. when Condition matches, incrment the tokencountholderarry respective index or indexes except inputs the take more than 1 characters
             * 3. remove the letter from sourcecode, and the letter to lexemestack
             * 4. call the respected next state or states
             **/

            if(!IsSourceCodeEmpty())
            {
                bool CharConsumeflag = false;
                var CodeArray = SourceCode.ToCharArray();
                var UnsupportedCharacter = "@#&?,/|^+[]-*!$-`~:\".";
                //code to remove pre-occurance of whitespace or line
                int i = 0;
                try
                {
                    while (CodeArray[i] == ' ' || CodeArray[i] == '\n' || CodeArray[i] == '\t')
                    {
                        SourceCode = SourceCode.Substring(1);
                        i++;
                        if(IsSourceCodeEmpty())
                        {
                            break;
                        }

                    } //
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
                if(!IsSourceCodeEmpty())
                {
                    CodeArray = SourceCode.ToCharArray();
                    string Letters = "abceghjklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";
                    string Numbers = "123456789";
                    if (Letters.Contains(CodeArray[0]))
                    {
                        if (!CharConsumeflag)
                        {
                            string a = MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                        State2();
                    }
                    if (CodeArray[0] == '0')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Constant")] += 1;
                        State3();
                    }
                    if (Numbers.Contains(CodeArray[0]))
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Constant")] += 1;
                        State4();
                    }
                    if (CodeArray[0] == 'f')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        //Increment will be on final state of "For";
                        //TokenCountHolderArray[Array.IndexOf(TokenTypes, "For")] += 1;
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                        State5();
                    }

                    if (CodeArray[0] == '+')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        //Increment on final state of ++ or +=
                        State12();
                    }

                    if (CodeArray[0] == '-')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        //Increment on final state of -- or -=
                        State15();
                    }

                    if (CodeArray[0] == 'd')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        //Increment on final state of double
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                        State18();
                    }


                    if (CodeArray[0] == '>')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "great_then_operator")] += 1;
                        State24();
                    }

                    if (CodeArray[0] == '<')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "less_then_operator")] += 1;
                        State26();
                    }

                    if (CodeArray[0] == '/')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }

                        State28();
                    }

                    if (CodeArray[0] == '*')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }

                        State30();
                    }

                    if (CodeArray[0] == '(')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Open_parenthesis")] += 1;
                        State32();
                    }

                    if (CodeArray[0] == ')')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Close_parenthesis")] += 1;
                        State33();
                    }

                    if (CodeArray[0] == '{')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Open_kurli_brace")] += 1;
                        State34();
                    }

                    if (CodeArray[0] == '}')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Close_kurli_brace")] += 1;
                        State35();
                    }

                    if (CodeArray[0] == 'i')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        //increment will be done on final state of Int
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                        State36();
                    }

                    if (CodeArray[0] == ';')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }

                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Terminator")] += 1;
                        State39();
                    }

                    if (CodeArray[0] == '=')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Assignment_operator")] += 1;
                        State40();
                    }

                    if (UnsupportedCharacter.Contains(CodeArray[0]))
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        TokenCountHolderArray[Array.IndexOf(TokenTypes, "Unidentified_Token")] += 1;
                    }
                    if (CodeArray[0] == '!')
                    {
                        if (!CharConsumeflag)
                        {
                            MoveNext();
                            CharConsumeflag = true;
                        }
                        //increment will be done on final state of !=
                        State42();
                    }
                }
               
            }
        }

        private void State30()
        {
            if(!IsSourceCodeEmpty())
            {
                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Assign_multiplyoperator")] += 2;
                }
            }
        }

        private void State42()
        {
            if (!IsSourceCodeEmpty())
            {
                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Not_equal_operator")] += 2;
                }
            }
            
        }

        private void State40()
        {
            if (!IsSourceCodeEmpty())
            {
                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Equality_operator")] += 2;
                }
            }
            
        }

        private void State39()
        {
            if (!IsSourceCodeEmpty())
            {
                //yhan code ni 
                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Equality_operator")] += 2;
                }
            }
            return;
        }

        private void State36()
        {
            if (!IsSourceCodeEmpty())
            {


                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == 'n')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State37();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }

        private void State37()
        {
            if (!IsSourceCodeEmpty())
            {


                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == 't')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Data_type")] += 3;
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State7();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State35()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        private void State34()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        private void State33()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        private void State32()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        private void State28()
        {
            if (!IsSourceCodeEmpty())
            {
                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Assign_divideoperator")] += 2;
                }
            }
        }
        private void State26()
        {
            if (!IsSourceCodeEmpty())
            {


                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Less_equal_operator")] += 2;
                }
            }
        }
        private void State24()
        {
            if (!IsSourceCodeEmpty())
            {


                var CodeArray = SourceCode.ToCharArray();
                if (CodeArray[0] == '=')
                {
                    MoveNext();
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Greater_equal_operater")] += 2;
                }

            }
        }
        private void State18()
        {
            if (!IsSourceCodeEmpty())
            {


                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz0123456789";
                if (CodeArray[0] == 'o')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State19();
                }
                if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }

            }
        }
        private void State19()
        {
            if (!IsSourceCodeEmpty())
            {


                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstvwxyz0123456789";
                if (CodeArray[0] == 'u')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State20();
                }
                if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State20()
        {
            if (!IsSourceCodeEmpty())
            {


                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZacdefghijklmnopqrstuvwxyz0123456789";
                if (CodeArray[0] == 'b')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State21();
                }
                if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State21()
        {
            if (!IsSourceCodeEmpty())
            {


                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
                if (CodeArray[0] == 'l')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State22();
                }
                if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State22()
        {
            if (!IsSourceCodeEmpty())
            {


                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdfghijklmnopqrstuvwxyz0123456789";
                if (CodeArray[0] == 'e')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Data_type")] += 6;
                    State7();
                }
                if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State15()
        {
            if (!IsSourceCodeEmpty())
            {


                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == '-')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Decrement_Operator")] += 2;
                    State17();
                }
                if (CodeArray[0] == '=')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Assignment_decrementoperator")] += 2;
                    State16();
                }
            }
        }
        private void State16()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        private void State17()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        private void State12()
        {
            if (!IsSourceCodeEmpty())
            {



                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == '+')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Increment_operator")] += 2;

                }
                if (CodeArray[0] == '=')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Assignment_incrementOperator")] += 2;

                }
            }
        }


        private void State5()
        {
            if (!IsSourceCodeEmpty())
            {
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz0123456789";

                if (CodeArray[0] == 'o')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State6();
                }
                else if (CodeArray[0] == 'l')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State8();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }

            }
        }
        private void State8()
        {
            if (!IsSourceCodeEmpty())
            {

                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == 'o')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State9();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }

        private void State9()
        {
            if (!IsSourceCodeEmpty())
            {

                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZbcdefghijklmnopqrstuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == 'a')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State10();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }

        }
        private void State10()
        {
            if (!IsSourceCodeEmpty())
            {

                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrsuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == 't')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Data_type")] += 5;
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State7();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State6()
        {
            if (!IsSourceCodeEmpty())
            {

                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqstuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();

                if (CodeArray[0] == 'r')
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "For")] += 3;
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State7();
                }
                else if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        //Pre_Finalization State for keywords
        private void State7()
        {
            if (!IsSourceCodeEmpty())
            {

                string IdentifierCharacters = "_ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                bool CharConsumeFlag = false;
                var CodeArray = SourceCode.ToCharArray();
                if (IdentifierCharacters.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }
            }
        }
        private void State4()
        {
            if (!IsSourceCodeEmpty())
            {

                bool CharConsumeFlag = false;
                String numbers = "0123456789";

                var CodeArray = SourceCode.ToCharArray();

                if (numbers.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Constant")] += 1;
                    State4();
                }
            }
        }
        private void State3()
        {
            if (!IsSourceCodeEmpty())
            {


                return;
            }
        }

        public string MoveNext()
        {
            LexemeStack.Push(SourceCode.ToCharArray()[0]);
            SourceCode = SourceCode.Substring(1);
            return SourceCode;


        }
        private void State2()
        {
            if (!IsSourceCodeEmpty())
            {

                bool CharConsumeFlag = false;
                string AlphaNumericCombo = "_0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

                var CodeArray = SourceCode.ToCharArray();

                if (AlphaNumericCombo.Contains(CodeArray[0]))
                {
                    if (!CharConsumeFlag)
                    {
                        MoveNext();
                        CharConsumeFlag = true;
                    }
                    TokenCountHolderArray[Array.IndexOf(TokenTypes, "Identifier")] += 1;
                    State2();
                }

            }
        }
    }
}
