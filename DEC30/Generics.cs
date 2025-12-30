using System;
using System.Collections;
using System.Collections.Generic;

public class Generics
{
    public Generics()
    {
    }
}
// A simple generic collection implementing IList
public class MyCollection : IList
{
    private object[] items = new object[5];
    private int count = 0;

    public int Add(object value)
    {
        if (count == items.Length)
        {
            object[] temp = new object[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
                temp[i] = items[i];
            items = temp;
        }

        items[count] = value;
        count++;
        return count - 1;
    }

    public void Clear()
    {
        for (int i = 0; i < count; i++)
            items[i] = null;
        count = 0;
    }

    public bool Contains(object value)
    {
        for (int i = 0; i < count; i++)
            if (items[i].Equals(value))
                return true;
        return false;
    }

    public int Count => count;
    public bool IsReadOnly => false;
    public bool IsFixedSize => false;
    public bool IsSynchronized => false;
    public object SyncRoot => this;

    public object this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    public int IndexOf(object value)
    {
        for (int i = 0; i < count; i++)
            if (items[i].Equals(value))
                return i;
        return -1;
    }

    public void Insert(int index, object value)
    {
        for (int i = count; i > index; i--)
            items[i] = items[i - 1];
        items[index] = value;
        count++;
    }

    public void Remove(object value)
    {
        int index = IndexOf(value);
        if (index >= 0)
            RemoveAt(index);
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < count - 1; i++)
            items[i] = items[i + 1];
        items[count - 1] = null;
        count--;
    }

    public void CopyTo(Array array, int index)
    {
        for (int i = 0; i < count; i++)
            array.SetValue(items[i], index++);
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            yield return items[i];
    }
}
