namespace HCI_Project.Classes;

public class Pair<TFirst, TSecond>
{
    public TFirst First { get; private set; }
    public TSecond Second { get; private set; }

    public Pair(TFirst first, TSecond second)
    {
        First = first;
        Second = second;
    }
}
