#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // AlexaAccounts
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class AlexaAccount
    {
        public System.Guid AccountId { get; set; } // AccountId (Primary key)
        public string AlexaUserId { get; set; } // AlexaUserId (length: 256)
        public System.DateTime DateCreated { get; set; } // DateCreated
        public System.DateTime LastRequest { get; set; } // LastRequest
        public int RequestCount { get; set; } // RequestCount

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<AlexaRequest> AlexaRequests { get; set; } // AlexaRequests.FK_dbo.AlexaRequests_dbo.AlexaAccounts_AccountRefId

        public AlexaAccount()
        {
            AlexaRequests = new System.Collections.Generic.List<AlexaRequest>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
