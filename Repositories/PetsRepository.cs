
namespace gregSharp.Repositories;

public class PetsRepository
{
  private readonly IDbConnection _db;

  // NOTE IDbConnection already exists within our startup so we don't need to add it, but it follows the same requirements for dependencies as the rest of our files. 
  public PetsRepository(IDbConnection db)
  {
    _db = db;
  }


  // NOTE we need to specify to dapper what the instance type is before our (sql)...think what is this a type of that we're sending?
  // NOTE then we need to tell dapper we want it in format of list. When dapper sees our string, it runs the request, sees the rows,and turns each of those rows into our instance type (<Pet>), converts it into a list, and then returns it back to our service
  internal List<Pet> GetAllPets()
  {
    string sql = "SELECT * FROM JDpets;";
    List<Pet> pets = _db.Query<Pet>(sql).ToList();
    return pets;
  }

  // NOTE firstOrDefault... we're trying to get back a single pet, our where is pointing to unique column in our pets. We typically use query when we're expecting a collection of things (lists, arrays, etc.), but in this case, we want a single object, which firstOrDefault handles. It gives us the first result from our query, or null (default handles the null).
  internal Pet GetPetById(int petId)
  {
    string sql = "SELECT * FROM JDpets WHERE id = @petId";
    Pet pet = _db.Query<Pet>(sql, new { petId }).FirstOrDefault();
    return pet;
  }

  // NOTE in create, firstOrDefault is similar to getbyid, but it is inserting a new pet, we still only want to get one thing back, so we do firstOrDefault on a create so that we get back just one thing, rather than a list of things. 
  internal Pet CreatePet(Pet petData)
  {
    string sql = @"
    INSERT INTO JDpets
    (name, species, breed, description, price, age, isCute, imgUrl)
    VALUES
    (@name, @species, @breed, @description, @price, @age, @isCute, @imgUrl);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, petData);
    petData.Id = id;
    return petData;
  }

  internal int RemovePet(int petId)
  {
    // NOTE throwing limit 1 here will make sure we only grab/delete the one.
    string sql = "DELETE FROM JDpets WHERE id = @petId LIMIT 1;";
    //  NOTE not expecting anything back, so just execute
    int rows = _db.Execute(sql, new { petId });
    return rows;
  }

  internal void updatePet(Pet original)
  {
    // NOTE @ uses variable by that name, 
    string sql = @"
    UPDATE JDpets SET 
    name = @name,
    species = @species,
    breed = @breed,
    description = @description,
    price = @price,
    age = @age,
    isCute = @isCute,
    imgUrl = @imgUrl
    WHERE id = @id;
    ";
    _db.Execute(sql, original);
  }
}
