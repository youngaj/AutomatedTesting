namespace SampleProject
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class User: IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}