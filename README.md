# FSCC .NET Library (netfscc)
This README file is best viewed [online](http://github.com/commtech/netfscc/).

## Installing Library

##### Downloading Library
- The easiest way is to grab the library from [NuGet](https://www.nuget.org/packages/netfscc/)
- Or, you can download the latest library version from [Github releases](https://github.com/commtech/netfscc/releases).


## Quick Start Guide

Lets get started with a quick programming example for fun.

_This tutorial has already been set up for you at_ [`examples/tutorial.cs`](examples/tutorial.cs).

First, drop `netfscc.dll` and `cfscc.dll` into a test directory. Now that those files are copied over, create a new C# file (named tutorial.cs) with the following code.

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

For this example I will use the Visual Studio command line compiler, but you can use your compiler of choice.

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

There are likely other configuration options you will need to set up for your own program. All of these options are described on their respective documentation page.

- [Connect](docs/connect.md)
- [Append Status](docs/append-status.md)
- [Append Timestamp](docs/append-timestamp.md)
- [Clock Frequency](docs/clock-frequency.md)
- [Ignore Timeout](docs/ignore-timeout.md)
- [Memory Cap](docs/memory-cap.md)
- [Purge](docs/purge.md)
- [Read](docs/read.md)
- [Registers](docs/registers.md)
- [RX Multiple](docs/rx-multiple.md)
- [Track Interrupts](docs/track-interrupts.md)
- [TX Modifiers](docs/tx-modifiers.md)
- [Write](docs/write.md)


## Build Dependencies
- .NET compiler (Visual Studio tested)
- [cfscc](https://github.com/commtech/cfscc/) (Included)


## Run-time Dependencies
- OS: Windows XP+ & Linux
- .NET: 2.0+


## API Compatibility
We follow [Semantic Versioning](http://semver.org/) when creating releases.


## License

Copyright (C) 2020 [Commtech, Inc.](https://fastcomproducts.com/)

Licensed under the [MIT license](https://opensource.org/licenses/MIT)
