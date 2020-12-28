using System;
using System.Collections.Generic;

namespace DataStructures{

    public enum HeapType    {Max, Min}

    public class Heap<T> where T:IComparable<T>{

        List<T> elements = new List<T>();
        HeapType _type;



        public Heap(HeapType type)
        {
            this._type = type;
        }
        public int GetSize(){
            return elements.Count;
        }

        public bool IsEmpty(){
            return elements.Count == 0;
        }

        public void Add(T item){

            elements.Add(item);

            this.BubbleUp(elements.Count - 1);

        }

        public T Pop(){
            if(elements.Count > 0){

                var item = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                this.BubbleDown(0);
                return item;


            }

            throw new ArgumentException("no elements in heap");
        }

          public T Peek(){
            if(elements.Count > 0){

                var item = elements[0];
                
                return item;


            }

            throw new ArgumentException("no elements in heap");
        }

        private void BubbleDown(int index)
        {
            int smallest = index;
            int left = GetLeft(index);
            int right = GetRight(index);

            // if(left < elements.Count && elements[index].CompareTo(elements[left]) > 0){
            //     smallest = left;
            // }

            //  if(right < elements.Count && elements[smallest].CompareTo(elements[right]) > 0){
            //     smallest = right;
            // }

             if(left < elements.Count && LessOrMore(index,left) ){
                smallest = left;
            }

             if(right < elements.Count && LessOrMore(smallest,right) ){
                smallest = right;
            }

            if(smallest != index){
                var temp = elements[index];
                elements[index] = elements[smallest];
                elements[smallest]  = temp;
                this.BubbleDown(smallest);
            }

        }

         private bool LessOrMore(int i, int j)
            {
                if (_type == HeapType.Max)	return elements[i].CompareTo(elements[j]) < 0;    // Less
                else                        return elements[i].CompareTo(elements[j]) > 0;    // More
            }

        private int GetRight(int index)
        {
            return (index * 2) + 2;
        }

        private int GetLeft(int index)
        {
            return (index * 2) + 1;
        }

        private void BubbleUp(int index)
        {
            int parent = GetParent(index);

            // if(parent > 0 && elements[parent].CompareTo(elements[index]) > 0 ){
            //     var temp = elements[index];
            //     elements[index] = elements[parent];
            //     elements[parent] = temp;

            //     this.BubbleUp(parent);
            // }

             if(parent >= 0 &&  LessOrMore(parent,index)  ){
                var temp = elements[index];
                elements[index] = elements[parent];
                elements[parent] = temp;

                this.BubbleUp(parent);
            }
        }

        private int GetParent(int index)
        {
            if(index <= 0){
            
                return -1;

            }

            return (index - 1) / 2;
                
        }
    }


}