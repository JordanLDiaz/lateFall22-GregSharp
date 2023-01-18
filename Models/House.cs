namespace gregSharp.Models;

public class House
{
  public int Id { get; set; }
  public int? Bedroom { get; set; }
  public int? Bathroom { get; set; }
  public int? Level { get; set; }
  public double? Price { get; set; }
  public string Description { get; set; }
  public string ImgUrl { get; set; }
}