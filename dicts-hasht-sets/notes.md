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

The data structure hash-table is usually implemented internally with an array. It consists of numerated elements (cells), each either holding a key-value pair or is empty (null).

In computing, a **hash table (hash map)** is a data structure that implements an associative array abstract data type, a structure that can map keys to values. An associative array (map/symbol table/dictionary) is an abstract data type composed of a collection of key,value pairs, such that each possible key appears at most once in the collection.

Operations associated with associative arrays are:

- the addition of a pair to the collection
- the removal of a pair from the collection
- the modification of an existing pair
- the lookup of a value associated with a particular key

A hash table uses a hash function to complete an index, also called a hash code, into an array of buckets or slots, from which the desired value can be found. Ideally , the hash function will assign each key to a unique bucket, but most hash table designs employ an imperfect hash function, which might cause hash collisions where the hash function generates the same index for more than one key. Such collisions must be accomodated in some way.

In a well-dimensioned hash table, the average cost (number of instructions) for each lookup is independent of the number of elements stored in the table. Many hash table designs also allow arbitrary insertions and deletions of key-value pairs, at (amortized) constant average cost per operation.

The size of the internal storage array of the hash-table is called capacity. The load factor is a real number between 0 and 1, which stands for the ratio between the occupied elements and the current capacity. For example, if we have a hash-table with 3 eolements and capacity m, the load factor for this hash-table would be 3/m.

When adding or searching for elements, a method for hashing the key(hash function) is executed, this returns a number we call a hash-code. When we take the division remainder of this hash-code and the capacity m, we get a number between 0 and m-1

        index = hash(key) % m

The figure below shows a hash-table T with capacity m and hash-function hash(key)

![](hash.PNG)

This value hash(k) gives us the position in the array at which we search or add a certain key-value pair having this k.If the hash function distributes the keys uniformly, in most cases every key will have a different hash value assigned. In this way, every cell of the array will have at most one key. Ultimately, we get an extremely fast search and insertion of the elements: just calculate the hash function and obtain the cell assigned for the key. Of course, it may occur that different keys would have the same hash code.

The internal table's capacity is increased when the number of elements in the hash-table becomes greater or equal to a certain constant called fill factor (load factor, the maximal degree of filling). When increasing the capacity (usually doubling it), all of the elements are reordered by the hash code of their keys and their assigned cell is calculated according to the new capacity. The load factor is significantly decreased after the reordering. This operation is time-consuming, but it is executed relatively rare, so it will ot impact the overall performance of the add operation.

Hash tables (unlike balanced trees), the elements are not kept sorted.

#### Class Dictionary<K,V>

The class `Dictionary<K,V>` is a standard implementation of dictionary based on hash-table in .NET Framework.

#### Hashing and Hash-Fucntions

The hash-code is a number returned by the hash-function, used for the hashing of the key. This number should be different for every key, or atleast there should be a high chance for that.

##### Hash-Functions

There is the concept of the perfect hash-function. One hash-function is perfect, if for example you have N keys, and for each of them the function would add a different number in a reasonable interval. Finding such a function in the common case is a very hard, almost impossible task. It's worth to use such functions when using sets of keys with predefined elements or when the set of keys is rearely changed.

In practice, there are also other, not so 'perfect' hash-functions.

##### GetHashCode() Method in .NET Framework

Every .NET class has a method called GetHashCode() that returns a value of type **int**. This method is inherited by the class **Object**, which is the root member in the hierarchy of .NET classes.

The implementation in the class **Object** of the method **GetHashCode()** does not guarantee the unique value of the result. This means that the descendant classes need to ensure that GetHashCode() is implemented in order to use it for a key in a hash-table.

The hash-function needs to distribute the keys evenly amongst the possible hash-code values.

##### Collisions with Hash-Functions

The situation where two different keys have the same hash-code is called coliision. The simplest solution to collision is to order the pairs that have keys with the same hash-codes in a list or other data structure. Thus we don't solve the collisions but we accept them and we just put several key-value pairs in the same element in the underlying array in the hash-table. This approach for collision resolution is known as chaining

##### Implementing the Method GetHashCode()

