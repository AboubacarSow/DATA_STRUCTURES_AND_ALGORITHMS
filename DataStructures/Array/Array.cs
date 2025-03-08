using System.Collections;

namespace DataStructures.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList;
        public int Count { get; private set; }  
        public int Capacity => InnerList.Length;

        public Array()
        {
            InnerList = new T[2];
            Count= 0;   
        }
        public Array(params T[] InitialList)
        {
            InnerList=new T[InitialList.Length];
            Count = 0;
            foreach(var item in InitialList) 
                Add(item);
        }
        public Array(IEnumerable<T> collection)
        {
            InnerList=new T[collection.ToArray().Length];
            Count = 0;
            foreach(var item in collection)
                Add(item);  
        }
        public void Add(T item)
        {
            if (InnerList.Length == Count)
                DoubleArray();
            InnerList[Count]= item;
            Count++;
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public void AddRange(params  T[] array)
        {
            foreach (var item in array)
                Add(item);
        }   
        public int IndexOf(T item)
        {
            if (this.Count == 0)
                return -1;
            for (int i = 0; i < Count; i++)
            {
                var value = InnerList[i];
                if (value.Equals(item))
                {
                   return i; 
                }
            }
            return -1;
        }
        public T Remove()
        {
            if (Count == 0)
                throw new Exception($"There is no more item that could be removed from the current array {this}");
            var itemToRemove = InnerList[Count - 1];
            InnerList[Count - 1] = default;
            //Manage the length of the array
            if(Count>0)
                Count--;
            if (InnerList.Length / 4 == Count)
                HalfArray();
            return itemToRemove;    
        }

        public bool Remove(T item)
        {
            
            for(int i = 0; i < Count; i++)
            {
               var value=InnerList[i];
                if (value.Equals(item))
                {
                    for (int j = i; j < Count-1; j++)
                        InnerList[j] =InnerList[j + 1];
                    Count--;
                    return true;
                }
            }
            Console.ForegroundColor=ConsoleColor.Red;
            Console.Write($"> Error:");
            Console.ResetColor();
            Console.ForegroundColor=ConsoleColor.DarkRed;
            Console.WriteLine($"The array does not contain item {item}");
            Console.ResetColor();
            Console.WriteLine();
            return false;
        }
        private void HalfArray()
        {
           var tempArray = new T[InnerList.Length / 2];
           System.Array.Copy(InnerList,tempArray,tempArray.Length/2);
           InnerList = tempArray;
        }

        private void DoubleArray()
        {
            var tempArray = new T[InnerList.Length * 2];
            System.Array.Copy(InnerList,tempArray,InnerList.Length);
            InnerList = tempArray;
        }

        public object  Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //Cela cree une collection intermediaire donc une surcharge de la memoire
            //Pas d'optimisation dans ce context aussi car le Linq est lent
            // return InnerList.Take(Count).GetEnumerator();


            //No simplicity but efficient in the concept of the memory

            for (int i = 0; i < Count; i++)
                yield return InnerList[i];



        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
