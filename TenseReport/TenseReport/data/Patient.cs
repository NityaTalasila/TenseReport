using System;
using System.Collections.Generic;
using SQLite;

namespace TenseReport.data
{
    public class Patient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private PatientID patientID;
        private List<Screening> screenings = new List<Screening>();
        public Patient()
        {
            this.patientID = null;
        }
        public Patient(string dob, string name, string contact, string email)
        {
            this.patientID = new PatientID(name, dob, contact, email);
        }

        public void BeginScreening(int sbp, int dbp, DateTime date)
        {
            this.screenings.Add(new Screening(sbp, dbp, date));
        }

        public void AddToScreening(int sbp, int dbp, DateTime date)
        {
            this.screenings[screenings.Count - 1].AddRecording(sbp, dbp, date);
        }

        public Screening GetScreening(int idx)
        {
            if (idx >= 0 && idx < screenings.Count)
            {
                return screenings[idx];
            } else
            {
                return null;
            }
        }

        public List<Screening> GetScreeningList()
        {
            //todo return copy
            return screenings;
        }

        public override string ToString()
        {
            return patientID.name;
        }
    }
}
