# Append Status

It is a good idea to pay attention to the status of each frame. For example, you
may want to see if the frame's CRC check succeeded or failed.

The FSCC reports this data to you by appending two additional bytes
to each frame you read from the card, if you opt-in to see this data. There are
a few methods of enabling this additional data.

###### Driver Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 


## Get
```c#
public bool AppendStatus
```

###### Examples
```c#
using Fscc;
...

var status = p.AppendStatus;
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


## Enable
```c#
public bool AppendStatus
```

###### Examples
```c#
using Fscc;
...

p.AppendStatus = true;
```

###### Support
| Code           | Version
| -------------- | --------
| `cfscc`        | `v1.0.0`


## Disable
```c#
using Fscc;
...

p.AppendStatus = false;
```

###### Support
| Code           | Version
| -------------- | --------
| `cfscc`        | `v1.0.0`


### Additional Resources
- Complete example: [`examples\append-status.c`](https://github.com/commtech/netfscc/blob/master/examples/append-status/append-status.c)
- Implemenation details: [`src\fscc.c`](https://github.com/commtech/cfscc/blob/master/src/fscc.c)
