using Fscc;
using System;

public class Loop
{
    enum ExitCode : int {
        Success = 0,
        Failure = 1,
        InvalidData = 2
    }

    public static int Main(string[] args)
    {
        int port_num_1, port_num_2;
        bool reset;
        ExitCode e;
        uint iterations = 0;
        uint mismatched = 0;

   		if (args.Length < 2 || args.Length > 3) {
            Console.WriteLine("loop.exe PORT_NUM PORT_NUM [RESET_REGISTER=1]");
            return (int)ExitCode.Failure;
        }

        port_num_1 = int.Parse(args[0]);
        port_num_2 = int.Parse(args[1]);

        if (args.Length == 3)
            reset = (int.Parse(args[2]) >= 0) ? true : false;
        else
            reset = true;

   		Fscc.Port p1 = new Fscc.Port((uint)port_num_1);
   		Fscc.Port p2 = new Fscc.Port((uint)port_num_2);

        if (reset) 
        {
            init(p1);
            init(p2);
        }
   		
        System.Console.WriteLine("Data looping, press any key to stop...");

        while (Console.KeyAvailable == false)
        {
            e = loop(p1, p2);
            if (e != 0) 
            {
                if (e == ExitCode.InvalidData)
                    mismatched++;
                else
                    return (int)ExitCode.Failure;
            }

            iterations++;
        }

        if (mismatched == 0)
            System.Console.WriteLine("Passed ({0} iterations).", iterations);
        else
            System.Console.WriteLine("Failed ({0} out of {1} iterations).", 
                    mismatched, iterations);

        return (int)ExitCode.Success;
    }

    static private void init(Fscc.Port p)
    {
        System.Console.WriteLine("Restoring to default settings.");

        p.MemoryCap.Input = 1000000;
        p.MemoryCap.Output = 1000000;

        p.RxMultiple = false;
        p.AppendStatus = false;
        p.AppendTimestamp = false;
        p.TxModifiers = TxModifiers.XF;
        p.IgnoreTimeout = false;

        p.Registers.FIFOT = 0x08001000;
        p.Registers.CCR0 = 0x0011201c;
        p.Registers.CCR1 = 0x00000018;
        p.Registers.CCR2 = 0x00000000;
        p.Registers.BGR = 0x00000000;
        p.Registers.SSR = 0x0000007e;
        p.Registers.SMR = 0x00000000;
        p.Registers.TSR = 0x0000007e;
        p.Registers.TMR = 0x00000000;
        p.Registers.RAR = 0x00000000;
        p.Registers.RAMR = 0x00000000;
        p.Registers.PPR = 0x00000000;
        p.Registers.TCR = 0x00000000;
        p.Registers.IMR = 0x0f000000;
        p.Registers.DPLLR = 0x00000004;
        p.Registers.FCR = 0x00000000;

        p.ClockFrequency = 18432000;

        p.Purge(true, true);
    }

    static private ExitCode loop(Fscc.Port p1, Fscc.Port p2)
    {
        string odata = "Hello world!";
        string idata;

        p1.Write(odata);
        idata = p2.Read((uint)odata.Length);
        
        if (idata.Length == 0 || odata != idata)
            return ExitCode.InvalidData;

        return ExitCode.Success;
    }
}