using System;

public class MinSubArraySum{

    public static int findArraySum(int K, int[] array){
        int result = int.MaxValue;
        int windowStart = 0;
        int sum = 0;
        
        for(int windowEnd = 0; windowEnd < array.Length; windowEnd++){
            //add the next element
            sum += array[windowEnd];

            //try to shrink the window
            while(sum >= K){
              result  =  Math.Min( result, windowEnd - windowStart + 1);
              //substract the element going out
              sum -= array[windowStart];
              windowStart++; //slide the window ahead
              
            }

           

        }


        return result == int.MaxValue ? 0 : result;  
    

    }
}