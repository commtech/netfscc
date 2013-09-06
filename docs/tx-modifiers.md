# TX Modifiers


###### Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 
| `netfscc`      | `v1.0.0`


## Property
```c#
public TransmitModifiers TxModifiers;
```


## Get
###### Examples
```c#
using Fscc;
...

var modifiers = p.TxModifiers;
```


## Set
###### Examples
```c#
using Fscc;
...

p.TxModifiers = Fscc.TxModifiers.XF | Fscc.TxModifiers.XREP;
```


### Additional Resources
- Complete example: [`examples\tx-modifiers.cs`](https://github.com/commtech/netfscc/blob/master/examples/tx-modifiers/tx-modifiers.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
