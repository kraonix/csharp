using System;
using System.Collections.Generic;
using System.Linq;

public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }

    // Compare: Points DESC, then Name ASC
    public int CompareTo(Team other)
    {
        int pointComparison = other.Points.CompareTo(this.Points);

        if (pointComparison != 0)
            return pointComparison;

        return this.Name.CompareTo(other.Name);
    }

    public override bool Equals(object obj)
    {
        if (obj is Team other)
            return Name == other.Name;

        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

public class Match
{
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }

    public int Team1Score { get; set; }
    public int Team2Score { get; set; }

    public Match(Team t1, Team t2)
    {
        Team1 = t1;
        Team2 = t2;
    }

    public Match Clone()
    {
        return new Match(Team1, Team2)
        {
            Team1Score = this.Team1Score,
            Team2Score = this.Team2Score
        };
    }
}

public class Tournament
{
    private List<Team> _teams = new List<Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();

    public void AddTeam(Team team)
    {
        _teams.Add(team);
    }

    public void ScheduleMatch(Match match)
    {
        _schedule.AddLast(match);
    }

    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        _undoStack.Push(match.Clone());
        _schedule.Remove(match);

        match.Team1Score = team1Score;
        match.Team2Score = team2Score;

        if (team1Score > team2Score)
            match.Team1.Points += 3;
        else if (team2Score > team1Score)
            match.Team2.Points += 3;
        else
        {
            match.Team1.Points += 1;
            match.Team2.Points += 1;
        }
    }

    public void UndoLastMatch()
    {
        if (_undoStack.Count == 0)
        {
            Console.WriteLine("No match to undo.");
            return;
        }

        Match lastMatch = _undoStack.Pop();

        if (lastMatch.Team1Score > lastMatch.Team2Score)
            lastMatch.Team1.Points -= 3;
        else if (lastMatch.Team2Score > lastMatch.Team1Score)
            lastMatch.Team2.Points -= 3;
        else
        {
            lastMatch.Team1.Points -= 1;
            lastMatch.Team2.Points -= 1;
        }
    }

    public List<Team> GetRankings()
    {
        return _teams.OrderBy(t => t).ToList();
    }

    public int GetTeamRanking(Team team)
    {
        var sorted = GetRankings();
        return sorted.FindIndex(t => t.Equals(team)) + 1;
    }
}

public class Program
{
    public static void Main()
    {
        Tournament tournament = new Tournament();

        Team teamA = new Team { Name = "Team Alpha", Points = 0 };
        Team teamB = new Team { Name = "Team Beta", Points = 0 };
        Team teamC = new Team { Name = "Team Gamma", Points = 0 };

        tournament.AddTeam(teamA);
        tournament.AddTeam(teamB);
        tournament.AddTeam(teamC);

        Match match1 = new Match(teamA, teamB);
        Match match2 = new Match(teamA, teamC);

        tournament.ScheduleMatch(match1);
        tournament.ScheduleMatch(match2);

        // Team Alpha beats Team Beta
        tournament.RecordMatchResult(match1, 3, 1);

        Console.WriteLine("Rankings After Match 1:");
        foreach (var team in tournament.GetRankings())
        {
            Console.WriteLine($"{team.Name} - {team.Points} pts");
        }

        Console.WriteLine();

        // Team Alpha draws with Team Gamma
        tournament.RecordMatchResult(match2, 2, 2);

        Console.WriteLine("Rankings After Match 2:");
        foreach (var team in tournament.GetRankings())
        {
            Console.WriteLine($"{team.Name} - {team.Points} pts");
        }

        Console.WriteLine();

        // Undo last match
        tournament.UndoLastMatch();

        Console.WriteLine("After Undo:");
        foreach (var team in tournament.GetRankings())
        {
            Console.WriteLine($"{team.Name} - {team.Points} pts");
        }

        Console.WriteLine();
        Console.WriteLine($"Team Alpha Ranking: {tournament.GetTeamRanking(teamA)}");
    }
}
