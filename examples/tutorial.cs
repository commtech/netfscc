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