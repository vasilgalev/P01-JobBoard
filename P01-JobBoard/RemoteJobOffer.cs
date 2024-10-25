using System;
using System.Collections.Generic;
using System.Text;

public class RemoteJobOffer : JobOffer
{
    private bool fullyRemote;

    public RemoteJobOffer(string jobTitle, string company, double salary, bool fullyRemote) 
        : base(jobTitle, company, salary)
    {
        this.FullyRemote = fullyRemote;
    }

    public bool FullyRemote
    {
        get
        {
            return fullyRemote;
        }
        set
        {
            fullyRemote = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Job Title: {JobTitle}");
        sb.AppendLine($"Company: {Company}");
        sb.AppendLine($"Salary: {Salary:f2} BGN");
        if (fullyRemote==true)
        {
            sb.AppendLine($"Fully Remote: yes");
        }
        else
        {
            sb.AppendLine($"Fully Remote: no");
        }
        return sb.ToString().Trim();
    }
}


