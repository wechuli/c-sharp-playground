using System;
using System.Collections.Generic;


namespace IListCustom
{
    public interface IListCustom<T>
    {
        int Add(T item);
        void Insert(int index, T item);
        void Clear();
        bool Contains(T item);
        void Remove(T item);
        void RemoveAt(int index);
        int IndexOf(T item);


    }

}