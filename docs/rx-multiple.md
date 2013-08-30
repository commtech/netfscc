# RX Multiple

###### Driver Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 


## Get
```c#
public bool RxMultiple
```

###### Examples
```c#
using Fscc;
...

var status = p.RxMultiple;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Enable
```c#
public bool RxMultiple
```

###### Examples
```c#
using Fscc;
...

p.RxMultiple = true;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Disable
```c#
using Fscc;
...

p.RxMultiple = false;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


### Additional Resources
- Complete example: [`examples\rx-multiple.cs`](https://github.com/commtech/netfscc/blob/master/examples/rx-multiple/rx-multiple.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
