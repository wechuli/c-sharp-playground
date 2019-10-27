using System;
using System.Text;


namespace dictimplimentation
{
    ///<summary>A structure holding a pair  {key,value}</summary>
    ///<typeparam name="TKey">the type of the keys</typeparam>
    ///<typeparam name="TValue">the type of the values</typeparam>

    public struct KeyValuePair<TKey, TValue>
    {
        /// <summary>Holds the key of the key-value pair </summary>
        public TKey Key { get; private set; }
        ///<summary>Holds the value of the key-value pair</summary>
        public TValue Value { get; private set; }
        ///<summary>Constructs a pair by given key + value </summary>
        public KeyValuePair(TKey key, TValue value) : this()
        {
            this.Key = key;
            this.Value = value;
        }

        ///<summary> Converts the key-value pair to a printable text </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append('[');
            if (this.Key != null)
            {
                builder.Append(this.Key.ToString());
            }
            builder.Append(", ");
            if (this.Value != null)
            {
                builder.Append(this.Value.ToString());
            }
            builder.Append(']');
            return builder.ToString();
        }

    }
}