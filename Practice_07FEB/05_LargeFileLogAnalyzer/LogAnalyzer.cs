using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class LogAnalyzer
{
    private static readonly Regex ErrorRegex =
        new Regex(@"ERR\d+", RegexOptions.Compiled);

    public IEnumerable<ErrorSummary> GetTopErrors(string filePath, int topN)
    {
        var errorCounts = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filePath))
        {
            var matches = ErrorRegex.Matches(line);

            foreach (Match match in matches)
            {
                string errorCode = match.Value;

                if (errorCounts.ContainsKey(errorCode))
                    errorCounts[errorCode]++;
                else
                    errorCounts[errorCode] = 1;
            }
        }

        return errorCounts
            .OrderByDescending(x => x.Value)
            .Take(topN)
            .Select(x => new ErrorSummary
            {
                ErrorCode = x.Key,
                Count = x.Value
            });
    }
}
