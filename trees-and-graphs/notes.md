# Trees and Graphs

- binary trees, binary search trees and self balanacing binary search tree
- graph, types of graphs and how to represent a graph in the memory

# Tree Data Structures

Very often we have to describe a group of real life objects, which have such relation to one another that we cannot use linear data structures for their description. A tree-like data structure or branched data structure consists of a set of elements(nodes) which could be linked to other elements, sometimes hierarchially, sometimes not. Trees represent hierarchies, while graphs represent more general relationsh such as the map of a city

## Trees

Trees are very often used in programming, because they naturally represent all kinds of object hierarchies from our surroundings.

### Trees Terminology

![](tree.PNG)

We will simplify the figure describing our hierarchy. We assume it consists of circles and lines connecting them. For convenience, we name the circles with unique numbers, so that we can easily specify about which one we are talking about.

We will call every circle a node and each line an edge.direct descendants (child nodes) of node "7", and node "7" their parent. The same way "1", "12" and "31" are children of "19" and "19" is their parent. Intuitively we can say that "21" is sibling of "19", because they are both children of "7" (the reverse is also true – "19" is sibling of "21").For "1", "12", "31", "23" and "6" node "7" precedes them in the hierarchy, so he is their indirect parent – ancestor, ant they are called his descendants.

The **Root** is the node without a parent. In our example this is node 7.

**Leaf** is a node without child nodes. In our example - "1","12","31","21","23" and "6"

**Internal nodes** are the nodes , which are not leaf or root ( all nodes, which have parent and at least one child.) Such nodes are "19" and "14"

A **Path** is called a sequence of nodes connected with edges in which there is no repetion of nodes. Example of path is the sequence "1", "19", "7" and "21". The sequence "1", "19" and "23" is not a path, because "19" and "23" are not connected.

**Path lenght** is the number of edges, connecting the sequence of nodes in the path. It is equal to the number of nodes in the path minus 1. The length of our example for path ("1", "19", "7" and "21") is three.

**Depth** of a node we will call the length of the path from the root to a certain node. In our example "7" as root depth zero, "19" has depth one and "23" has depth two.

Tree is a recursive data structure, which consists of nodes, connected with edges. The following statements are true for trees

- Each node can have 0 or more direct descendats(children)
- Each node has at most one parent. There is only one special node without a parent - the root (if the tree is not empty)
- All nodes are reachable from the root - there is a path from the root top each node in the tree.

**The Height of a tree** - is the maximu depth of all its nodes. In our example the tree height is 2.
**The Degree** of the node is the _number of direct children_ of the given node. The degree of "19" and "7" is three, but the degree of "14" is two. The leaves have degree zero.

**Branching factor** is the maximu of the degrees of all nodes in the tree. In our example, the maximu degree of the nodes is 3, so the branching factor is 3.

### Tree Implementation - Example

Our tree will contain numbers inside its nodes, and each node will have a list of zero or more children, which are trees too (following our recursive definition)

Each node is recursively defined using itself. Each node of the tree (**`TreeNode<T>`**) contains a list of children, which are nodes. The tree itself is another class **`Tree<T>`** which can be empty or can have a root node.

#### How Does the Implementation Work

The function associated with a node, like creating a node, adding a child node to this node, and getting the number of children are implemented at the level of **`TreeNode<T>`**.

The rest of the functionality (traversing the tree fo rexample) is implemented at the level of **`Tree<T>`**. Logically dividing the fucntionality between the two classes makes our implementation more flexible.

The reason we divide the implementation in two classes is that some operations are typical for each separate node(adding a child for example), while others are about the whole tree (searching a node by its number). In this variant of the implementation, the tree is a class that knows its root and each node knows its children. In this implementation we can have an empty tree (when root =null).

#### Depth-First-Search (DFS) Traversal

The Depth-First-Search algorithm aims to visit each of the tree nodes exactly once. Such a visit of all nodes is called tree traversal.

The DFS algorithm starts from a given node and goes as deep in the tree hierarchy as it can. Whenit reaches a node, which has no children to visit or all have been visited, it returns to the previous node. We can describe the depth-first search algorithm by the following simple steps:

- Traverse the current node - e.g print it on the console or process it in some way
- Sequentially traverse recursively each of the current nodes' child nodes (traverse the sub-trees of the current node).This can be done by a recursive call to the same method for each child node.

The DFS algorithm is a recursive algorithm that uses the idea of backtracking. It involves exhaustive searches of all the nodes by going ahead if possible, else by backtracking.

