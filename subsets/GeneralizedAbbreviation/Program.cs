using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralizedAbbreviation
{

    class AbbreviatedWord{
        public StringBuilder value;
        public int count;
        public int index;

        public AbbreviatedWord(StringBuilder value, int index, int count)
        {
            this.value = value;
            this.count = count;
            this.index = index;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<String> result = generateGeneralizedAbbreviation("BAT");
            foreach(var item in result){
                Console.WriteLine(item);
            }
        }

        public static List<String> generateGeneralizedAbbreviation(String word) {

            int wordLength = word.Length;

            List<string> result = new List<string>();

            Queue<AbbreviatedWord> queue = new Queue<AbbreviatedWord>();
            queue.Enqueue(new AbbreviatedWord(new StringBuilder(),0,0));

            while(queue.Count > 0){
                var abWord = queue.Dequeue();

                if(abWord.index == wordLength){
                    if(abWord.count != 0){
                        abWord.value.Append(abWord.count);
                    }
                    result.Add(abWord.value.ToString());
                }else{
                        //continue abbreviating
                        queue.Enqueue(
                            new AbbreviatedWord(
                                new StringBuilder(abWord.value.ToString()),abWord.index + 1, abWord.count + 1)
                        );
                        
                        //restart; add the count and the new char

                        if(abWord.count != 0){
                            abWord.value.Append(abWord.count);
                        }

                        queue.Enqueue(
                            new AbbreviatedWord(new StringBuilder(abWord.value.ToString()).Append(word[abWord.index]), abWord.index + 1, 0)
                

                        );


                }

            }

            return result;
            

        }
    }
}
