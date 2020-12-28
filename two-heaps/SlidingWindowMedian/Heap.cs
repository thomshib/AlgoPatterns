using System;
using System.Collections.Generic;

namespace DataStructures{


    public enum HeapType{
        Min,
        Max
    }
    class Heap<T> where T:IComparable<T>{

        List<T> elements;
        HeapType _type;
        public Heap(HeapType type)
        {
            _type = type;
            elements = new List<T>();
        }

        public int GetSize(){
            return elements.Count;
        }

        public void Add(T item){
            elements.Add(item);
            this.BubbleUp(elements.Count - 1);
        }

        public bool IsEmpty(){
            return elements.Count == 0;
        }

        public T Pop(){

            if(!IsEmpty()){

                T item = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                this.BubbleDown(0);

                return item;

            }

            throw new InvalidOperationException(" no elements in heap");
        }

         public T Peek(){

            if(!IsEmpty()){

                T item = elements[0];
               

                return item;

            }

            throw new InvalidOperationException(" no elements in heap");
        }

        private void BubbleDown(int index)
        {
            var smallest = index;
            var left = GetLeft(index);
            var right = GetRight(index);

            if(left < elements.Count &&  LessorMore(index, left) ){
                smallest = left;
            }

            if(right < elements.Count && LessorMore(smallest, right)) {
                smallest = right;
            }

            if(smallest != index){
                var temp = elements[index];
                elements[index] = elements[smallest];
                elements[smallest] = temp;
                this.BubbleUp(smallest);
            }
        }

        private int GetRight(int index)
        {
            return index * 2 + 2;
        }

        private int GetLeft(int index)
        {
             return index * 2 + 1;
        }

        private void BubbleUp(int index)
        {
            int parent = GetParent(index);
            if(parent >=0 && LessorMore(parent,index)){
                var temp = elements[index];
                elements[index] = elements[parent];
                elements[parent] = temp;
                this.BubbleUp(parent);
            }
        }

        private bool LessorMore(int i, int j){
            // type max - less
            //type min - more

            if ( _type == HeapType.Max)  return elements[i].CompareTo(elements[j]) < 0 ;
            else                         return elements[i].CompareTo(elements[j]) > 0;

            
        }

        private int GetParent(int index)
        {
            if(index <= 0) return -1;

            return (index - 1) / 2;
        }
    }
}