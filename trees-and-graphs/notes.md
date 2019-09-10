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

We make creating a tree easier by defining a special constructor, which takes for input parameters a node value and a list of its sub-trees. That allows us to give any number of type **`Tree<T>`** (sub-trees)

#### Traverse the Hard Drive Directories


### Bread-Frist Search (BFS)


