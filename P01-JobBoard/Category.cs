using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Category
{
    private string name;
    private List<JobOffer> jobOffers;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            if (value.Length<2||value.Length>40 )
            {
                throw new ArgumentException($"Name should be between 2 and 40 characters!");
            }
            name = value;
        }
    }

    public Category(string name)
    {
        this.Name = name;
        this.jobOffers = new List<JobOffer>();
    }

    public void AddJobOffer(JobOffer offer)
    {
        jobOffers.Add(offer);
    }

    public double AverageSalary()
    {
        if (jobOffers.Count==0)
        {
            return 0.0;
        }
        var averageSalary = jobOffers.Average(offer=>offer.Salary);
        return averageSalary;
        
    }

    public List<JobOffer> GetOffersAboveSalary(double salary)
    {
        var getAboveSalary = jobOffers.Where(x => x.Salary>=salary).OrderByDescending(x=>x.Salary).ToList();
        return getAboveSalary;
    }

    public List<JobOffer> GetOffersWithoutSalary()
    {
        var getWithoutSalary = jobOffers.Where(x=>x.Salary==0).OrderBy(x=>x.JobTitle).ToList();
        return getWithoutSalary;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Category {Name}");
        sb.Append($"Total Offers: {jobOffers.Count}");
        return sb.ToString();
    }
}