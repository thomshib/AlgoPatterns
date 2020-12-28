using System;

namespace BackspaceCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(compare("xy#z", "xzz#"));
        }

         public static bool compare(String source, String target) {

             int sourceIndex = source.Length - 1;
             int targetIndex = target.Length - 1;

             while(sourceIndex >= 0 || targetIndex >= 0){
                 
                 int sourceNextIndex = getNextValidCharIndex(source,sourceIndex);
                 int targetNextIndex = getNextValidCharIndex(target, targetIndex);

                 if(sourceNextIndex < 0 && targetNextIndex < 0 ) { //reached the end
                    return true;
                 }

                if(sourceNextIndex < 0 || targetNextIndex < 0 ) { //one reached the end
                    return false;
                 }

                if(source[sourceNextIndex] !=  target[targetNextIndex]) { 
                    return false;
                 }

                sourceIndex = sourceNextIndex - 1;
                targetIndex = targetNextIndex - 1;

             }

             return true;


         }

         public static int getNextValidCharIndex(String input, int index){
             int backspaceCount = 0;
             while(index >=0 ){
                 if(input[index] == '#'){
                     backspaceCount++;
                 }else if(backspaceCount > 0){
                     backspaceCount--; //skip the char next to backspace char
                 }else{
                     break;
                 }
                 index--;
             }

             return index;
         }
    }
}
