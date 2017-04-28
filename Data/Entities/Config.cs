#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace Data.Entities
{

    // Configs
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.28.0.0")]
    public partial class Config
    {
        public int ConfigId { get; set; } // ConfigId (Primary key)
        public string Key { get; set; } // Key (length: 50)
        public string Group { get; set; } // Group (length: 50)
        public string Value { get; set; } // Value (length: 1024)

        public Config()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
