using System;
using System.Collections.Generic;

namespace GenerateParentheses
{

    class ParenthesisString{
        public int openCount;
        public int closeCount;
        public string value;

        public ParenthesisString(string input, int openCount, int closeCount)
        {
            this.value = input;
            this.openCount = openCount;
            this.closeCount = closeCount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           var result = generateValidParentheses(3);
           foreach(var item in result){
               Console.WriteLine(item);
           }
        }

        public static List<String> generateValidParentheses(int num) {
            List<String> result = new  List<String>();
            
            ParenthesisString pString = new ParenthesisString("",0,0);
            Queue<ParenthesisString> queue = new Queue<ParenthesisString>();

            queue.Enqueue(pString);

            while(queue.Count > 0){
                var ps = queue.Dequeue();

                //if we reached the max of open anc closed bracked add to the result
                if(ps.openCount == num && ps.closeCount == num){
                    result.Add(ps.value);
                }else{
                    if(ps.openCount < num){
                        //we can add open bracket
                        queue.Enqueue(new ParenthesisString(ps.value + "(", ps.openCount + 1, ps.closeCount));
                    }

                    if(ps.closeCount < ps.openCount){
                        //we can add close brackt
                        queue.Enqueue(new ParenthesisString(ps.value +")",ps.openCount, ps.closeCount + 1));
                    }

                }
            }
        

            return result;
        }
    }
}
