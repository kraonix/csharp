public class MedicalRecord
{
    private string _diagnosis;
    private string _treatment;

    public int RecordId { get; private set; }
    public int PatientId { get; private set; }

    public string Diagnosis
    {
        get => _diagnosis;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Diagnosis cannot be empty");
            _diagnosis = value;
        }
    }

    public string Treatment
    {
        get => _treatment;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Treatment cannot be empty");
            _treatment = value;
        }
    }

    public MedicalRecord(int recordId, int patientId)
    {
        RecordId = recordId;
        PatientId = patientId;
    }
}
