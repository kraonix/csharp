public class Doctor : Person, IBillable
{
    public string Specialization { get; set; }
    public decimal ConsultationFee { get; set; }

    public decimal CalculateBill()
    {
        return ConsultationFee;
    }
}
