namespace gregSharp.Repositories;

public class JobsRepository
{
  private readonly IDbConnection _db;
  public JobsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Job> Get()
  {
    string sql = @"
    SELECT
    *
    FROM JDjobs;
    ";
    List<Job> jobs = _db.Query<Job>(sql).ToList();
    return jobs;
  }

  internal Job Create(Job jobData)
  {
    string sql = @"
    INSERT INTO JDjobs
    (title, company, description, salary, hours, remote)
    VALUES
    (@title, @company, @description, @salary, @hours, @remote);

    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, jobData);
    jobData.Id = id;
    return jobData;
  }

  internal Job Get(int id)
  {
    string sql = @"
    SELECT
    *
    FROM JDjobs
    WHERE id = @id;
    ";
    Job job = _db.Query<Job>(sql, new { id }).FirstOrDefault();
    return job;
  }

  internal bool Update(Job original)
  {
    string sql = @"
    UPDATE JDjobs
        SET
        title = @title,
        company = @company,
        description = @description,
        salary = @salary,
        hours = @hours,
        remote = @remote
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, original);
    return rows > 0;
  }

  internal bool Remove(int id)
  {
    string sql = @"
    DELETE FROM JDjobs
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }
}
