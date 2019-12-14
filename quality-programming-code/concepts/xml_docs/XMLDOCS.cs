using System;

namespace xml_docs
{


    /// <summary>This class represents an appointment object in the system</summary>
    public class Appointment
    {

        private string patientId;
        private DateTime appointmentDateTime;

        public string PatientId
        {
            get { return this.patientId; }
            set { this.patientId = value; }
        }

        public DateTime AppointmentDateTime
        {
            get { return this.appointmentDateTime; }
            set { this.appointmentDateTime = value; }
        }

        ///<summary>creates an appointment instance</summary>
        /// <param name="patientId">The Id of the patient the appointment is created for</param>
        /// <param name="appointmentDateTime">The date and time of the said appointment</param>
        /// <returns>Constructor function, so returns none</returns>

        public Appointment(string patientId, DateTime appointmentDateTime)
        {
            PatientId = patientId;
            AppointmentDateTime = appointmentDateTime;
        }


    }


}