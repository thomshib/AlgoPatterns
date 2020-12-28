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
        elements = new List<T>();
        _type = type;

    }


        public int GetSize(){
            return this.elements.Count;
        }

        public void Add(T item){

            elements.Add(item);
            this.BubbleUp(elements.Count - 1);
        }

        public T Pop(){

            if(elements.Count > 0){

                T item = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                this.BubbleDown(0);
                return item;

            }

            throw new InvalidOperationException("No elements in heap");
        }

        private void BubbleDown(int index)
        {
            int smallest = index;
            int left = GetLeft(index);
            int right = GetRight(index);

            if(left < elements.Count && LessOrMore(index, left)){
                smallest = left;
            }

            if(right < elements.Count && LessOrMore(smallest,right)){
                smallest = right;
            }

            if(smallest != index){
                var temp = elements[smallest];
                elements[smallest] = elements[index];
                elements[index] = temp;
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
            int parent = GettParent(index);

            if( parent >=0  &&  LessOrMore(parent,index) ){
                var temp = elements[parent];
                elements[parent] = elements[index];
                elements[index] = temp;
                this.BubbleUp(parent);
            } 
        }

        private bool LessOrMore(int i, int j){
            //Max less; min more

            if(_type == HeapType.Max) return elements[i].CompareTo(elements[j]) < 0;
                return elements[i].CompareTo(elements[j]) > 0;
        }

        private int GettParent(int index)
        {
            if(index <=0 ) return -1;

            return (index - 1) / 2;
        }
    }




}