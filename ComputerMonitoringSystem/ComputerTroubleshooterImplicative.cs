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
        //Загружаются все неполадки, значения признаков,
        //связи между проблемами и значениями признаков,
        //нормальные значения признаков.
        var issues = _context.Issues.ToList();
        var featureValues = _context.FeatureValues.ToList();
        var issueFeatureValues = _context.IssueFeatureValues.ToList();
        var normalFeatureValues = _context.NormalFeatureValues.ToList();

        //Создается словарь импликативных правил, ключ - кортеж значений признаков,
        //значение - список проблем, связанных с этими значениями признаков
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

        //Проверка для каждого входного значения на наличие кортежа в словаре импликативных правил.
        //Если существует, добавляю все проблемы из списка значений словаря в список потенциальных проблем.
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

        //Если список потенциальных проблем не пуст, то возвращаю его как результат мониторинга.
        //В противном случае, проверяю, являются ли все входные значения признаков нормальными.
        //Если ДА - No issues detected.
        //Иначе Unable to determine the issue.
        if (potentialIssues.Count > 0)
        {
            // Отрицание условий, когда выбраны все нормальные значения признаков
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

            // Если выбраны все нормальные значения признаков, отрицаем потенциальные проблемы и возвращаем "No issues detected"
            if (allNormal)
            {
                return "No issues detected.";
            }
            else
            {
                return string.Join("\n", potentialIssues.Select(issue => $"{issue.Name}: {issue.Description}"));
            }
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

