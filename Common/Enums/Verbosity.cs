namespace Common.Enums
{
    using System;
    using System.ComponentModel;

    [Flags]
    public enum Verbosity
    {
        [Description("None")]
        None = 0,
        [Description("area")]
        AreaDescription = 1,
        [Description("directions")]
        Direction = 2,
        [Description("items")]
        CellItems = 4
    }
}
