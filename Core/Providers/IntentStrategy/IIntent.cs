using Common.Models;

namespace Core.Providers.IntentStrategy
{
    internal interface IIntent
    {
        void Execute(IntentModel intentModel);
    }
}