# FSCC .NET Library (netfscc)
This README file is best viewed [online](http://github.com/commtech/netfscc/).

## Installing Library

##### Downloading Library
- The easiest way is to grab the library from 
[NuGet](https://www.nuget.org/packages/netfscc/)
- Or, you can download the latest library version from
[Github releases](https://github.com/commtech/netfscc/releases).


## Quick Start Guide

Lets get started with a quick programming example for fun.

_This tutorial has already been set up for you at_ 
[`examples/tutorial.cs`](https://github.com/commtech/netfscc/tree/master/examples/tutorial.cs).

First, drop `netfscc.dll` and `cfscc.dll` into a test directory. Now that those files are 
copied over, create a new C# file (named tutorial.cs) with the following code.

```c#
using Fscc;
using System;

public class Tutorial
{
    public static int Main(string[] args)
    {
   		Fscc.Port p = new Fscc.Port(0);
   		
        // Send "Hello world!" text
        p.Write("Hello world!");

        // Read the data back in (with our loopback connector)
        Console.WriteLine(p.Read(100));

        return 0;
    }
}
```

For this example I will use the Visual Studio command line compiler, but
you can use your compiler of choice.

```
# csc /reference:netfscc.dll /platform:x86 tutorial.cs
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
- [Track Interrupts](https://github.com/commtech/netfscc/blob/master/docs/track-interrupts.md)
- [Write](https://github.com/commtech/netfscc/blob/master/docs/write.md)
- [Read](https://github.com/commtech/netfscc/blob/master/docs/read.md)


## Dependencies
- .NET compiler (Visual Studio tested)
- [cfscc](https://github.com/commtech/cfscc/) (Included)


## API Compatibility
We follow [Semantic Versioning](http://semver.org/) when creating releases.


## License

Copyright (C) 2013 [Commtech, Inc.](http://commtech-fastcom.com)

Licensed under the [GNU General Public License v3](http://www.gnu.org/licenses/gpl.txt).
