using System;
namespace TenseReport.data
{
    public class PatientID
    {
        public string name { get; set; }
        public string dob { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public PatientID(string name, string dob, string contact, string email)
        {
            this.name = name;
            this.dob = dob;
            this.contact = contact;
            this.email = email;
        }
    }
}
