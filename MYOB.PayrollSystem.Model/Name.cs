namespace MYOB.PayrollSystem.Model
{
    /// <summary>
    /// Name
    /// </summary>
    public class Name
    {
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Returns the Name in String format
        /// </summary>
        public override string ToString() => $"{FirstName} {LastName}";
    }
}