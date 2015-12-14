namespace _03.ImplementArrayBasedStack
{
    public class ArrayStack<T>
    {
        private const int InitalCapacity = 16;
        private T[] elements;

        public ArrayStack()
        {
            this.elements = new T[InitalCapacity];
            //this.Count = 0;
        }

        public ArrayStack(int capacity)
        {
            this.elements = new T[capacity];
            //this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            T result = this.elements[this.Count];

            return result;
        }


        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.elements[this.Count - 1 - i];
            }

            return newArray;
        }

        private void Grow()
        {
            T[] newElements = new T[this.elements.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
