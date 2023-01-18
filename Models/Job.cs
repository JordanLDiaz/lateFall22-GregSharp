namespace gregSharp.Models;

public class Job
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Company { get; set; }
  public string Description { get; set; }
  public int? Salary { get; set; }
  public int? Hours { get; set; }
  public bool? Remote { get; set; }
}
