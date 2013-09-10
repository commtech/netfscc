# Append Timestamp

###### Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.4.0` 
| `fscc-linux`   | `v2.4.0` 
| `netfscc`      | `v1.0.0`


###### Property
```c#
bool AppendTimestamp { get {...}, set{...} };
```


## Get
###### Examples
```c#
using Fscc;
...

var status = p.AppendTimestamp;
```


## Enable
###### Examples
```c#
using Fscc;
...

p.AppendTimestamp = true;
```


## Disable
###### Examples
```c#
using Fscc;
...

p.AppendTimestamp = false;
```


### Additional Resources
- Complete example: [`examples\append-timestamp.cs`](https://github.com/commtech/netfscc/blob/master/examples/append-timestamp.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
