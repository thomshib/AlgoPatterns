using System;
using System.Collections.Generic;

namespace EvaluateExpression
{
    class Program
    {
        private static Dictionary<string,List<int>> map;
        static void Main(string[] args)
        {
                map = new Dictionary<string, List<int>>();
                var result = EvaluateExpression("1+2*3");

                result.ForEach(Console.WriteLine);

        }

        public static List<int> EvaluateExpression(String input){

            if(map.ContainsKey(input)){
                return map[input];
            }

            List<int> result = new List<int>();

            //base case; if the input contains digits only;
            if( !input.Contains("*") && !input.Contains("+") && !input.Contains("-")){
                result.Add(int.Parse(input));
            }else{

                for(int i = 0; i < input.Length; i++){
                    var character = input[i];

                    if(!char.IsDigit(character)){
                        //break into two parts and make recucrsive calls

                        var leftParts = EvaluateExpression(input.Substring(0, i));
                        var rightParts  = EvaluateExpression(input.Substring(i+1));

                        foreach(int part1 in leftParts){
                            foreach(int part2 in rightParts){
                                if(character == '+'){
                                    result.Add(part1 + part2);
                                }else if(character == '-'){
                                    result.Add(part1 - part2);
                                }else if(character == '*'){
                                    result.Add(part1 * part2);
                                }   


                            }
                        }   

                }
            
            }
        }

        if(!map.ContainsKey(input)){
            map.Add(input,result);
        }

        return result;


    }


    }

}

    