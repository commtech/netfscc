# FSCC .NET Library (netfscc)
This README file is best viewed [online](http://github.com/commtech/netfscc/).

## Installing Library

##### Downloading Library
- You can use the pre-built driver package that is included with the driver
- Or, you can download the latest library version from
[Github releases](https://github.com/commtech/netfscc/releases).


## Quick Start Guide

Lets get started with a quick programming example for fun.

_This tutorial has already been set up for you at_ 
[`examples/tutorial/`](https://github.com/commtech/netfscc/tree/master/examples/tutorial).

First, drop `netfscc.dll` and `cfscc.dll` into a test directory. Now that those files are 
copied over, create a new C# file (named tutorial.cs) with the following code.

```c#
using Fscc;
using System;

public class Tutorial
{
	public static int Main(string[] args)
	{
		string odata = "Hello world!";
		string idata;

   		Fscc.Port p = new Fscc.Port(0);
   		
		/* Send "Hello world!" text */
		p.Write(odata);

		/* Read the data back in (with our loopback connector) */
		idata = p.Read((uint)odata.Length);

		Console.WriteLine(idata);

		return 0;
	}
}
```

For this example I will use the Visual Studio command line compiler, but
you can use your compiler of choice.

```
# csc /reference:netfscc.dll tutorial.cs
```

Now attach the included loopback connector.

```
# tutorial.exe
Hello world!
```

You have now transmitted and received an HDLC frame! 


## API Reference

There are likely other configuration options you will need to set up for your 
own program. All of these options are described on their respective documentation page.

- [Connect](https://github.com/commtech/netfscc/blob/master/docs/connect.md)
- [Append Status](https://github.com/commtech/netfscc/blob/master/docs/append-status.md)
- [Append Timestamp](https://github.com/commtech/netfscc/blob/master/docs/append-timestamp.md)
- [Clock Frequency](https://github.com/commtech/netfscc/blob/master/docs/clock-frequency.md)
- [Ignore Timeout](https://github.com/commtech/netfscc/blob/master/docs/ignore-timeout.md)
- [RX Multiple](https://github.com/commtech/netfscc/blob/master/docs/rx-multiple.md)
- [Memory Cap](https://github.com/commtech/netfscc/blob/master/docs/memory-cap.md)
- [Purge](https://github.com/commtech/netfscc/blob/master/docs/purge.md)
- [Registers](https://github.com/commtech/netfscc/blob/master/docs/registers.md)
- [TX Modifiers](https://github.com/commtech/netfscc/blob/master/docs/tx-modifiers.md)
- [Read](https://github.com/commtech/netfscc/blob/master/docs/sync-read.md)


## Dependencies
TODO


## API Compatibility
We follow [Semantic Versioning](http://semver.org/) when creating releases.


## License

Copyright (C) 2013 [Commtech, Inc.](http://commtech-fastcom.com)

Licensed under the [GNU General Public License v3](http://www.gnu.org/licenses/gpl.txt).
