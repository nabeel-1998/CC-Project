using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            "For", "Identifier", "Open_parenthesis", "Close_parenthesis", "Data_type", "Assignment_operator","Less_equal_operator", "Greater_equal_operater", "Not_equal_operator",
        "Equality_operator", "great_then_operator", "less_then_operator", "Constant", "Terminator", "Increment_operator", "Decrement_Operator",
        "Assignment_incrementOperator", "Assignment_decrementoperator", "Assign_multiplyoperator", "Assign_divideoperator", "Open_kurli_brac",
        "Close_kurli_braces","Unidentified_Token"
        };
        List<Token> TokenList = new List<Token>();
        string SourceCode;
        string sourceCodeCopy;
        int[] TokenCountHolderArray = new int[22];
        Stack<char> LexemeStack = new Stack<char>();
        public Tokenizer(string SourceCode)
        {

            this.SourceCode = SourceCode;
            sourceCodeCopy = SourceCode;


        }

        public void TryTokenize()
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
                    foreach (var item in LexemeStack)
                    {
                        token.Value = token.Value + LexemeStack.Pop();
                    }

                }
                else
                {
                    token = new Token();
                    token.TokenType = TokenTypes[ListOfIndexes.Min()];
                    foreach (var item in LexemeStack)
                    {
                        token.Value = token.Value + LexemeStack.Pop();
                    }
                }
                TokenList.Add(token);


            }


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

            bool CharConsumeflag = false;
            var CodeArray = SourceCode.ToCharArray();
            var UnsupportedCharacter = "@#&?,/|^+-*!$-`~:\".";
            //code to remove pre-occurance of whitespace or line
            int i = 0;
            while (CodeArray[i] == ' ' || CodeArray[i] == '\n' || CodeArray[i] == '\t')
            {
                SourceCode = SourceCode.Substring(1);
                i++;
            } //

            CodeArray = SourceCode.ToCharArray();
            string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_";
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

                State28();
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
                TokenCountHolderArray[Array.IndexOf(TokenTypes, "Open_kurli_brac")] += 1;
                State34();
            }

            if (CodeArray[0] == '}')
            {
                if (!CharConsumeflag)
                {
                    MoveNext();
                    CharConsumeflag = true;
                }
                TokenCountHolderArray[Array.IndexOf(TokenTypes, "Close_kurli_braces")] += 1;
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

        private void State42()
        {
            throw new NotImplementedException();
        }

        private void State40()
        {
            throw new NotImplementedException();
        }

        private void State39()
        {
            throw new NotImplementedException();
        }

        private void State36()
        {
            throw new NotImplementedException();
        }

        private void State35()
        {
            throw new NotImplementedException();
        }

        private void State34()
        {
            throw new NotImplementedException();
        }

        private void State33()
        {
            throw new NotImplementedException();
        }

        private void State32()
        {
            throw new NotImplementedException();
        }

        private void State28()
        {
            throw new NotImplementedException();
        }

        private void State26()
        {
            throw new NotImplementedException();
        }

        private void State24()
        {
            throw new NotImplementedException();
        }

        private void State18()
        {

        }

        private void State15()
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

        private void State16()
        {
            return;
        }

        private void State17()
        {
            return;
        }

        private void State12()
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
                State6();
            }
            if (CodeArray[0] == '=')
            {
                if (!CharConsumeFlag)
                {
                    MoveNext();
                    CharConsumeFlag = true;
                }
                TokenCountHolderArray[Array.IndexOf(TokenTypes, "Assignment_incrementOperator")] += 2;
                State8();
            }
        }

        private void State5()
        {
            bool CharConsumeFlag = false;
            var CodeArray = SourceCode.ToCharArray();

            if (CodeArray[0] == 'o')
            {
                if (!CharConsumeFlag)
                {
                    MoveNext();
                    CharConsumeFlag = true;
                }
                State6();
            }
            if (CodeArray[0] == 'l')
            {
                if (!CharConsumeFlag)
                {
                    MoveNext();
                    CharConsumeFlag = true;
                }
                State8();
            }

        }

        private void State8()
        {
            return;
        }

        private void State6()
        {
            return;
        }

        private void State4()
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

        private void State3()
        {
            return;
        }

        public string MoveNext()
        {
            LexemeStack.Push(SourceCode.ToCharArray()[0]);
            string remaining_lexeme = SourceCode.Substring(1);
            return remaining_lexeme;


        }
        private void State2()
        {
            bool CharConsumeFlag = false;
            string AlphaNumericCombo = "_0123456789abcdefghijjklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

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
