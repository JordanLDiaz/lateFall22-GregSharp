namespace gregSharp.Repositories;

public class HousesRepository
{
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<House> Get()
  {
    string sql = @"
  SELECT
  *
  FROM JDhouses;
  ";
    List<House> houses = _db.Query<House>(sql).ToList();
    return houses;
  }

  internal House Create(House houseData)
  {
    string sql = @"
    INSERT INTO JDhouses
    (bedroom, bathroom, level, price, description, imgUrl)
    Values
    (@bedroom, @bathroom, @level, @price, @description, @imgUrl);

    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, houseData);
    houseData.Id = id;
    return houseData;
  }

  internal House Get(int id)
  {
    string sql = @"
   SELECT
   *
   FROM JDhouses
   WHERE id = @id;
   ";
    House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
    return house;
  }

  internal bool Update(House original)
  {
    string sql = @"
    UPDATE JDhouses
    SET
        bedroom = @bedroom,
        bathroom = @bathroom,
        level = @level,
        price = @price,
        description = @description,
        imgUrl = @imgUrl
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, original);
    return rows > 0;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM JDhouses
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
