using System;
using System.Collections.Generic;

namespace DataStructures{

    public class Heap<T> where T: IComparable<T>{
        List<T> elements = new List<T>();

        public int GetSize(){
            return elements.Count;
        }

        public void Add(T item){
            elements.Add(item);
            this.BubbleUp(elements.Count - 1);
        }

         public T Peek(){
            if(elements.Count > 0){
                T item = elements[0];
                
                return item;
            }

            throw new InvalidOperationException("heap has no elements");
        }

        public T Pop(){
            if( elements.Count > 0 ){
                T item = elements[0];
                elements[0] = elements[elements.Count - 1];
                elements.RemoveAt(elements.Count - 1);
                this.BubbleDown(0);
                return item;
            }

            throw new InvalidOperationException(" no elements in heap");
        }

        private void BubbleDown(int index)
        {
            int samllest = index;

            int left = this.GetLeft(index);
            int right = this.GetRight(index);

            if(left < this.GetSize() && elements[left].CompareTo(elements[index]) < 0){
                samllest = left;
            }

            if(right < this.GetSize() && elements[samllest].CompareTo(elements[right]) < 0){
                samllest = right;
            }
            
            if(samllest != index){
                var temp = elements[index];
                elements[index] = elements[samllest];
                elements[samllest] = temp;
                this.BubbleDown(samllest);
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
            if(parent >=0 && elements[index].CompareTo(elements[parent]) < 0){
                var temp = elements[index];
                elements[index] = elements[parent];
                elements[parent] = temp;
                BubbleUp(parent);
            }
        }

        private int GetParent(int index)
        {
            if(index <= 0) return -1;

            return (index - 1) / 2;
        }
    }
}