First we need to choose which fields of the class will take part in the implementation of the **Equals(object)** method. This is necessary because every time when **Equals()** returns true, the result from GetHashCode() should always return the same value.

This way the fields that do not take part in **Equals()**, should not take part in **GetHashCode()** as well.

After we choose which fields will take part in the calculation of **GetHashCode()**, we need to receive values from them(of type int). Here is a sample scheme:

- If the field is bool, for true, we take 1 and for false we take 0 (or directly call method **GetHashCode()** on bool)
- If the field is of type int,byte,short,char, we can convert it toint with the cast operator int (or we could directly call **GetHashCode()**)
- If the field is type **long** **float** or **double**, we could use the result from their own implmentations of **GetHashCode()**
- If the field in not a primitive type, we could call the method **GetHashCode()** of this object. If the field value is null, we can return 0.
- If the field is an array or a collection, we take the hash-code from every element of this collection.

In the end, we sum all the received **int** values and before each addition, we multiply the temporary result with a prime number number(for example 83), while ignoring the eventual overflow of type int. For example, if we have 3 fields and their hash codes are f1,f2 and f3, our hash function could combine them through the formula hash = (((f1\*83) + f2) )+ f3.

At the end we obtain a hash-code, which is very well distributed in the range of all 32-bit values, we can expect, that with a hash-code calculated this way, collisions would be rare, because every change is some of the fields taking part in GetHashCode() leads to a major change in the hash code and thus reduces the chance for collision.

##### Interface IEqualityComparer<T>

One of the most important things that we have learned so far is that in order to use instance of class as keys for a dictionary, the class needs to properly implement **GetHashCode()** and **Equals()**. But what should we do if we want to use a class, that we cannot inherit or change ? In this case, the interface **`IEqualityComparer<T>`** comes to our aid.

It defines the following two operations:

- **bool Equals(T obj1, T obj2)** - returns true if obj1 and obj2 are equal
- **int GetHashCode(T obj)** - returns the hash-code of given object

As you might have already guessed, the dictionaries in .NET can use an instance of **`IQualityComparer<T>`**, instead of using the corresponding methods of the given class that should be assigned for a key.

#### Resolving the Collision Problem

In practice, collisions happen almost always, excluding some rare and specific cases. There are several strategies for dealing with collisions:

##### Chaining in a List

The most widespread method to resolve collisions problem is called chaining. Its major concept consists of storing in a list all the pairs (key, value), which have the same hash-code for the key.

##### Open Addressing Methods for Collision Resolution

In general, in case of collision, we try to put the new pair in a table position, which is free. These methods differentiate from each other in the way they choose where to look for a free position for the new pair. Moreover, the new pair must be easily located at its new place.

###### Linear Probing

This is one of the easiest methods for implementation. **Linear probing** in general, can be presented with the following code:

```C#
int newPosition = (oldPosition + i) % capacity;
```

Here, capacity is the internal table capacity, oldPosition is the position where collision occurs and i is a number for the next probing.If the new position is free, then we place the new pair there. Otherwise we try again (probing), incrementing i. Probing can be either forward or backwards. Backward probing is when instead of adding, we are subtracting i from the position we have collision for.
The advantage of this method is the relatively quick way to find of a new position. Unfortunately, if there was a collision at a certain place, there is an extremely high probability collision to occur again at the same place. So this, in practice, leads to a high inefficiency.

###### Quadratic Probing

Quadratic probing is a classic method for collision resolution. The main difference between quadratic probing and linear probing is that it uses a quadratic function of i (the number of the next probing) to find new position. Possible quadratic probing function is shown below:

```C#
int newPosition = (oldPosition + c1*i + c2*i*i) % capacity;
```

The given example uses two constants: c1 and c2, such that c2 must not be 0, otherwise we are going back to linear probing.
By choosing c1 and c2 we define the position we are going to probe, compared to the starting position. For instance, if c1 and c2 are equal to 1, we are going to probe consequently oldPosition, oldPosition + 2, oldPosition + 6, … For a hash-table with capacity of the kind 2n, the best is to choose c1 and c2 equal to 0.5.
Quadratic probing is more efficient than linear the linear probing.

###### Double Hashing

