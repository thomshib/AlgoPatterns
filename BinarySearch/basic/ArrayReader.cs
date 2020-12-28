namespace basic
{
    public class ArrayReader
    {
        int[] arr;
        public ArrayReader(int[] arr)
        {
            this.arr = arr;
        }

        public int get(int index){

            if(index >= arr.Length){
                return int.MaxValue;
            }

            return arr[index];
        }
    }
}