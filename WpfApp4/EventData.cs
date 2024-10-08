using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public class EventData
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public EventData(DateTime date, string description)
        {
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description}";
        }
    }

}
