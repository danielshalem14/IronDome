namespace IronDome.DAL
{
    public class Data
    {
        // מחרוזת חיבור לבסיס הנתונים
        string ConnectionString = "server = DANIEL\\SQLEXPRESS; initial catalog = IronDome; user id = sa; password = 1234;TrustServerCertificate=Yes";

        // קונסטרקטור פרטי למניעת יצירת מופעים מחוץ למחלקה
        private Data()
        {
            // יצירת מופע של שכבת הנתונים עם מחרוזת החיבור
            Layer = new DataLayer(ConnectionString);
        }

        // משתנה סטטי לשמירת מופע יחיד של המחלקה
        static Data GetData;

        // מאפיין סטטי לקבלת שכבת הנתונים
        public static DataLayer Get
        {
            get
            {
                // יצירת מופע חדש של המחלקה אם לא קיים
                if (GetData == null)
                {
                    GetData = new Data();
                }
                // החזרת שכבת הנתונים
                return GetData.Layer;
            }
        }

        // מאפיין לשמירת שכבת הנתונים
        public DataLayer Layer { get; set; }

    }
}
