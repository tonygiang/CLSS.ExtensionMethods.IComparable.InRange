# CLSS.ExtensionMethods.IComparable.InRange

### Problem

An expression to check if a value is within a certain range is somewhat long:

```
min <= value && value < max
```

Even longer when the type of your value does not implement comparison operators:

```
value.CompareTo(min) >= 0 && value.CompareTo(max) < 0
```

### Solution

`InRange` does this in a more intuitive, shorter and functional style friendly way:

```
using CLSS;

value.InRange(min, max)
```

No more short stops in your code reading to decode the meanings of comparison operators. When you read `InRange`, you know what it's doing.

By default, `InRange` is min-inclusive and max-exclusive. To change this behavior, you can pass in a 3rd and 4th argument to specify min and max inclusivity:

```
using CLSS;

// this is a min-exclusive and max-inclusive comparison
value.InRange(min, max, false, true) // false if value == min, true if value == max
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).