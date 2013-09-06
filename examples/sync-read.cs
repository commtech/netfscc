using Fscc;
using System;

public class Tutorial
{
    public static int Main(string[] args)
	{
        Fscc.Port p = new Fscc.Port(0);

        Console.WriteLine(p.Read(20));

		return 0;
	}
}