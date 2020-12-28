public class AverageOfSubarrayOfSizeK{

    public static double[] findAverages(int K, int[] array){

        double[] result = new double[array.Length - K + 1];

        double windowSum = 0;
        int windowStart = 0;

        for(int windowEnd = 0; windowEnd < array.Length; windowEnd++){

            //add the next element
            windowSum += array[windowEnd];
            //slide the window when we have K elements
            if( windowEnd >= K - 1){
                result[windowStart] = windowSum / K;
                //remove the outgoing element
                windowSum -= array[windowStart];
                //slide the window
                windowStart++;
            }
        }


        return result;

    }
}