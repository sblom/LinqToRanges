<Query Kind="Expression">
  <NuGetReference>LinqToRanges</NuGetReference>
  <Namespace>LinqToRanges</Namespace>
</Query>

from m in 1..(12 + 1) from n in 1..(12 + 1) select new { M = m, N = n, Product = m * n }