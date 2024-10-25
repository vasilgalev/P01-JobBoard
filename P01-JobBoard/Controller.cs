using System;
using System.Collections.Generic;
using System.Text;


public class Controller
{
    private readonly Dictionary<string, Category> categories;

    public Controller()
    {
        this.categories = new Dictionary<string, Category>();
    }

    public string AddCategory(List<string> args)
    {
        string name = args[0];
        if (!categories.ContainsKey(name))
        {
            categories.Add(name, new Category(name));
            return $"Created Category {name}!";
        }
        return $"Category already exist!";
        
    }

    public string AddJobOffer(List<string> args)
    {
        string name = args[0];
        string jobTitle = args[1];
        string company = args[2];
        double salary = double.Parse(args[3]);
        string type = args[4];
        if (type == "onsite")
        {
            string city = args[5];
            JobOffer offer = new OnSiteJobOffer(jobTitle, company, salary, city);
            categories[name].AddJobOffer(offer);
            return $"Created JobOffer {jobTitle} in Category {name}!";
        }
        else if (type == "remote")
        {
            bool fullyRemote = bool.Parse(args[5]);
            JobOffer offer = new RemoteJobOffer(jobTitle,company, salary, fullyRemote);
            categories[name].AddJobOffer(offer);
            return $"Created JobOffer {jobTitle} in Category {name}!";
        }
        return $"Job offer cannot be created!";
    }

    public string GetAverageSalary(List<string> args)
    {
        string name = args[0];
        double averageSalary = categories[name].AverageSalary();
        return $"The average salary is: {averageSalary:f2} BGN";
    }

    public string GetOffersAboveSalary(List<string> args)
    {
        string name = args[0];
        double salary = double.Parse(args[1]);
        var listOffers = categories[name].GetOffersAboveSalary(salary);
        StringBuilder sb = new StringBuilder();
        foreach (var offer in listOffers)
        {
            sb.AppendLine(offer.ToString());
        }
        return sb.ToString().Trim();
    }

    public string GetOffersWithoutSalary(List<string> args)
    {
        string name = args[0];
        var listOffers = categories[name].GetOffersWithoutSalary();
        StringBuilder sb = new StringBuilder();
        foreach (var offer in listOffers)
        {
            sb.AppendLine(offer.ToString());
        }
        return sb.ToString().Trim();
    }

}