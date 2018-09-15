using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using LHGames.DataStructures;

namespace LHGames
{
    public static class AIHelper
    {
        public static string CreateStealAction(Point position)
        {
            return CreateAction("StealAction", position);
        }

        public static string CreateAttackAction(Point position)
        {
            return CreateAction("AttackAction", position);
        }

        public static string CreateCollectAction(Point position)
        {
            return CreateAction("CollectAction", position);
        }

        public static string CreateMoveAction(Point direction)
        {
            return CreateAction("MoveAction", direction);
        }

        public static string CreateUpgradeAction(UpgradeType upgrade)
        {
            return JsonConvert.SerializeObject(new ActionContent("UpgradeAction", upgrade));
        }

        public static string CreatePurchaseAction(PurchasableItem item)
        {
            return JsonConvert.SerializeObject(new ActionContent("PurchaseAction", item));
        }

        public static string CreateHealAction()
        {
            return JsonConvert.SerializeObject(new ActionContent("HealAction"));
        }

        private static string CreateAction(string name, Point target)
        {
            return JsonConvert.SerializeObject(new ActionContent(name, target));
        }
    }
}
