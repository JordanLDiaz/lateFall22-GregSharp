namespace gregSharp.Services;

public class HousesService
{
  private readonly HousesRepository _repo;

  public HousesService(HousesRepository repo)
  {
    _repo = repo;
  }

  internal List<House> Get()
  {
    List<House> houses = _repo.Get();
    return houses;
  }

  internal House Create(House houseData)
  {
    House house = _repo.Create(houseData);
    return house;
  }

  internal House Get(int id)
  {
    House house = _repo.Get(id);
    if (house == null)
    {
      throw new Exception("No house at this id.");
    }
    return house;
  }

  internal House Update(House houseUpdate, int id)
  {
    House original = Get(id);
    original.Bedroom = houseUpdate.Bedroom ?? original.Bedroom;
    original.Bathroom = houseUpdate.Bathroom ?? original.Bathroom;
    original.Level = houseUpdate.Level ?? original.Level;
    original.Price = houseUpdate.Price ?? original.Price;
    original.Description = houseUpdate.Description ?? original.Description;
    original.ImgUrl = houseUpdate.ImgUrl ?? original.ImgUrl;

    bool edited = _repo.Update(original);
    if (edited == false)
    {
      throw new Exception("House was not edited.");
    }
    return original;
  }

  internal string Remove(int id)
  {
    House house = Get(id);
    bool deleted = _repo.Remove(id);
    if (deleted == false)
    {
      throw new Exception("No house was deleted");
    }
    return $"{house.Description} at {house.Price} was removed.";

  }
}