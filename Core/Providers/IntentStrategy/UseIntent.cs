namespace Core.Providers.IntentStrategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Extensions;
    using Common.Models;
    using Common.Static;
    using Data.Repositories;

    internal class UseIntent : IntentBase, IIntent
    {
        public static string IntentType = "UseIntent";
        private const string SlotType = "item";

        public UseIntent() : this(new PlayerRepository(), 
            new MapRepository()) { }

        public UseIntent(IPlayerRepository playerRepository,
            IMapRepository mapRepository) : base(playerRepository, mapRepository) { }

        public void Execute(IntentModel intentModel)
        {
            var value = base.GetSlotValue(intentModel.Request, SlotType);
            var valid = base.IsSlotValueValid(value);

            var output = new StringBuilder();
            if (valid)
            {
                var item = base.MapRepository.GetItem(value);
                var inventoryName = item.Name.ToLower() ?? string.Empty;

                switch (inventoryName)
                {
                    case "key":
                        {
                            output.Append("There is nothing to unlock here.");
                            break;
                        }
                    case "rock":
                        {
                            output.Append("How do you use a rock?");
                            break;
                        }
                    case "knife":
                        {
                            output.Append("You're now holding the knife.");
                            break;
                        }
                    default:
                        {
                            output.Append($"You don't have a {value}.");
                            break;
                        }
                }
            }
            else
            {
                output.Append(StaticText.UseIntent_UseWhatItem);
            }

            intentModel.Output.Append(output);
        }

    }
}
