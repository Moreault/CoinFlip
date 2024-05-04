![CoinFlip](https://github.com/Moreault/CoinFlip/blob/master/coinflip.png)
# What is it?
Adds Coin.Flip() methods for easy, straightforward two-result randoms.

# Returning a random true/false

Result will be either `true` or `false`.
```cs
var result = Coin.Flip();
```

# Returning a random out of two values

The method is generic and will take any type, not just `string`.
```cs
var result = Coin.Flip("Rambo", "Snake");
```

Alternatively, you can use `FlipOrDefault` if you only need to return one value or "nothing".
```cs
var result = Coin.FlipOrDefault("Snake");
```

# Executing random delegates

You can pass `Func<T>` objects to it as well if your logic is more than just returning plain old `T`s.
```cs
var result = Coin.Flip(() => { ... }, () => { ... });
```

Alternatively, you can use `FlipOrDefault` if you only need to execute one or "nothing".
```cs
var result = Coin.FlipOrDefault(() => { ... });
```

If you need to execute code that doesn't return, you can use `Action` delegates.
```cs
Coin.Flip(() => { DestroyTheWorld }, () => SaveTheWorld);
```

Or if you only want one of those to execute or for nothing to happen.
```cs
Coin.Flip(() => { DestroyTheWorld });
```

# Why use this?
It was written mostly with unit testing in mind but it can be used for basically any purpose where you need to have a random result between two options.

This is a super lightweight library that does almost nothing and has zero dependencies.