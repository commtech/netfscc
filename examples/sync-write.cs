using Fscc;

public class Tutorial
{
    public static int Main(string[] args)
	{
        Fscc.Port p = new Fscc.Port(0);

        p.Write("Hello world!");

		return 0;
	}
}