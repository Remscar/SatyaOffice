using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriggerRelay.Logic
{
    public interface IRelayLogic
    {
        Task<string> StoreTrigger(int userId);
        Task<IEnumerable<string>> GetTriggerList(int userId);
    }
}
