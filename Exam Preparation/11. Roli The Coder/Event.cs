namespace _11.Roli_The_Coder
{
    using System.Collections.Generic;

    public class Event
    {
        public Event(int id, string eventName)
        {
            Id = id;
            EventName = eventName;
            ListOfParticipants = new List<string>();
        }

        public Event(int id, string eventName, List<string> listOfParticipants)
        {
            Id = id;
            EventName = eventName;
            ListOfParticipants = listOfParticipants;
        }

        public int Id { get; set; }
        public string EventName { get; set; }
        public List<string> ListOfParticipants { get; set; }
    }
}
