
namespace gregSharp.Models
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public string breed { get; set; }
    public string description { get; set; }
    public int? Price { get; set; }
    public int? Age { get; set; }
    public bool? IsCute { get; set; }
    public string ImgUrl { get; set; }

  }
}