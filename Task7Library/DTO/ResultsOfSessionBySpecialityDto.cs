namespace Task7ORM.DTO
{
    /// <summary>
    /// Class which represent model with Results Of Session By Speciality
    /// </summary>
    public class ResultsOfSessionBySpecialityDto
    {
        /// <summary>
        /// Property which storage speciality of group
        /// </summary>
        public string Speciality { get; set; }

        /// <summary>
        /// Property which storage education period
        /// </summary>
        public string SessionPeriod { get; set; }

        /// <summary>
        /// Property which storage middleMark of first semester
        /// </summary>
        public double FirstSemestrMiddleMark { get; set; }

        /// <summary>
        /// Property which storage middleMark of second semester
        /// </summary>
        public double SecondSemestrMiddleMark { get; set; }
    }
}
