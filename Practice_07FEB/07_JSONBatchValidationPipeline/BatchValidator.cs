using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;

public class BatchValidator
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    private static readonly Regex PanRegex =
        new(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$", RegexOptions.Compiled);

    public ValidationReport ValidateBatch(List<string> jsonPayloads)
    {
        var report = new ValidationReport
        {
            TotalRecords = jsonPayloads.Count
        };

        for (int i = 0; i < jsonPayloads.Count; i++)
        {
            var result = new RecordValidationResult { Index = i };

            try
            {
                var app = JsonSerializer.Deserialize<CustomerApplication>(
                    jsonPayloads[i],
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                ValidateApplication(app, result);
            }
            catch (Exception ex)
            {
                result.Errors.Add($"Invalid JSON: {ex.Message}");
            }

            if (result.IsValid)
                report.ValidRecords++;
            else
                report.InvalidRecords++;

            report.Details.Add(result);
        }

        return report;
    }

    private void ValidateApplication(CustomerApplication app, RecordValidationResult result)
    {
        if (app == null)
        {
            result.Errors.Add("Application is null.");
            return;
        }

        // Mandatory fields
        if (string.IsNullOrWhiteSpace(app.Name))
            result.Errors.Add("Name is mandatory.");

        if (string.IsNullOrWhiteSpace(app.Email))
            result.Errors.Add("Email is mandatory.");

        if (string.IsNullOrWhiteSpace(app.PAN))
            result.Errors.Add("PAN is mandatory.");

        // Email format
        if (!string.IsNullOrWhiteSpace(app.Email) &&
            !EmailRegex.IsMatch(app.Email))
            result.Errors.Add("Invalid email format.");

        // Age check
        if (app.Age < 18 || app.Age > 60)
            result.Errors.Add("Age must be between 18 and 60.");

        // PAN format
        if (!string.IsNullOrWhiteSpace(app.PAN) &&
            !PanRegex.IsMatch(app.PAN))
            result.Errors.Add("Invalid PAN format.");
    }
}
