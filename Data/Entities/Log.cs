#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Log
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Log
    {
        public int LogId { get; set; } // LogId (Primary key)
        public string Level { get; set; } // Level (length: 50)
        public string Logger { get; set; } // Logger (length: 128)
        public string ThreadId { get; set; } // ThreadId (length: 50)
        public string Exception { get; set; } // Exception (length: 128)
        public string Content { get; set; } // Content
        public string StackTrace { get; set; } // StackTrace
        public System.DateTime DateCreated { get; set; } // Date_Created
        public System.Guid? UserCreated { get; set; } // User_Created

        public Log()
        {
            DateCreated = System.DateTime.Now;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