Here, the word backtrack means that when you are moving forward and there are no more nodes along the current path, you move backwards on the same path to dind nodes to traverse. All the nodes will be visited on the current path till all the unvisited nodes have been traversed after which the next path will be selected.

We make creating a tree easier by defining a special constructor, which takes for input parameters a node value and a list of its sub-trees. That allows us to give any number of type **`Tree<T>`** (sub-trees)

#### Traverse the Hard Drive Directories

### Bread-Frist Search (BFS)

**Breadth-First Search(BFS)** is an algorithm for traversing branched data structures (like trees and graphs). The BFS algorithm first traverses the start node, then all its direct children, then their direct children and so on. This approach is also known as the wavefront traversal, because it looks like the waves caused by a stone thrown into a lake.

The **Breadth-Frist Search (BFS) algorithm** consists of the following steps:

1. Enqueue the start node in queue Q
2. While Q is not empty, repeat the following steps
   - Dequeue the next node v from Q and print it
   - Add all children of v in the queue

The BFS algorithm is very simple and always traverses first the nodes that are closest to the start node, and then the more distant and so on until it reaches the furthest. The BFS algorithm is very widely used in problem solving e.g for finding the shortest path in labyrinth.

### Binary Trees

This type of tree turns out to be very useful in programming. The terminology for trees is also valid about binary trees
Binary Tree is a tree which nodes have a degree equal or less than 2. Because every node's children are at most 2, we call them left child and right child. They are the roots of the left sub-tree and the right sub-tree of their parent node. Some nodes may have only left or only right child, not both. Some nodes may have no children and are called leaves.

Binary tree can be recursively defined as follows: a single node is a binary tree and can have left and right children which are also binary trees.

![](binary.PNG)

We have to note that there is one very big difference in the definition of binary tree from the definition od the classical tree - the order of the children of each node. Although we take binary trees as a special case of a tree structure, we have to notice that the condition for particular order of children nodes makes them a completely different structure.

The traversal of binary tree is a classic problem which has classical solutions. Generally, there are few ways to traverse a binary tree recursively:

- In-order (Left-Root-Right) - the traversal algorithm first traverses the left sub-tree, then the root and last the right sub-tree.
- Pre-order (Root-Left-Right) - in this case the algorithm first traveses the root, then the left sub-tree and last the right sub-tree.
- Post-order(Left-Right-Root) - here we first traverse the left subtree, then the right one last the root.

### Ordered Binary Search Trees

We have seen how to build traditional and binary trees. These structures are very summarized in themselves and it will be difficult for us to use them for a bigger project. Practically, in computer science, special and programming variants of binary and ordinary trees are used that have certain special characteristics, like order, minimal depth and others.

As examples for a useful properties we can give the ability to quickly search for an element by given value (Red-Black tree); order of elements in the tree (ordered search trees); balanced depth(balanced trees);possiblity to store an ordered tree in persistent storage so that searching an element to be fast with as little as possible read operations(B-tree)

They use one often met property of the nodes in the binary trees - unique identification key in every node. Important property of these keys is that they are comparable.

#### Comparability between Objects

Comparability - we call two objects A and B comparable, if exactly one of the following 3 dependencies exists:

- A is less than B
- A is bigger than B
- A is equal to B

The nodes of a tree can contain different fields but we think about only thier unique keys , which we want to be comparable.

And we arrive to the definition of the ordered binary seach tree:

- **Ordered Binary Tree(binary search tree)** is a binary tree, in which every node has a unique key, every two of the keys are comparbale and the tree is organized in a way that for every node the following is satisfied

- All keys in the left sub-tree are smaller than its key
- All keys in the right sub-tree are bigger than its key

#### Properties of the Ordered Binary Search Trees

![](ordered.PNG)

By definition, we know that the left sub-tree of every node consts of elements which are smaller than itself. While the right sub-tree, there are only bigger elements. This means that if we want to find a given element, starting from the root, either we have found it or should search it respectively in its left or right sub-tree, which will save unneccessary comparisons.

From the elements' order follwos that the smallest element in the tree is the leftmost successor of the root, if there is such or the root itself, if it does not have a left successor. Next useful property from this is, that every single element from the left sub-tree of the given node is smaller than every single element from the right sub-tree of the same node.

#### Comparability betwwen Objects in C

What does "comparability between objects" mean for us as developers? It means that we must somehow oblige everyone who uses our data structure, to create it passing it a type, which is comparable.

        T : IComparable<T>

The interface `IComparable<T>`, located in the namespace `Sys
