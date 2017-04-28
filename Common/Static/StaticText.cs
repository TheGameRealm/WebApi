using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Static
{
    public static class StaticText
    {
        public static string GameTitle = "The Azure Realm ";

        public static string Nothing = "There is nothing here. ";
        public static string Rock = "It's a rock. ";
        public static string Void = "You're in the Void. ";
        public static string Portal = "mysterious portal. ";
        public static string StartupConfiguration = "Startup";
        public static string DefaultPathDescription = "path";
        public static string DefaultPortalDescription = "portal";
        public static string IntentType = "IntentType";
        
        public static string PromptForInput = "I didn't understand the command. ";
        public static string RepromptForInput = "What do you want to do? ";

        public static string LaunchIntent_Welcome = "You've entered the Realm";
        public static string SessionEndedRequest_Goodbye = "You've left the Realm";

        public static string DropIntent_DroppedItem = "You dropped the {0}. ";
        public static string DropIntent_DontHaveItem = "You don't have a {0}. ";
        public static string DropIntent_DropWhatItem = "What do you want to drop? ";

        public static string GetIntent_GetItem = "You picked up the {0}. ";
        public static string GetIntent_DontSeeItem = "I don't see a {0}. ";
        public static string GetIntent_GetWhatItem = "What do you want to get? ";

        public static string UseIntent_UseWhatItem = "What do you want to use? ";

        public static string GoIntent_Traveled = "You've traveled {0}. ";
        public static string GoIntent_CantGoThatWay = "I can't go {0}. ";
        public static string GoIntent_DontKnowHow = "I don't know how to go that way. ";
    }
}
