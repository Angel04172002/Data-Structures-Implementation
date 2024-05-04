

namespace DataStructuresImplementation
{
    public class CustomList<T>
    {
        private T[] items;
        private int index;
        public CustomList(int capacity = 4)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];   
        }

        public int Count { get => index; }

        public int Capacity { get => items.Length; }


        public void Add(T item) 
        {
            if(index == items.Length)
            {
                items = Resize(items);
            }

            items[index] = item;
            index++;
        }


        public T this[int index]
        {
            get => items[index];
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

   
        public void InsertAt(int startIndex, T item) 
        {
            ValidateIndex(startIndex);
            GrowArray(items, startIndex);
            items[startIndex] = item; 
            index++;
        }

    

        public bool Remove(T item)
        {
            var itemIndex = IndexOf(item);

            if(itemIndex == -1)
            {
                return false;
            }
            
            RemoveAt(itemIndex);

            return true;
        }


        public void RemoveAt(int indexToRemove)
        {
            ValidateIndex(indexToRemove);
            ShrinkArray(items, indexToRemove);
            index--;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < index; i++)
            {
                if (items[i]!.Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        private void ShrinkArray(T[] items, int startIndex)
        {
            for (int i = startIndex; i < index - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[index - 1] = default;
        }

        private void GrowArray(T[] items, int startIndex)
        {
            for (int i = index - 1; i >= startIndex; i--)
            {
                items[i + 1] = items[i];
            }
        }


        private T[] Resize(T[] items)
        {
            T[] newArray = new T[items.Length * 2];

            for (int i = 0; i < index; i++)
            {
                newArray[i] = items[i];
            }

            return newArray;
        }


        private void ValidateIndex(int indexArr)
        {
            if(indexArr < 0 || indexArr > index)
            {
                throw new IndexOutOfRangeException("Invalid Index!");
            }
        }
    }
}
