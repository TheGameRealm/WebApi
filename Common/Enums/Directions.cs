namespace Common.Enums
{
    using System;
    using System.ComponentModel;

    [Flags]
    public enum Directions
    {
        [Description("None")]
        None = 0,
        [Description("North")]
        North = 1,
        [Description("East")]
        East = 2,
        [Description("South")]
        South = 4,
        [Description("West")]
        West = 8
    }
}
