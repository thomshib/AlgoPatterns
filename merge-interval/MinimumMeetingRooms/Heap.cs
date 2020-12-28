using System;
using System.Collections.Generic;

namespace DataStructures
{

    public class Heap<T> where T : IComparable<T>{

        /* each element a at index i has

            children at indices 2i + 1 and 2i + 2
            its parent at index floor((i − 1) ∕ 2).
        */

        private List<T> elements = new List<T>();

        public int GetSize(){
            return elements.Count;
        }

        public T GetMin(){
            return this.elements.Count > 0 ? this.elements[0] : default(T); 
        }

        public void Add(T item){
            this.elements.Add(item);
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


         public T Peek(){
            if(elements.Count > 0){
                T item = elements[0];
               
                return item;
            }
            throw new InvalidOperationException("No elements in heap");
        }

        private void BubbleDown(int index)
        {
            var smallest = index;
            var left = this.GetLeft(index);
            var right = this.GetRight(index);
            if(left < this.GetSize() && elements[left].CompareTo(elements[index]) < 0){
                smallest = left;
            }

            if(right < this.GetSize() && elements[right].CompareTo(elements[smallest]) < 0){
                smallest = right;
            }

            if(smallest != index){
                var temp = elements[index];
                elements[index] = elements[smallest];
                elements[smallest] = temp;

                this.BubbleDown(smallest);
            }
        }

      

        private void BubbleUp(int index)
        {
            var parent = this.GetParent(index);

            //swap element at index with parent if it is smaller

            if(parent >=0  && elements[index].CompareTo(elements[parent]) < 0){
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

        private int GetRight(int index)
        {
            return 2 * index + 2;
        }

        private int GetLeft(int index)
        {
            return 2 * index + 1;
        }
    }



}