namespace Core.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common.Models;
    using IntentStrategy;
    using Common.Static;
    using Data.Repositories;
    using Common.Enums;

    public class IntentProvider : ProviderBase, IIntentProvider
    {
        private readonly IEnumerable<Type> intentStrategyClasses;

        public IntentProvider() : this(new PlayerRepository(), 
            new MapRepository()) { }

        public IntentProvider(IPlayerRepository playerRepository,
            IMapRepository mapRepository) : base(playerRepository, mapRepository)
        {
            var intentType = typeof(IIntent);

            this.intentStrategyClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => intentType.IsAssignableFrom(p) && !p.IsInterface);
        }

        public AlexaResponseModel LaunchRequest(AlexaRequestModel alexaRequestModel)
        {
            var alexaResponseModel = BuildAlexaResponseModel();

            var intentModel = BuildIntentModel(alexaRequestModel, alexaResponseModel);

            intentModel.Output.Append(StaticText.LaunchIntent_Welcome);

            BuildOutput(intentModel);

            FinalizeOutput(intentModel);

            return intentModel.Response;
        }

        public AlexaResponseModel SessionEndedRequest(AlexaRequestModel alexaRequestModel)
        {
            var intentModel = BuildIntentModel(alexaRequestModel, BuildAlexaResponseModel());

            intentModel.Output.Append(StaticText.SessionEndedRequest_Goodbye);
            intentModel.Response.Response.ShouldEndSession = true;

            BuildOutput(intentModel);

            FinalizeOutput(intentModel);

            return intentModel.Response;
        }

        public AlexaResponseModel HelpRequest(AlexaRequestModel alexaRequestModel)
        {
            var intentModel = BuildIntentModel(alexaRequestModel, BuildAlexaResponseModel());

            var value = base.GetSlotValue(intentModel.Request, "item");

            var output = new StringBuilder();

            output.Append("The Realm Help Menu");
            output.Append("Movement actions are Go, Move, or Travel followed by a direction such as north, south, east, or west.");
            output.Append("Item actions are Get, Drop, or Use followed by the item name.");
            output.Append("The following toggle are available to improve game play. ");
            output.Append("Toggle area will toggle the general area description. ");
            output.Append("Toggle directions will toggle announcements of the travel directions. ");
            output.Append("Toggle items will toggle the announcement of items on the ground. ");

            intentModel.Output.Append(output);

            FinalizeOutput(intentModel);

            return intentModel.Response;
        }

        public AlexaResponseModel IntentRequest(AlexaRequestModel alexaRequestModel)
        {
            var alexaResponseModel = BuildAlexaResponseModel();

            var intentModel = BuildIntentModel(alexaRequestModel, alexaResponseModel);

            var intentClass = this.intentStrategyClasses
                .SingleOrDefault(o => o.GetField(StaticText.IntentType)
                .GetValue(null).ToString() == alexaRequestModel.Request.Intent.Name);

            if (intentClass != null)
            {
                var intentStrategyClass = (IIntent)Activator.CreateInstance(intentClass);

                intentStrategyClass.Execute(intentModel);
            }

            BuildOutput(intentModel);

            FinalizeOutput(intentModel);

            return intentModel.Response;
        }

        private static AlexaResponseModel BuildAlexaResponseModel()
        {
            var alexaResponseModel = new AlexaResponseModel();
            alexaResponseModel.Response.Card.Title = StaticText.GameTitle;
            alexaResponseModel.Response.Card.Content = StaticText.PromptForInput;
            alexaResponseModel.Response.Reprompt.OutputSpeech.Text = StaticText.RepromptForInput;
            alexaResponseModel.Response.ShouldEndSession = false;

            return alexaResponseModel;
        }

        private IntentModel BuildIntentModel(AlexaRequestModel alexaRequestModel, AlexaResponseModel alexaResponseModel)
        {
            var playerId = base.CustomPrincipal.PlayerId;
            var playerDto = base.PlayerRepository.GetPlayer(playerId);
            var mapDto = base.MapRepository.GetMap(playerDto.MapRefId);
            var cellDto = base.MapRepository.GetCell(playerDto.MapRefId, playerDto.LocationX, playerDto.LocationY);

            var intentModel = new IntentModel()
            {
                Request = alexaRequestModel,
                Response = alexaResponseModel,
                Player = playerDto,
                Map = mapDto,
                Cell = cellDto
            };

            return intentModel;
        }
        
        private void BuildOutput(IntentModel intentModel)
        {
            if (intentModel.Player.Verbosity.HasFlag(Verbosity.AreaDescription))
                intentModel.Output.Append(BuildAreaDescription(intentModel));
            if (intentModel.Player.Verbosity.HasFlag(Verbosity.Direction))
                intentModel.Output.Append(BuildDirectionOutput(intentModel));
            if (intentModel.Player.Verbosity.HasFlag(Verbosity.CellItems))
                intentModel.Output.Append(BuildCellItemsOutput(intentModel));
        }

        private static void FinalizeOutput(IntentModel intentModel)
        {
            intentModel.Response.Response.Card.Content = intentModel.Output.ToString();
            intentModel.Response.Response.OutputSpeech.Text = intentModel.Output.ToString();
        }

    }
}
