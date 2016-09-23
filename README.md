# RoundRobin
A simple round robin class

## Usage of `RoundRobin<T>`

To create a round robin, pass in a collection of items in the sequence you want them returned in. The sequence must contain at least one element or it will throw an exception.
    
    var rr = new RoundRobin<int>(items);
    
To retrieve items, call `GetNextItem()` which will get you the next item in the sequence. Once the sequence is exhausted, it will restart at the beginning of the sequence.
    
    var item = rr.GetNextItem();
    
## Thread safety

Calls to `GetNextItem()` are thread safe. However, calling it from several threads will not guarantee that each thread receives its items in sequence as calls may be interleaved. 
