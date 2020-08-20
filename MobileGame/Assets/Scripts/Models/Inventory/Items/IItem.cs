namespace Models.Items
{
    public interface IItem
    {
        int Id { get; set; }
        string Name { get; set; }
        ItemType Type { get; set; }
    }
}