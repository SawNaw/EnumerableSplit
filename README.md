# LINQ extension to split a collection into several.
Think of it as a `String.Split()` that works on collections of classes.<br />

Example: Split a collection by specifying the splitters.
--------
```
string[] things = { "pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter" };

// Literally specify the splitters.
var edibleThings = things.Split("mud-pie", "mud-spread");
```
`edibleThings` will contain these collections: <br />
   {"pie", "apple", "cake"}<br />
   {"nuts", "plum"}<br />
   {"milk", "butter"}<br />


Example: Split a collection by using a function to define the splitter.
--------
```
string[] things = { "pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter" };

// Specify a function to define the splitters.
var edibleThings = things.Split(t => t.StartsWith("mud"));
```
`edibleThings` will contain these collections: <br />
   {"pie", "apple", "cake"}<br />
   {"nuts", "plum"}<br />
   {"milk", "butter"}
   
# Use Cases
Any time a collection contains useful information separated by known elements.<br /><br />
For example, a text file may contain records where each record is separated by a newline. <br />
Simply read the text file, and perform a `Split()`, passing in the condition for the split.

```
string[] fileContents = File.ReadAllLines("records.txt");
var individualRecords = fileContents.Split(x => string.IsNullOrWhiteSpace(x));
```
