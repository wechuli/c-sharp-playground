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

        public V Set(K key, V value)
        {
            if (this.size >= this.threshold)
            {
                this.Expand();
            }
            List<KeyValuePair<K, V>> chain = this.FindChain(key, true);
            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    // Key found -> replace its value with the new value
                    KeyValuePair<K, V> newEntry = new KeyValuePair<K, V>(key, value);
                    chain[i] = newEntry;
                    return entry.Value;
                }
            }
            chain.Add(new KeyValuePair<K, V>(key, value));
            this.size++;
            return default(V);
        }

        /// <summary> Gets/sets the value by given key.Get returns null when the key is not found.false Set replaces the existing value or created a new key-value pair i fthe key does not exist, works very fast</summary>
        public V this[K key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }


        /// <summary>Removes a key-value pair specified /// by certain key from the hash table.</summary> /// <returns>true if the pair was found removed /// or false if the key was not found</returns>

        public bool Remove(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);
            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    KeyValuePair<K, V> entry = chain[i];
                    if (entry.Key.Equals(key))
                    {
                        //Key found -> remove it
                        chain.RemoveAt(i);
                        this.size--;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>Returns the number of key-value pairs /// in the hash table (its size)</summary>
        public int Count
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>Clears all ements of the hash table</summary>
        public void Clear()
        {
            this.table = new List<KeyValuePair<K, V>>[this.initialCapacity];
            this.size = 0;
        }

        /// <summary>Expands the underlying hash-table. Creates 2 /// times bigger table and transfers the old elements /// into it. This is a slow (linear) operation</summary>

        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            List<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];
            this.threshold = (int)(newCapacity * this.loadFactor);
            foreach (List<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldTable != null)
                {
                    foreach (KeyValuePair<K, V> KeyValuePair in oldChain)

                    {
                        List<KeyValuePair<K, V>> chain = FindChain(KeyValuePair.Key, true);
                        chain.Add(KeyValuePair);
                    }
                }
            }
            {

            }
        }
        /// <summary>Implements the IEnumerable<KeyValuePair<K, V>> /// to allow iterating over the key-value pairs in the hash /// table in foreach-loops</summary>

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (List<KeyValuePair<K, V>> chain in this.table)
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        /// <summary>Implements IEnumerable (non-generic) /// as part of IEnumerable<KeyValuePair<K, V>></summary> 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }

}