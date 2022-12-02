using System.Text;

namespace StartFromScratch
{
    public class CreateICS
    {
        public static string CreateICSFile(DateTime start, DateTime end, string summary, string desc)
        {
            //some variables for demo purposes
            DateTime DateStart = start;
            DateTime DateEnd = end;
            string Summary = summary;
            string Location = "TEST LOC";
            string Description = desc;

            //create a new stringbuilder instance
            StringBuilder sb = new StringBuilder();

            //start the calendar item
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:stackoverflow.com");
            sb.AppendLine("CALSCALE:GREGORIAN");
            sb.AppendLine("METHOD:PUBLISH");

            //add the event
            sb.AppendLine("BEGIN:VEVENT");

            //with time zone specified
            sb.AppendLine("DTSTAMP:" + DateTime.Now.ToUniversalTime().ToString("yyyyMMddTHHmmssZ"));
            sb.AppendLine("UID:" + DateTime.Now.ToUniversalTime().ToString("yyMMddTHHmmssZ")+"superrandomstring-2281337"+new Random().Next(10000000));
            sb.AppendLine("DTSTART;TZID=Europe/Tallinn:" + DateStart.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND;TZID=Europe/Tallinn:" + DateEnd.ToString("yyyyMMddTHHmm00"));

            sb.AppendLine("SUMMARY:" + Summary);
            sb.AppendLine("LOCATION:" + Location);
            sb.AppendLine("DESCRIPTION:" + Description);
            sb.AppendLine("END:VEVENT");

            //end calendar item
            sb.AppendLine("END:VCALENDAR");

            return sb.ToString();
        }
    }
}
