public class DoctorNotAvailableException : Exception
{
    public DoctorNotAvailableException(string message) : base(message) { }
}

public class InvalidAppointmentException : Exception
{
    public InvalidAppointmentException(string message) : base(message) { }
}

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string message) : base(message) { }
}

public class DuplicateMedicalRecordException : Exception
{
    public DuplicateMedicalRecordException(string message) : base(message) { }
}
