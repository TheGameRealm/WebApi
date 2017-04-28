#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // AlexaRequests
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class AlexaRequest
    {
        public int Id { get; set; } // Id (Primary key)
        public string RequestId { get; set; } // RequestId (length: 256)
        public string SessionId { get; set; } // SessionId (length: 256)
        public string UserId { get; set; } // UserId (length: 256)
        public System.DateTime Timestamp { get; set; } // Timestamp
        public string Intent { get; set; } // Intent
        public string SlotsToString { get; set; } // SlotsToString (length: 256)
        public bool IsNew { get; set; } // IsNew
        public string Version { get; set; } // Version (length: 10)
        public string Type { get; set; } // Type (length: 50)
        public System.DateTime DateCreated { get; set; } // DateCreated
        public System.Guid AccountRefId { get; set; } // AccountRefId

        // Foreign keys
        public virtual AlexaAccount AlexaAccount { get; set; } // FK_dbo.AlexaRequests_dbo.AlexaAccounts_AccountRefId

        public AlexaRequest()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
