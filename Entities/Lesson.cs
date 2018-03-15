namespace jav.Entities
{
  public class Lesson : IEntity
  {
    public int Id { get; set; }
    public int Index { get; set; }
    public string BookName { get; set; }
  }
}
