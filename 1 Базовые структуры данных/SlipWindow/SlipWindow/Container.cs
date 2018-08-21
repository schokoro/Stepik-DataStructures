using System;


namespace SlipWindow
{
    public struct Container<T> where T : IComparable<T>
    {
        private T item;
        private T maximum;
        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public T Maximum
        {
            get { return maximum; }
            set { maximum = value; }
        }
        public Container(T val1, T val2)
        {
            item = val1;
            maximum = val2;
        }
    }
}
