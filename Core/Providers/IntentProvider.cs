using Common.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Providers
{
    /// <summary>
    /// Todo: 
    /// Player Persistance
    /// Map Interaction
    /// Map Item Interaction (Move Items to/from Inventory to map location)
    /// Inventory Management
    /// Combat
    /// Quests
    /// NPC Interaction
    /// Scoring? Achievements? Character Level?
    /// </summary>
    public class IntentProvider : ProviderBase, IIntentProvider
    {
        private IAlexaRepository alexaRepository { get; set; }
        private List<Func<AlexaRequestModel, string>> intents { get; set; }
        private List<string> validDirections = new List<string>() { "north", "east", "south", "west" };
        private List<string> validItems = new List<string>() { "key", "rock", "knife" };


        public IntentProvider(IAlexaRepository alexaRepository)
        {
            this.alexaRepository = alexaRepository;

            this.intents = new List<Func<AlexaRequestModel, string>>();
            this.intents.Add(this.GoIntent);
            this.intents.Add(this.PortalIntent);
            this.intents.Add(this.GetIntent);
            this.intents.Add(this.UseIntent);
            this.intents.Add(this.DropIntent);
        }

        public AlexaResponseModel LaunchRequest(AlexaRequestModel alexaRequestModel)
        {
            var response = new AlexaResponseModel("You've entered the Realm");

            // Prepare game for user

            //response.Session.MemberId = alexaRequestModel.Session.Attributes.MemberId;
            response.Response.Card.Title = "The Realm";
            response.Response.Card.Content = "You've entered the realm";
            response.Response.Reprompt.OutputSpeech.Text = "What would you like to do?";
            response.Response.ShouldEndSession = false;

            return response;
        }

        public AlexaResponseModel SessionEndedRequest(AlexaRequestModel alexaRequestModel)
        {
            var response = new AlexaResponseModel("You've left the Realm");

            // Cleanup Work here

            //response.Session.MemberId = alexaRequestModel.Session.Attributes.MemberId;
            response.Response.Card.Title = "The Realm";
            response.Response.Card.Content = "You've left the realm";
            response.Response.Reprompt.OutputSpeech.Text = "";
            response.Response.ShouldEndSession = true;

            return response;
        }

        public AlexaResponseModel IntentRequest(AlexaRequestModel alexaRequestModel)
        {
            var result = this.intents.SingleOrDefault(o => o.Method.Name == alexaRequestModel.Request.Intent.Name)(alexaRequestModel);

            if (result == null)
            {
                result = "I didn't understand the command.";
            }

            var response = new AlexaResponseModel(result);
            //response.Session.MemberId = alexaRequestModel.Session.Attributes.MemberId;
            response.Response.Card.Title = "The Realm";
            response.Response.Reprompt.OutputSpeech.Text = "What do you want to do?";
            response.Response.ShouldEndSession = false;

            return response;
        }

        private string GoIntent(AlexaRequestModel alexaRequestModel)
        {
            var value = base.GetSlotValue(alexaRequestModel, "direction");
            var valid = base.IsSlotValueValid(this.validDirections, value);

            if (value != null)
            {
                if (valid)
                {
                    return $"You've traveled {value}.";
                }
            }

            return "You can't go that way.";
        }

        private string PortalIntent(AlexaRequestModel alexaRequestModel)
        {
            return "You entered the portal.";
        }

        private string GetIntent(AlexaRequestModel alexaRequestModel)
        {
            var value = base.GetSlotValue(alexaRequestModel, "item");
            var valid = base.IsSlotValueValid(this.validItems, value);

            if (value != null)
            {
                if (valid)
                {
                    return $"You picked up the {value} and put it in your satchel.";
                }
                else
                {
                    return $"I don't see a {value}.";
                }
            }

            return "What do you want to get?";
        }

        private string UseIntent(AlexaRequestModel alexaRequestModel)
        {
            var value = base.GetSlotValue(alexaRequestModel, "item");
            var valid = base.IsSlotValueValid(this.validItems, value);

            if (value != null)
            {
                if (valid)
                {
                    var action = string.Empty;
                    switch (value)
                    {
                        case "key":
                            {
                                action = "There is nothing to unlock here.";
                                break;
                            }
                        case "rock":
                            {
                                action = "How do you use a rock?";
                                break;
                            }
                        case "knife":
                            {
                                action = "You're now holding the knife.";
                                break;
                            }
                        default:
                            {
                            action = $"You don't have a {value}.";
                            break;
                            }
                    }

                    return action;
                }
                else
                {
                    return $"You don't have a {value}";
                }
            }

            return "What do you want to use?";
        }

        private string DropIntent(AlexaRequestModel alexaRequestModel)
        {
            var value = base.GetSlotValue(alexaRequestModel, "item");
            var valid = base.IsSlotValueValid(this.validItems, value);

            if (value != null)
            {
                if (valid)
                {
                    return $"You dropped the {value}.";
                }
                else
                {
                    return $"You don't have a {value}.";
                }
            }

            return "What do you want to drop?";
        }

    }
}
