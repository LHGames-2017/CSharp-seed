using LHGames.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace LHGames.DataStructures
{
    public enum ActionTypes
    {
        DefaultAction,
        MoveAction,
        AttackAction,
        CollectAction,
        UpgradeAction,
        StealAction,
        PurchaseAction,
        HealAction
    }

    public enum UpgradeType
    {
        CarryingCapacity,
        AttackPower,
        Defence,
        MaximumHealth,
        CollectingSpeed
    }

    public enum PurchasableItem
    {
        MicrosoftSword,
        UbisoftShield,
        DevolutionsBackpack,
        DevolutionsPickaxe,
        HealthPotion,
    }

    // DO NO REORDER THIS, make sure it matches the typescript tile enum.
    public enum TileType
    {
        Tile,
        Wall,
        House,
        Lava,
        Resource,
        Shop
    }

    public struct GameInfo
    {
        public IPlayer Player;
        public string CustomSerializedMap;
        public List<KeyValuePair<string, PublicPlayerInfo>> OtherPlayers;
        public int xMin;
        public int yMin;
    }

    public class Tile
    {
        public TileType TileType { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public Tile(byte content, int x, int y)
        {
            TileType = (TileType)content;
            X = x;
            Y = y;
        }
    }

    public interface IPlayer
    {
        int Health { get; }
        int MaxHealth { get; }
        int CarriedResources { get; }
        int CarryingCapacity { get; }
        int TotalResources { get; }
        int AttackPower { get; }
        int Defence { get; }
        Point Position { get; }
        Point HouseLocation { get; }
        int Score { get; }
        string Name { get; }
    }

    public struct PublicPlayerInfo
    {
        public PublicPlayerInfo(int health, int maxHealth, Point position)
        {
            Health = health;
            MaxHealth = maxHealth;
            Position = position;
        }

        public int Health;
        public int MaxHealth;
        public Point Position;
    }
}
