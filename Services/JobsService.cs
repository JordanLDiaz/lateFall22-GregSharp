namespace gregSharp.Services;

public class JobsService
{
  private readonly JobsRepository _repo;

  public JobsService(JobsRepository repo)
  {
    _repo = repo;
  }

  internal List<Job> Get()
  {
    List<Job> jobs = _repo.Get();
    return jobs;
  }

  internal Job Get(int id)
  {
    Job job = _repo.Get(id);
    return job;
  }
  internal Job Create(Job jobData)
  {
    Job job = _repo.Create(jobData);
    return job;
  }

  internal Job Update(Job jobUpdate, int id)
  {
    Job original = Get(id);
    original.Title = jobUpdate.Title ?? original.Title;
    original.Company = jobUpdate.Company ?? original.Company;
    original.Description = jobUpdate.Description ?? original.Description;
    original.Salary = jobUpdate.Salary ?? original.Salary;
    original.Hours = jobUpdate.Hours ?? original.Hours;
    original.Remote = jobUpdate.Remote ?? original.Remote;

    bool edited = _repo.Update(original);
    if (edited == false)
    {
      throw new Exception("Job was not edited");
    }
    return original;
  }

  internal string Remove(int id)
  {
    Job job = Get(id);
    bool deleted = _repo.Remove(id);
    if (deleted == false)
    {
      throw new Exception("No job was deleted.");
    }
    return $"{job.Title} at {job.Company} was removed.";
  }
}
