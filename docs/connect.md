# Connect

Opening a handle using this API will only give you access to the
synchronous functionality of the card. You will need to use the COM ports
if you would like to use the asynchronous functionality.

###### Driver Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 


## Connect
```c#
public Port(uint port_num)
```

###### Examples
```c#
using Fscc;
...

var p = new Fscc.Port(0);
```

###### Support
| Code           | Version
| -------------- | --------
| `netfscc`        | `v1.0.0`


### Additional Resources
- Complete example: [`examples\tutorial.cs`](https://github.com/commtech/netfscc/blob/master/examples/tutorial/tutorial.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
