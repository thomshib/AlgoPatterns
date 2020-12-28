using System;
using System.Collections.Generic;

namespace DataStrcutures{

    public enum HeapType{
        Min, 
        Max
    }

class Heap<T> where T:IComparable<T>{

    List<T> elements;
    HeapType _type;
   
   

    public Heap(HeapType type)
    {
        this._type = type;
        this.elements = new List<T>();

    }

    

    public int GetSize(){
        return this.elements.Count;
    }

    public void Add(T item){

        this.elements.Add(item);
        this.BubbleUp(elements.Count - 1);

    }

        private void BubbleUp(int index)
        {
           int parent = GetParent(index);
           if( parent >= 0 && LessOrMore(parent,index) ){
               var temp = elements[parent];
               elements[parent] = elements[index];
               elements[index] = temp;
               this.BubbleUp(parent);

           }
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

          public T Peek(){

            if(elements.Count > 0){
                T item = elements[0];
               
                return item;
            }
            throw new InvalidOperationException("No elements in heap");
        }


        private void BubbleDown(int index)
        {
           int smallest = index;
           int left = GetLeft(index);
           int right = GetRight(index);

           if( left < elements.Count && LessOrMore(index,left) ){
               smallest = left;
           }

            if( right < elements.Count && LessOrMore(smallest,right) ){
               smallest = right;
           }

           if(index != smallest){
               var temp = elements[index];
               elements[index] = elements[smallest];
               elements[smallest] = temp;
               this.BubbleDown(smallest);
           }


        }

        private int GetLeft(int index)
        {
            return 2 * index + 1;
        }

        private int GetRight(int index)
        {
           return 2 * index + 2;
        }

        private int GetParent(int index)
        {
            if( index <= 0) return -1;

            return (index - 1) / 2;
        }

        private bool LessOrMore(int i, int j){
            //max less
            //min more

            if(_type == HeapType.Max)  return elements[i].CompareTo(elements[j]) < 0 ;
            else return elements[i].CompareTo(elements[j]) > 0;
        }

        public List<T> Elements{
            get{
                return elements;
            }
        }
    }



}