As the name implies, the double hashing method uses two different hash functions. The main concept is that, the second hash function is used for the elements that fall into a collision. This method is better than the linear and quadratic probing, because all the next probing depends of the value of the key and not of the table position inside the hash-table. It makes sense, because the position of a given key depends on the current capacity of the hash-table.

###### Cuckoo Hashing

Cuckoo hashing is a relatively new method for collision resolution, using an open addressing. It was firstly presented by R. Pagh and F. Rodler in 2001. Its name comes from the behavior, observed with some kinds of cuckoos. The mother cuckoos push out the eggs and/or the nests out of other birds, in order to put their own eggs there and the other birds mistakenly care for the cuckoos' eggs in that way. (Also for the nests, after the incubation)
The main idea of this method is the use of two hash-functions instead of one. In this way, we have not one, but two positions to place the element inside the hash-table. If one of the positions is free, then we just put the element there. If both are taken, then we put the new element in one of them and it "kicks out" the element, which was already there. In turn, the "kicked" element is going to his alternative position and "kicks" another element out, if necessary. The new "kicked out" is repeating the procedure, and in that way until reaching a free position or we fall into a loop. In the last case, the whole hash table is built again with greater size and new hash-functions.
On the figure bellow it is shown an example scheme of a hash-table using cuckoo hashing. Every position, containing an element, has a link to the alternative position for the key inside. Now, let’s play out different situations of adding an element.
If, at least one of the two hash functions result is a free cell, there is no problem. We put the element in one of them. Let both hash functions result is a taken cell and we randomly have been choosing one of them.
Some researches show, the cuckoo hashing and its modifications could be much more efficient than the widely spread today chaining in a list and open addressing methods. Nevertheless, this method is still not well adopted in the industry and not used internally in .NET Framework. The main stopper is the need of two hash functions, which means that the class System.Object should introduce two GetHashCode() methods.

### The Set Data Structure

Sets are collections of unique elements (without any repeating elements). In the .NET context, it means, for every set object, calling its Equals() method and passing another object from the set as argument, will always result in false.

Some sets allow their elements to be null, while others do not allow.

Besides not allowing the repetition of objects, another important thing, that distinguishes sets from lists and arrays is that the set element has no index. The elements of the set cannot be accessed by any key, as it is with dictionaries. The elements themselves are the keys.

The only way to access an object from a set is by having available either the object itself or another object, which us equal to it. That is why, in practice we access all the elements of a given set at once, while iterating by using the foreach loop construct.

In .NET, there is an interface `ISet<T>` representing the ADT "set" and it has two standard implementation classes:

- **`HashSet<T>`** - hash-table based implementation of set
- **`SortedSet<T>`** - red-black tree based implementation of set

The main operations, defined by the `ISet<T>` interface (abstract data structure set), are the following

- bool Add(element) – adding the element to the set and returning false if the element is already present inside the set, otherwise returning true.
- bool Contains(element) – checks if the set already contains the element passed as an argument. If yes, returns true as a result, otherwise returns false.
- bool Remove(element) – removes the element from the set. Returns Boolean if the element has been present inside the set.
- void Clear() – removes all the elements from the set.
- void IntersectWith(Set other) – inside the current set remain only the elements of the intersection of both sets – the result is a set, containing the elements, which are present in both sets at the same time – the set, calling the method and the other, passed as parameter.
- void UnionWith(Set other) – inside the current set remain only the elements of the sets union – the result is a set, containing the elements of either one or the other, or both sets.
- bool IsSubsetOf(Set other) – checks if the current set is a subset of the other set. Returns true, if yes and false, if no.
- bool IsSupersetOf(Set other) – checks if the other set is a subset of the current one. Returns true, if yes and false, if no.
- int Count – a property, which returns the current number of elements inside the set.

#### HashSet<T>

The hash-table implementation od set in .NET is the `HashSet<T>` class. This class, like `Dictionary<K,V>` has constructors by which we might pass a list of elements as well as an **IEqualityComparer** implementation.

#### SortedSet<T>

The standard .NET class `SortedSet<T>` is a set, implemented by a balanced search tree (red-black tree). Because of this, its elements are internally kept in an increasing order. For that reason, we can only add elements which are comparable.
We remind that in .NET it typically means the objects are instances of a class, implementing IComparable<T>.
