class Program
{
    static void Main()
    {
        var engine = new LoanWorkflowEngine();

        var app = engine.Create("LN1001");

        engine.ChangeState("LN1001", LoanAction.Submit);
        engine.ChangeState("LN1001", LoanAction.StartReview);
        engine.ChangeState("LN1001", LoanAction.Approve);
        engine.ChangeState("LN1001", LoanAction.Disburse);

        Console.WriteLine($"Final State: {app.CurrentState}");

        Console.WriteLine("\nState History:");
        foreach (var entry in app.StateHistory)
            Console.WriteLine(entry);
    }
}
