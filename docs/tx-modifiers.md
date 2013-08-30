# TX Modifiers


###### Driver Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 


## Get
```c#
public TransmitModifiers TxModifiers
```

###### Examples
```c#
using Fscc;
...

var modifiers = p.TxModifiers;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Set
```c#
public TransmitModifiers TxModifiers
```

###### Examples
```c#
using Fscc;
...

p.TxModifiers = XF | XREP;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


### Additional Resources
- Complete example: [`examples\tx-modifiers.cs`](https://github.com/commtech/netfscc/blob/master/examples/tx-modifiers/tx-modifiers.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
