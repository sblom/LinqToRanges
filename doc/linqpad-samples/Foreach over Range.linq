<Query Kind="Statements">
  <NuGetReference>LinqToRanges</NuGetReference>
  <Namespace>LinqToRanges</Namespace>
</Query>

int total = 0;

foreach (var n in 0..100)
{
	total += n;
}

total.Dump("Total");