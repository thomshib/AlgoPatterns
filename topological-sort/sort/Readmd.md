https://www.educative.io/courses/grokking-the-coding-interview/m25rBmwLV00

Solution #

The basic idea behind the topological sort is to provide a partial ordering among the vertices of the graph such that if there is an edge from U to V then U≤V i.e., U comes before V in the ordering. Here are a few fundamental concepts related to topological sort:

    Source: Any node that has no incoming edge and has only outgoing edges is called a source.

    Sink: Any node that has only incoming edges and no outgoing edge is called a sink.

    So, we can say that a topological ordering starts with one of the sources and ends at one of the sinks.

    A topological ordering is possible only when the graph has no directed cycles, i.e. if the graph is a Directed Acyclic Graph (DAG). If the graph has a cycle, some vertices will have cyclic dependencies which makes it impossible to find a linear ordering among vertices.

To find the topological sort of a graph we can traverse the graph in a Breadth First Search (BFS) way. We will start with all the sources, and in a stepwise fashion, save all sources to a sorted list. We will then remove all sources and their edges from the graph. After the removal of the edges, we will have new sources, so we will repeat the above process until all vertices are visited.