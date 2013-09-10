# Read
The length argument of the `fscc_read()` function means different things depending
on the mode you are using.

In a frame based mode the length argument specifies the maximum frame size
to return. If the next queued frame is larger than the size you specified
the error `FSCC_BUFFER_TOO_SMALL` is returned and the data will remain 
waiting for a `fscc_read()` of a larger value. If a `fscc_read()` length is specified 
that is larger than the length of multiple frames in queue, you will still only receive 
one frame per `fscc_read()` call.

In streaming mode (no frame termination) the length argument specifies the
maximum amount of data to return. If there are 100 bytes of streaming data
in the card and you `fscc_read()` with a length of 50, you will receive 50 bytes.
If you do a `fscc_read()` of 200 bytes, you will receive the 100 bytes available.

Frame based data and streaming data are kept separate within the driver.
To understand what this means, first imagine the following scenario. You are in a
frame based mode and receive a couple of frames. You then switch to
streaming mode and receive a stream of data. When calling `fscc_read()`
you will receive the the streaming data until you switch back into a frame based
mode and do a `fscc_read()`.

Most users will want the advanced I/O capabilities included by using the Windows
[OVERLAPPED I/O API](http://msdn.microsoft.com/en-us/library/windows/desktop/ms686358.aspx). 
We won't duplicate the documentation here, but for your reference, here is an [article]
(http://blogs.msdn.com/b/oldnewthing/archive/2011/02/02/10123392.aspx) on a common
bug developers introduce while trying to cancel I/O operations when using OVERLAPPED I/O.

###### Support
| Code           | Version
| -------------- | --------
| `fscc-windows` | `v2.0.0` 
| `fscc-linux`   | `v2.0.0` 
| `netfscc`      | `v1.0.0`


## Read (Overlapped)
```c#
int Read(byte[] buf, uint size, out NativeOverlapped o)
```

| Parameter    | Type                   | Description
| ------------ | ---------------------- | -----------------------
| `buf`        | `byte []`              | The data buffer to hold incoming data
| `size`       | `uint`                 | The data buffer size
| `o`          | `out NativeOverlapped` | [Overlapped IO structure](http://msdn.microsoft.com/en-us/library/windows/desktop/ms686358.aspx)

| Return Value            | Cause
| ----------------------- | ------------------------------------------------------------------
| 0                       | Success
| `FSCC_BUFFER_TOO_SMALL` | The read size is smaller than the next frame (in a frame based mode)

###### Examples
```c#
using Fscc;
...

var idata = new byte[20];
var bytes_read = 0;

bytes_read = p.Read(idata, (uint)idata.Length, o);
```


## Read (Blocking)
```c#
uint Read(byte[] buf, uint size)
```

| Parameter    | Type      | Description
| ------------ | --------- | -----------------------
| `buf`        | `byte []` | The data buffer to hold incoming data
| `size`       | `uint`    | The data buffer size

| Return
| ---------------------------
| Number of bytes read

###### Examples
```c#
using Fscc;
...

var idata = new byte[20];
var bytes_read = 0;

bytes_read = p.Read(idata, (uint)idata.Length);
```


## Read (Timeout)
```c#
uint Read(byte[] buf, uint size, uint timeout)
```

| Parameter    | Type      | Description
| ------------ | --------- | -----------------------
| `buf`        | `byte []` | The data buffer to hold incoming data
| `size`       | `uint`    | The data buffer size
| `timeout`    | `uint`    | Number of milliseconds to wait for data

| Return
| ---------------------------
| Number of bytes read

###### Examples
```c#
using Fscc;
...

var idata = new byte[20];
var bytes_read = 0;

bytes_read = p.Read(idata, (uint)idata.Length, 100);
```

## Read (Blocking)
```c#
string Read(uint size=4096)
```

| Parameter    | Type      | Default | Description
| ------------ | --------- | ------- | -----------------------
| `size`       | `uint`    | `4096`  | The max frame size

| Return
| ---------------------------
| The latest frame

###### Examples
```c#
using Fscc;
...

string str = p.Read();
```

## Read (Timeout)
```c#
string Read(uint size, uint timeout)
```

| Parameter    | Type      | Description
| ------------ | --------- | -----------------------
| `size`       | `uint`    | The max frame size
| `timeout`    | `uint`    | Number of milliseconds to wait for data

| Return
| ---------------------------
| The latest frame

###### Examples
```c#
using Fscc;
...

string str = p.Read(4096, 100);
```


### Additional Resources
- Complete example: [`examples\tutorial.cs`](https://github.com/commtech/netfscc/blob/master/examples/tutorial.cs)
- Implemenation details: [`src\Fscc.cs`](https://github.com/commtech/netfscc/blob/master/src/Fscc.cs)
