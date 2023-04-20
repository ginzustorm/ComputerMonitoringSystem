using ComputerMonitoringSystem.Data;
using ComputerMonitoringSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class ComputerTroubleshooterImplicative
{
    private readonly AppDbContext _context;

    public ComputerTroubleshooterImplicative(AppDbContext context)
    {
        _context = context;
    }

    public string Diagnose(List<FeatureValue> userSelectedFeatureValues)
    {
        // Загружаем все необходимые данные
        var issues = _context.Issues.ToList();
        var featureValues = _context.FeatureValues.ToList();
        var issueFeatureValues = _context.IssueFeatureValues.ToList();
        var normalFeatureValues = _context.NormalFeatureValues.ToList();

        // Создаем словарь правил
        Dictionary<Tuple<int, string>, List<Issue>> implicationalRules = new Dictionary<Tuple<int, string>, List<Issue>>();
        foreach (var issueFeatureValue in issueFeatureValues)
        {
            var featureValue = featureValues.First(fv => fv.Id == issueFeatureValue.FeatureValueId);
            var issue = issues.First(i => i.Id == issueFeatureValue.IssueId);
            var ruleKey = Tuple.Create(featureValue.FeatureId, featureValue.Value);

            if (!implicationalRules.ContainsKey(ruleKey))
            {
                implicationalRules[ruleKey] = new List<Issue>();
            }

            implicationalRules[ruleKey].Add(issue);
        }

        List<Issue> potentialIssues = new List<Issue>();

        // Проверяем каждое выбранное пользователем значение признака
        foreach (var userSelectedFeatureValue in userSelectedFeatureValues)
        {
            var ruleKey = Tuple.Create(userSelectedFeatureValue.FeatureId, userSelectedFeatureValue.Value);

            // Проверяем, является ли выбранное значение признака нормальным
            var normalFeatureValue = normalFeatureValues.FirstOrDefault(nfv => nfv.FeatureId == userSelectedFeatureValue.FeatureId);
            if (normalFeatureValue != null && normalFeatureValue.Value == userSelectedFeatureValue.Value)
            {
                continue; // Пропускаем итерацию, если значение признака является нормальным
            }

            if (implicationalRules.ContainsKey(ruleKey))
            {
                potentialIssues.AddRange(implicationalRules[ruleKey]);
            }
        }

        potentialIssues = potentialIssues.Distinct().ToList();

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
