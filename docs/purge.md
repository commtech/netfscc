# Purge
Between the hardware FIFO and the driver's software buffers there are multiple places data could 
be stored, excluding your application code. If you ever need to clear this data and start fresh, 
there are a couple of methods you can use.

###### Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 
| `netfscc`      | `v1.0.0`


## Execute
```c
void Purge(bool tx, bool rx);
```

| Parameter | Type   | Description
| --------- | ------ | -----------------------
| `tx`      | `bool` | Whether to purge the transmit data
| `rx`      | `bool` | Whether to purge the receive data

| Exception        | Base Exception  | Cause
| ---------------- | --------------- | ---------------------------------
| TimeoutException | SystemException | Command timed out (missing clock)


```c
void Purge();
```

| Exception               | Cause
| ----------------------- | --------------------------------------------------------------------
| TimeoutException        | You are executing a command that requires a transmit clock present
| BufferTooSmallException | The read size is smaller than the next frame (in a frame based mode)


This version purges both the transmit and receive sides.


###### Examples
Purge both the transmit and receive data.
```c#
using Fscc;
...

p.Purge(true, true)
```

Purge only the transmit data.
```c#
using Fscc;
...

p.Purge(true, false)
```

Purge only the receive data.
```c#
using Fscc;
...

p.Purge(false, true)
```


### Additional Resources
- Complete example: [`examples\purge.cs`](https://github.com/commtech/netfscc/blob/master/examples/purge.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
