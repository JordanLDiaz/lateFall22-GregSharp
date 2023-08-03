
namespace gregSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
  private readonly PetsService _petsService;

  public PetsController(PetsService petsService)
  {
    _petsService = petsService;
  }

  [HttpGet]
  public ActionResult<List<Pet>> GetAllPets()
  {
    try
    {
      List<Pet> pets = _petsService.GetAllPets();
      return Ok(pets);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{petId}")]
  public ActionResult<Pet> GetPetById(int petId)
  {
    try
    {
      Pet pet = _petsService.getPetById(petId);
      return Ok(pet);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Pet> CreatePet([FromBody] Pet petData)
  {
    try
    {
      Pet pet = _petsService.CreatePet(petData);
      return Ok(pet);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{petId}")]
  public ActionResult<Pet> UpdatePet(int petId, [FromBody] Pet updateData)
  {
    try
    {
      updateData.Id = petId;
      Pet pet = _petsService.UpdatePet(updateData);
      return Ok(pet);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{petId}")]
  public ActionResult<string> RemovePet(int petId)
  {
    try
    {
      string message = _petsService.RemovePet(petId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}
