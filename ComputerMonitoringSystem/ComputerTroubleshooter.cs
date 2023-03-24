using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class ComputerTroubleshooter
{
    private readonly AppDbContext _context;

    public ComputerTroubleshooter(AppDbContext context)
    {
        _context = context;
    }

    public string Diagnose(List<FeatureValue> userSelectedFeatureValues)
    {
        var issues = _context.Issues.ToList();
        var normalFeatureValues = _context.NormalFeatureValues.ToList();
        var issueFeatureValues = _context.IssueFeatureValues.ToList();

        List<Issue> potentialIssues = new List<Issue>();
        Console.WriteLine("User selected feature values: " + string.Join(", ", userSelectedFeatureValues.Select(fv => $"FeatureId: {fv.FeatureId}, Value: {fv.Value}")));

        foreach (var issue in issues)
        {
            var issueValues = issueFeatureValues.Where(ifv => ifv.IssueId == issue.Id).ToList();
            bool anyValueMatches = false;

            foreach (var issueValue in issueValues)
            {
                var featureValue = _context.FeatureValues.Find(issueValue.FeatureValueId);
                if (userSelectedFeatureValues.Any(ufv => ufv.FeatureId == featureValue.FeatureId && ufv.Value == featureValue.Value))
                {
                    anyValueMatches = true;
                    break;
                }
            }

            if (anyValueMatches)
            {
                potentialIssues.Add(issue);
            }
        }

        Console.WriteLine("Potential issues: " + string.Join(", ", potentialIssues.Select(issue => issue.Name)));

        if (potentialIssues.Count > 0)
        {
            return string.Join("\n", potentialIssues.Select(issue => $"{issue.Name}: {issue.Description}"));
        }
        else
        {
            bool allNormal = true;
            foreach (var userSelectedFeatureValue in userSelectedFeatureValues)
            {
                var normalFeatureValue = normalFeatureValues.FirstOrDefault(nfv => nfv.FeatureId == userSelectedFeatureValue.FeatureId);
                if (normalFeatureValue == null || normalFeatureValue.Value != userSelectedFeatureValue.Value)
                {
                    allNormal = false;
                    break;
                }
            }

            if (allNormal)
            {
                return "No issues detected.";
            }
            else
            {
                return "Unable to determine the issue.";
            }
        }
    }

}
