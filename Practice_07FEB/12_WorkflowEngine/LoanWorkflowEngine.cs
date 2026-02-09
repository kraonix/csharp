using System.Collections.Generic;

public class LoanWorkflowEngine
{
    private readonly Dictionary<string, LoanApplication> _applications = new();

    public LoanApplication Create(string appId)
    {
        var app = new LoanApplication(appId);
        _applications[appId] = app;
        return app;
    }

    public void ChangeState(string appId, LoanAction action)
    {
        if (!_applications.ContainsKey(appId))
            throw new KeyNotFoundException("Application not found.");

        _applications[appId].ChangeState(action);
    }

    public LoanApplication Get(string appId) => _applications[appId];
}
