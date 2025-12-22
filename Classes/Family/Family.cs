namespace Family
{
    public class Father
    {
        public virtual string IntrestOn() // Virtual method to be overridden by derived classes
        {
            return "Fishing";
        }
    }

    public class Son : Father
    {
        public override string IntrestOn() // Override the base class method
        {
            return "Video Games";
        }
    }
}