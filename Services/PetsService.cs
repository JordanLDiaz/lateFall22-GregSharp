
namespace gregSharp.Services;

public class PetsService
{
  // NOTE this gives my service access to a repo, the constructor 
  private readonly PetsRepository _petsRepo;

  public PetsService(PetsRepository petsRepo)
  {
    _petsRepo = petsRepo;
  }


  internal List<Pet> GetAllPets()
  {
    List<Pet> pets = _petsRepo.GetAllPets();
    return pets;
  }

  internal Pet getPetById(int petId)
  {
    Pet pet = _petsRepo.GetPetById(petId);
    if (pet == null)
    {
      throw new Exception("No pet at this id.");
    }
    return pet;
  }

  internal Pet CreatePet(Pet petData)
  {
    Pet pet = _petsRepo.CreatePet(petData);
    return pet;
  }

  internal string RemovePet(int petId)
  {
    //  NOTE first check if it exists
    Pet pet = getPetById(petId);
    // NOTE should also check if user is authorized
    // NOTE if we want to be careful/specific, we can also grab rows
    int rows = _petsRepo.RemovePet(petId);
    if (rows > 1) throw new Exception("Whoopsie Daisy.");
    return $"{pet.Name}, age {pet.Age} was removed";
  }

  internal Pet UpdatePet(Pet updateData)
  {
    Pet original = getPetById(updateData.Id);

    original.Name = updateData.Name ?? original.Name;
    original.Species = updateData.Species ?? original.Species;
    original.breed = updateData.breed ?? original.breed;
    original.description = updateData.description ?? original.description;
    original.Price = updateData.Price ?? original.Price;
    original.Age = updateData.Age ?? original.Age;
    original.IsCute = updateData.IsCute ?? original.IsCute;
    original.ImgUrl = updateData.ImgUrl ?? original.ImgUrl;

    _petsRepo.updatePet(original);
    return original;
  }
}
