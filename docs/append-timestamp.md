# Append Timestamp

###### Driver Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 


## Get
```c#
public bool AppendTimestamp
```

###### Examples
```c#
using Fscc;
...

var status = p.AppendTimestamp;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Enable
```c#
public bool AppendTimestamp
```

###### Examples
```c#
using Fscc;
...

p.AppendTimestamp = true;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Disable
```c#
using Fscc;
...

p.AppendTimestamp = false;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


### Additional Resources
- Complete example: [`examples\append-timestamp.cs`](https://github.com/commtech/netfscc/blob/master/examples/append-timestamp.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
