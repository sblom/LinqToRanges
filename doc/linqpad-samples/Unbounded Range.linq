<Query Kind="Statements">
  <NuGetReference Version="0.9.0">LinqToRanges</NuGetReference>
  <Namespace>LinqToRanges</Namespace>
</Query>

// Since we're using a lazy Enumerable, you can do infinite ranges.
var integers = from x in (0..) select x;

integers.TakeWhile(n => n * n < 1337).Dump();