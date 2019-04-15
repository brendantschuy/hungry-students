namespace bs2.Models
{
    public class DatabaseEntry
    {
        public DatabaseEntry(string name, int st, int end, int date, string address, string desc, string types)
        {
            this.EventName = name;
            this.EventStart = st;
            this.EventEnd = end;
            this.EventDate = date;
            this.EventAddress = address;
            this.Description = desc;
            this.FoodType = types;
        }
        public string EventName{get;set;}
        public int EventStart{get;set;}
        public int EventEnd{get;set;}
        public int EventDate{get;set;}
        public string EventAddress{get;set;}

        public string Description{get;set;}
        public string FoodType{get;set;}
    }
}