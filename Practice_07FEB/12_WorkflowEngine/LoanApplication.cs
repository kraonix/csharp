using System;
using System.Collections.Generic;

public class LoanApplication
{
    public string AppId { get; }
    public LoanState CurrentState { get; private set; }

    public List<string> StateHistory { get; } = new();

    public LoanApplication(string id)
    {
        AppId = id;
        CurrentState = LoanState.Draft;
        AddHistory("Initialized as Draft");
    }

    public void ChangeState(LoanAction action)
    {
        var nextState = GetNextState(CurrentState, action);

        if (nextState == null)
            throw new InvalidOperationException(
                $"Invalid transition from {CurrentState} using {action}");

        CurrentState = nextState.Value;
        AddHistory($"Action: {action} → New State: {CurrentState}");
    }

    private LoanState? GetNextState(LoanState current, LoanAction action)
    {
        return (current, action) switch
        {
            (LoanState.Draft, LoanAction.Submit) => LoanState.Submitted,
            (LoanState.Submitted, LoanAction.StartReview) => LoanState.InReview,
            (LoanState.InReview, LoanAction.Approve) => LoanState.Approved,
            (LoanState.InReview, LoanAction.Reject) => LoanState.Rejected,
            (LoanState.Approved, LoanAction.Disburse) => LoanState.Disbursed,

            _ => null
        };
    }

    private void AddHistory(string message)
    {
        StateHistory.Add($"{DateTime.UtcNow}: {message}");
    }
}
