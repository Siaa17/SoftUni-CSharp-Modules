namespace _04.BorderControl.Interfaces
{
    public interface ICitizen : IBuyer
    {
        string Name { get; }

        int Age { get; }
    }
}
