# Prefix Search Engine

A highly optimized search engine built in C# to filter strings from datasets based on word prefixes. Developed to practice OOP, complex data structures, and algorithms.

## Cool Features

### Prefix Tree (Trie)

Utilizes a custom Trie data structure for very fast, memory efficient prefix lookups. Indexing time complexity is O(N) (where N is the total number of characters in the dataset).

### Space Tokenization
Datasets are separated into searchable words based on spaces.

### Composite Design Pattern
The architecture allows chaining an infinite number of logical filters (AndOperator, OrOperator, WordFilter) into a single query tree.

## Current Operators

### AND (&&)
Returns entries containing both prefix conditions (uses set intersection).

### OR (||)
Returns entries containing at least one prefix condition (uses set union).

## Example Usage

### Dataset
"Today is Sunday"  
"Today is not Monday"  
"Tomorrow is Tuesday"  
"Tomorrow isn’t Wednesday"  
"Today is Sunday"

### Query
Applying the condition Tod && Sun using the AndOperator to search for words starting with those prefixes.

### Result
"Today is Sunday"