# Ignore Timeout


###### Driver Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 


## Get
```c#
public bool IgnoreTimeout
```

###### Examples
```c#
using Fscc;
...

var status = p.IgnoreTimeout;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Enable
```c#
public bool IgnoreTimeout
```

###### Examples
```c#
using Fscc;
...

p.IgnoreTimeout = true;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Disable
```c#
using Fscc;
...

p.AppendStatus = false;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


### Additional Resources
- Complete example: [`examples\ignore-timeout.cs`](https://github.com/commtech/netfscc/blob/master/examples/ignore-timeout/ignore-timeout.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
