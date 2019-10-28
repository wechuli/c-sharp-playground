using System;
using System.Collections.Generic;

namespace dictimplimentation
{
    /// <summary> /// Implementation of <see cref="IDictionary"/> interface /// using a hash table. Collisions are resolved by chaining. /// </summary> /// <typeparam name="K">Type of the keys. Keys are required /// to correctly implement Equals() and GetHashCode() /// </typeparam> /// <typeparam name="V">Type of the values</typeparam>

    public class HashDictionary<K, V> : IDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const float DEFAULT_LOAD_FACTOR = 0.75f;
        private List<KeyValuePair<K, V>>[] table;
        private float loadFactor;
        private int threshold;
        private int size;
        private int initialCapacity;

        /// <summary> Creates an empty hash table with the default capacity and load factor</summary>
        public HashDictionary() : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR)
        {

        }

        /// <summary> Creates an empty hash table with given capacity and load factor </summary>
        public HashDictionary(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.table = new List<KeyValuePair<K, V>>[capacity];
            this.loadFactor = loadFactor;
            this.threshold = (int)(capacity * this.loadFactor);

        }

        /// <summary> Finds the chain of elements corresponding internally to given key(by its hash code)</summary>
        /// <param name="createIfMissing">creates an empty list
        /// of elements if the chain still does not exist</param> /// <returns>a list of elements in the chain or null</returns>

        private List<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = index & 0x7FFFFFFF; //CLEAR THE NEGATIVE BIT
            index = index % this.table.Length;
            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }
            return this.table[index] as List<KeyValuePair<K, V>>;
        }

        ///<summary> Finds the value assigned to a given key</summary>
        /// <returns>the value found or null when not found</returns>

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                foreach (KeyValuePair<K, V> entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }

                }
            }
            return default(V);
        }


        /// <summary>Assigns a value to certain key. If the key /// exists, its value is replaced. If the key does not /// exist, it is first created. Works very fast</summary> /// <returns>the old (replaced) value or null</returns>

        public V Set(K key,V value)
        {
            if(this.size >= this.threshold)
            {
                this.Expand();
            }
            List<KeyValuePair<K,V>> chain = this.FindChain(key,true);
        }

    }

}