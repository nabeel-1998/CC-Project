using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_Project
{
    public class Sets 
    {
        public string NonTerminal { get; set; }
        public List<string> FirstSet = new List<string>();
        public List<string> FollowSet = new List<string>();
    }

    class production
    {
        public string NonTerminal { get; set; }

        public List<string> ProductionRule = new List<string>();
    }
    class FirstandFollowSet
    {

        /****CFG FOR "forloop" CONSTRUCT*****/
        //S -> H
        //H -> foropen_parenthesisFAH'
        //H' ->GU
        //H' ->U
        //U -> close_parenthesisopen_kurli_braceJclose_kurli_brace
        //A -> ICMterminator
        //F -> DIassignment_operatorMterminator
        //G -> IB
        //G -> IYM
        //G -> ɛ
        //J -> HJ'
        //J -> ɛ
        //J' -> JJ'
        //J' -> ɛ
        //C -> greater_equal_operater
        //C -> less_equal_operator
        //C -> not_equal_operator
        //C -> Equality_operator
        //C -> less_then_operator
        //C -> great_then_operator
        //C -> not_equal_operator
        //D -> data_type
        //I -> identifier
        //B -> increment_operator
        //B -> decrement_operator
        //Y -> assignment_incrementoperator
        //Y -> assignment_decrementoperator
        //Y -> assign_multiplyoperator
        //Y -> assign_divideoperator
        //M -> constant
        ///////////////////////////////////////////////////
        /*Our grammer has 15 NON-TERMINALS*/
        /*Our grammer has 30 Production Rules*/
        //Non terminals are S,H,H',U,A,F,G,J,J',C,D,I,B,Y,M
        

                                               //0    1    2     3    4    5    6   7     8     9    10   11  12   13    14
        string[] NON_TERMINALS = new string[] { "S", "H", "H'", "U", "A", "F", "G", "J", "J'", "C", "D", "I", "B", "Y", "M" };
        string[] TERMINALS = new string[] 
        { 
            "for",//0
            "data_type",
            "identifier",
            "open_parenthesis",
            "close_parenthesis", //4
            "assignment_operator",
            "less_equal_operator",
            "greater_equal_operater", //7
            "not_equal_operator",
            "equality_operator",
            "great_then_operator",
            "less_then_operator",
            "constant", //12
            "terminator",
            "increment_operator",
            "decrement_operator",
            "assignment_incrementoperator",
            "assignment_decrementoperator", //17
            "assign_multiplyoperator",
            "assign_divideoperator",
            "open_kurli_brace",
            "close_kurli_brace",
            "unidentified_Token",
            "ɛ"
        };
        List<Sets> FFSets;
        

        production[] Production = new production[30];

        string[] pRules = new string[] {
                "H",
                "for*open_parenthesis*F*A*H'",
                "G*U",
                "U",
                "close_parenthesis*open_kurli_brace*J*close_kurli_brace",
                "I*C*M*terminator",
                "D*I*assignment_operator*M*terminator",
                "I*B",
                "I*Y*M",
                "ɛ",
                "H*J'",
                "ɛ",
                "J*J'",
                "ɛ",
                "greater_equal_operater",
                "less_equal_operator",
                "not_equal_operator",
                "equality_operator",
                "less_then_operator",
                "great_then_operator",
                "not_equal_operator",
                "data_type",
                "identifier",
                "increment_operator",
                "decrement_operator",
                "assignment_incrementoperator",
                "assignment_decrementoperator",
                "assign_multiplyoperator",
                "assign_divideoperator",
                "constant"

        };



        public FirstandFollowSet()
        {
            FFSets = new List<Sets>();
                                          //0    1    2     3    4    5    6   7     8     9    10   11  12   13    14
            NON_TERMINALS = new string[] { "S", "H", "H'", "U", "A", "F", "G", "J", "J'", "C", "D", "I", "B", "Y", "M" };
            for (int i = 0; i < 15; i += 1)
            {
                FFSets.Add(new Sets { NonTerminal = NON_TERMINALS[i] });
            }

            Production[0] = new production { NonTerminal = "S", ProductionRule = pRules[0].Split('*').ToList() };
            Production[1] = new production { NonTerminal = "H", ProductionRule = pRules[1].Split('*').ToList() };
            Production[2] = new production { NonTerminal = "H'", ProductionRule = pRules[2].Split('*').ToList() };
            Production[3] = new production { NonTerminal = "H'", ProductionRule = pRules[3].Split('*').ToList() };
            Production[4] = new production { NonTerminal = "U", ProductionRule = pRules[4].Split('*').ToList() };
            Production[5] = new production { NonTerminal = "A", ProductionRule = pRules[5].Split('*').ToList() };
            Production[6] = new production { NonTerminal = "F", ProductionRule = pRules[6].Split('*').ToList() };
            Production[7] = new production { NonTerminal = "G", ProductionRule = pRules[7].Split('*').ToList() };
            Production[8] = new production { NonTerminal = "G", ProductionRule = pRules[8].Split('*').ToList() };
            Production[9] = new production { NonTerminal = "G", ProductionRule = pRules[9].Split('*').ToList() };
            Production[10] = new production { NonTerminal = "J", ProductionRule = pRules[10].Split('*').ToList() };
            Production[11] = new production { NonTerminal = "J", ProductionRule = pRules[11].Split('*').ToList() };
            Production[14] = new production { NonTerminal = "C", ProductionRule = pRules[14].Split('*').ToList() };
            Production[15] = new production { NonTerminal = "C", ProductionRule = pRules[15].Split('*').ToList() };
            Production[16] = new production { NonTerminal = "C", ProductionRule = pRules[16].Split('*').ToList() };
            Production[17] = new production { NonTerminal = "C", ProductionRule = pRules[17].Split('*').ToList() };
            Production[18] = new production { NonTerminal = "C", ProductionRule = pRules[18].Split('*').ToList() };
            Production[19] = new production { NonTerminal = "C", ProductionRule = pRules[19].Split('*').ToList() };
            Production[20] = new production { NonTerminal = "C", ProductionRule = pRules[20].Split('*').ToList() };
            Production[21] = new production { NonTerminal = "D", ProductionRule = pRules[21].Split('*').ToList() };
            Production[22] = new production { NonTerminal = "I", ProductionRule = pRules[22].Split('*').ToList() };
            Production[23] = new production { NonTerminal = "B", ProductionRule = pRules[23].Split('*').ToList() };
            Production[24] = new production { NonTerminal = "B", ProductionRule = pRules[24].Split('*').ToList() };
            Production[25] = new production { NonTerminal = "Y", ProductionRule = pRules[25].Split('*').ToList() };
            Production[26] = new production { NonTerminal = "Y", ProductionRule = pRules[26].Split('*').ToList() };
            Production[27] = new production { NonTerminal = "Y", ProductionRule = pRules[27].Split('*').ToList() };
            Production[28] = new production { NonTerminal = "Y", ProductionRule = pRules[28].Split('*').ToList() };
            Production[29] = new production { NonTerminal = "M", ProductionRule = pRules[29].Split('*').ToList() };
            Production[12] = new production { NonTerminal = "J'", ProductionRule = pRules[12].Split('*').ToList() };
            Production[13] = new production { NonTerminal = "J'", ProductionRule = pRules[13].Split('*').ToList() };

        }

        //check rule
        //first character is non terminal add to first set of the terminal

       public List<string> FindFirstSet(string Nonterminal)
        {

            List<string> firstSetString = new List<string>(); 
            for(int i=0; i<Production.Length; i++)
            {
                if(Production[i].NonTerminal==Nonterminal)
                {
                    if(TERMINALS.Contains(Production[i].ProductionRule[0]))
                    {
                        if(!firstSetString.Contains(Production[i].ProductionRule[0]))
                        {
                            firstSetString.Add(Production[i].ProductionRule[0]);
                        }
                        
                    }
                    else
                    {
                        var moreList = FindFirstSet(Production[i].ProductionRule[0]);
                        foreach(string item in moreList)
                        {
                            firstSetString.Add(item);
                        }
                    }
                    
                }
            }
            return firstSetString;
        }

        public async Task<List<Sets>> findfinalfirstset()
        {
            await Task.Run(() => 
            {
                foreach (var item in NON_TERMINALS)
                {
                    var list = FindFirstSet(item);
                    var followlist = FindFollowSet(item);
                    var Tobject = FFSets.FirstOrDefault(x => x.NonTerminal == item);
                    if (Tobject != null)
                    {
                        Tobject.FirstSet = list;
                        Tobject.FollowSet = followlist;
                    }
                    else
                    {
                        Sets set = new Sets() { NonTerminal = item, FirstSet = list};
                        FFSets.Add(set);
                    }

                }



                return FFSets;
            });

            return FFSets;
        }

        public List<String> FindFollowSet(string Non_Terminal)
        {
            List<string> followSetList = new List<string>();
            if (Non_Terminal == "S")
            {
                if (!followSetList.Contains("$"))
                {
                    followSetList.Add("$");
                }

            }
            for (int i = 0; i < Production.Length; i++)
            {
                for (int j = 0; j < Production[i].ProductionRule.Count; j++)
                {
                    if (Production[i].ProductionRule[j] == Non_Terminal)
                    {
                        if (j == Production[i].ProductionRule.Count - 1)
                        {
                            var RightFollowlist = FindFollowSet(Production[i].NonTerminal);
                            foreach (var item in RightFollowlist)
                            {
                                followSetList.Add(item);
                            }
                        }
                        else if (TERMINALS.Contains(Production[i].ProductionRule[j + 1]))
                        {

                            if (!followSetList.Contains(Production[i].ProductionRule[j + 1]))
                            {
                                followSetList.Add(Production[i].ProductionRule[j + 1]);
                            }
                        }
                        else
                        {

                            int m = 1;
                            while (FindFirstSet(Production[i].ProductionRule[j + m]).Contains("ɛ"))
                            {
                                var firstsetList = FindFirstSet(Production[i].ProductionRule[j + m]);
                                firstsetList.Remove("ɛ");
                                foreach (var item in firstsetList)
                                {
                                    if (!followSetList.Contains(item))
                                    {
                                        followSetList.Add(item);
                                    }

                                }
                                if (j + m + 1 >= Production[i].ProductionRule.Count)
                                {
                                    var rightruleList = FindFollowSet(Production[i].NonTerminal);
                                    foreach (var item in rightruleList)
                                    {
                                        if (!followSetList.Contains(item))
                                        {
                                            followSetList.Add(item);
                                        }
                                    }
                                    break;
                                }
                                else
                                {
                                    m++;
                                }

                            }


                        }

                    }

                }
            }

            return followSetList;
        }



    }
}
