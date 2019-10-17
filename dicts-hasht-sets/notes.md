## Dictionary Data Structure

Dictionaries are also known as associative arrays or maps. Every element in the dictionary has a key and an associated value for this key. Both the key and the value represent a pair.
When using dictionaries, the set of keys usually is a randomnly chosen set of values like real numbers or strings. The only restriction is that we distringuish one key from the other.
For every key in the dictionary, there is a corresponding value. One key can hold only one value. The aggregation of all the pairs (key,value) represents the dictionary

### The Abstract Data Structure "Dictionary" (Associative Array, Map)

In programming, the abstract data structure "dictionary" is represented by many aggregated pairs (key, value) along with predefined methods for accessing the values by a given key. Alternativelt, this data strucure can also be called a "map" or "associative array"

Described below are the required operations, defined by this data structure:

- **void Add(K key, V value)** - adds given key-value pair in the dictionary. With most implementations of this class in .NET, when adding a key that already exists, an exception is thrown.
- **V Get(K key)** - returns the value by the specified key. If there is no pair with this key, the method returns null or throws an excpetion depending on the specific dictionary implentation
- **bool Remove(key)** - removes the value, associated with the specified key and returns a Boolean value indication if the operation was successful.

Here are some additional methods, which are supported by the ADT.

- **bool Contains(key)** - returns true if the dictionary has a pair with the selected key
- **int Count** - returns the number of elements (key value pairs) in the dictionary

Other operations that are usually supported are: extracting all of the keys, values or key value pairs and importing them into another structure (array, list)

### The Interface IDictionary<K,V>

In .NET, there is a standard interface **`IDictionary<K,V>`**, where K defines the type of the key, and V th type of the value. If defines all of the basic operations that the dictionaries should implement. `IDictionary<K,V>` corresponds to the abstract data structure "dictionary" and defines the operations, mentioned above, but without supplying an actual implementation of them. Interfaces define which methods and fields should be implmented in the classes that inherit the interface.

In .NET Framework there are two major implementations of the interface `IDictionary<K, V>` – `Dictionary<K, V>` and `SortedDictionary<K, V>`. `SortedDictionary` is an implementation by a balanced (red-black) tree, and `Dictionary` – by a hash-table.

#### Implementation of Dictionary with Red-Black Tree

A red-black tree is an ordered binary balanced search tree, that's used for searching. This is why one of the important requirements for the set of keys used by `SortedDictionary<K,V>` is comparability. This means that, if we have two keys, either one of them should be bigger, or they should be equal. The keys used in `SortedDictionary<K,V>` should implement `IComporable<K>`

The usage of the binary search tree gives us a great advantage: the keys in the dictionary are stored ordered. Thanks to this feature, if we need the data ordered by keys, we don't need to perform any additional sorting. Actually, this is the only advantage this dictionary implementation compared to the hash-table

A things that should be mentioned is that keeping the keys ordered comes with its price. Searching for the elements using an ordered balanced tree is slower (typically takes log(n) steps) than using a hash-table (O(1)). Because of this, if there is no requirement for the keys to be ordered, its better to use **`Dictionary<K,V>`**

##### IComparable<K> Interface

When using `SortedDictionary<K,V>` the keys are required to be **comparable**. In our example we use objects of type **string**.
The class **string** implements the interface **IComparable** and the comparison between the elements is done lexicographically. By default, the strings in .NET are case sensitive. This means that words that start with a lowercase letter will be before the ones with an uppercase letter. This definition comes from the implementation of the method **CompareTo(object)**, through which the **string** class implements the interface **IComparable**.

##### IComparer<T> Interface

What should we do when we are not happy with the default implementation of comparison? For example, what should we so when we want uppercase and lowercase chracters to be treated as equal ?

For the comparison of objects with an exclusively defined order in `SortedDictionary<K,V>` in .NET, we will use the interface `IComparable<T>`. It defines a comparison function **int Compare(T x, T y)** that is an alternative to the already defined order.

When we create an object of type `SortedDictionary<K,V>`, we can pass to its constructor a reference to `IComparable<K>` so that it can use it for the key comparison (key elements should be objects of type K).

After using `IComparerer<E>`, we changed the definition for ordering keys in our dictionary. If, for a key, we used a class, defined by us, for example - **Student**, that implements `IComparable<E>`, we would get the same result if we were to alter the method `CompareTo(Student)`. There is also one additional requirement, when implementin `IComparable<K>`:
When two objects are equal (Equals(object) returns true), CompareTo(E) should return 0.

Meeting this requirement would allow us to use the objects of a custom class as keys, just as in the implementation of a balanced tree.

#### Dictionary Implmentation with Hash-Table

With a hash-table implementation, the time for accessing the elements in the dictionary is theoretically independent from their count. This is a very important advantage. With hash-tables, if we have a key, the number of comparisons that we would need to do to find out if there is a key with this calue, is constant and it does not depend on the number of elements.

##### What is a Hash Table?