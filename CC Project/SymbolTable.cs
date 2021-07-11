using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC_Project
{
    class Symbol
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }


    class SymbolTable
    {
        List<Symbol> SymbolTableRecords = new List<Symbol>();
        public bool Lookup(string Identifier)
        {
            foreach (var item in SymbolTableRecords)
            {
                if (item.Value == Identifier)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Insert(string identifier, string Data_Type)
        {
            foreach(var item in SymbolTableRecords)
            {
                if(item.Value==identifier)
                {
                    return false;
                }
            }
            SymbolTableRecords.Add(new Symbol { Id = SymbolTableRecords.Count() + 1, Value = identifier, Type = Data_Type });
            return true;
            
        }

        public List<Symbol> FindAndInsert(List<Token> tokenList)
        {
            for(int i=1; i<tokenList.Count; i++)
            {
                if(tokenList[i].TokenType== "identifier")
                {
                    if(tokenList[i-1].TokenType== "data_type")
                    {
                        Insert(tokenList[i].Value, tokenList[i - 1].Value);
                    }
                }
            }
            return SymbolTableRecords;
        }
    }
}
