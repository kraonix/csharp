public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

// 1. Generic patient queue with priority
public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    // TODO: Enqueue patient with priority (1=highest, 5=lowest)
    public void Enqueue(T patient, int priority)
    {
        // Validate priority range
        // Create queue if doesn't exist for priority
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (priority < 1 || priority > 5)
            throw new ArgumentOutOfRangeException(nameof(priority), "Priority must be 1–5");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    // TODO: Dequeue highest priority patient
    public T Dequeue()
    {
        // Return patient from highest non-empty priority
        // Throw if empty
        if (!_queues.Any(q => q.Value.Count > 0))
            throw new InvalidOperationException("Queue is empty");

        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
                return queue.Value.Dequeue();
        }

        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Peek without removing
    public T Peek()
    {
        // Look at next patient
        if (!_queues.Any(q => q.Value.Count > 0))
            throw new InvalidOperationException("Queue is empty");

        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
                return queue.Value.Peek();
        }

        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Get count by priority
    public int GetCountByPriority(int priority)
    {
        // Return count for specific priority
        if (!_queues.ContainsKey(priority))
            return 0;

        return _queues[priority].Count;
    }
}

// 2. Generic medical record
public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient ?? throw new ArgumentNullException(nameof(patient));
    }

    // TODO: Add diagnosis with date
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        _diagnoses.Add($"{date:d} - {diagnosis}");
    }

    // TODO: Add treatment
    public void AddTreatment(string treatment, DateTime date)
    {
        // Add to treatments dictionary
        if (string.IsNullOrWhiteSpace(treatment))
            throw new ArgumentException("Invalid treatment");

        _treatments[date] = treatment;
    }

    // TODO: Get treatment history
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        // Return sorted by date
        return _treatments.OrderBy(t => t.Key);
    }
}

// 3. Specialized patient types
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; } // in kg
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; } // 1-10
}

// 4. Generic medication system
public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    // TODO: Prescribe medication with dosage validation
    public void PrescribeMedication(T patient, string medication,
        Func<T, bool> dosageValidator)
    {
        // Check if dosage is valid for patient type
        // Pediatric: weight-based validation
        // Geriatric: kidney function consideration
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        if (!dosageValidator(patient))
            throw new InvalidOperationException("Dosage validation failed for patient type.");

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));
    }

    // TODO: Check for drug interactions
    public bool CheckInteractions(T patient, string newMedication)
    {
        // Return true if interaction with existing medications
        if (!_medications.ContainsKey(patient))
            return false;

        var existingMeds = _medications[patient];

        // Simple mock interaction rule
        return existingMeds.Any(m => m.medication == newMedication);
    }
}

// 5. TEST SCENARIO: Simulate hospital workflow
// a) Create 2 PediatricPatient and 2 GeriatricPatient
// b) Add them to priority queue with different priorities
// c) Create medical records with diagnoses/treatments
// d) Prescribe medications with type-specific validation
// e) Demonstrate:
//    - Priority-based patient processing
//    - Age-specific medication validation
//    - Treatment history retrieval
//    - Drug interaction checking

public class Program
{
    public static void Main()
    {
        var queue = new PriorityQueue<IPatient>();

        var p1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Kid A",
            DateOfBirth = new DateTime(2018, 1, 1),
            BloodType = BloodType.O,
            GuardianName = "Parent A",
            Weight = 18
        };

        var p2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Kid B",
            DateOfBirth = new DateTime(2016, 5, 1),
            BloodType = BloodType.A,
            GuardianName = "Parent B",
            Weight = 30
        };

        var g1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Senior A",
            DateOfBirth = new DateTime(1945, 1, 1),
            BloodType = BloodType.B,
            MobilityScore = 4
        };

        var g2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Senior B",
            DateOfBirth = new DateTime(1940, 1, 1),
            BloodType = BloodType.AB,
            MobilityScore = 6
        };

        queue.Enqueue(p1, 3);
        queue.Enqueue(p2, 2);
        queue.Enqueue(g1, 1);
        queue.Enqueue(g2, 4);

        Console.WriteLine("\n=== Priority Processing ===");
        Console.WriteLine(queue.Dequeue().Name);
        Console.WriteLine(queue.Dequeue().Name);

        var record = new MedicalRecord<IPatient>(p1);
        record.AddDiagnosis("Flu", DateTime.Now.AddDays(-2));
        record.AddTreatment("Paracetamol", DateTime.Now.AddDays(-1));

        Console.WriteLine("\n=== Treatment History ===");
        foreach (var t in record.GetTreatmentHistory())
            Console.WriteLine($"{t.Key:d} - {t.Value}");

        var medSystem = new MedicationSystem<IPatient>();

        medSystem.PrescribeMedication(p1, "Syrup A", patient =>
        {
            if (patient is PediatricPatient ped)
                return ped.Weight >= 15; // weight-based rule

            return true;
        });

        Console.WriteLine("\nMedication prescribed successfully.");

        Console.WriteLine("Interaction check: " +
            medSystem.CheckInteractions(p1, "Syrup A"));
    }

}
