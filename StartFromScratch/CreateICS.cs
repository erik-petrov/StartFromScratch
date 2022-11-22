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
            string FileName = "BuyingInvitation";

            //create a new stringbuilder instance
            StringBuilder sb = new StringBuilder();

            //start the calendar item
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:stackoverflow.com");
            sb.AppendLine("CALSCALE:GREGORIAN");
            sb.AppendLine("METHOD:PUBLISH");

            //create a time zone if needed, TZID to be used in the event itself
            sb.AppendLine("BEGIN:VTIMEZONE");
            sb.AppendLine("TZID:Europe/Tallinn");
            sb.AppendLine("BEGIN:STANDARD");
            sb.AppendLine("TZOFFSETTO:+0200");
            sb.AppendLine("TZOFFSETFROM:+0200");
            sb.AppendLine("END:STANDARD");
            sb.AppendLine("END:VTIMEZONE");

            //add the event
            sb.AppendLine("BEGIN:VEVENT");

            //with time zone specified
            sb.AppendLine("DTSTAMP;" + DateTime.Now.To);
            sb.AppendLine("UID;" + DateTime.Now.ToUniversalTime()+"superrandomstring-2281337"+new Random().Next(10000000));
            sb.AppendLine("DTSTART;TZID=Europe/Tallinn:" + DateStart.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND;TZID=Europe/Tallinn:" + DateEnd.ToString("yyyyMMddTHHmm00"));
            //or without
            sb.AppendLine("DTSTART:" + DateStart.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND:" + DateEnd.ToString("yyyyMMddTHHmm00"));

            sb.AppendLine("SUMMARY:" + Summary + "");
            sb.AppendLine("LOCATION:" + Location + "");
            sb.AppendLine("DESCRIPTION:" + Description + "");
            sb.AppendLine("PRIORITY:3");
            sb.AppendLine("END:VEVENT");

            //end calendar item
            sb.AppendLine("END:VCALENDAR");

            return sb.ToString();
        }
    }
}
