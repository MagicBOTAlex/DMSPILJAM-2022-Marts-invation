using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public enum TowerType
    {
        Player,
        Neutral,
        Enemy
    }

    public class TowerInfo
    {
        public GameObject Object;
        public int TowerLevel;
        public int UnitsInside;
        public TowerType Type;
        public int IndexInList;
        public int MaxUnits;
    }

    public class AbillityInfo
    {
        public string AbillityName;
        public GameObject Overlay;
        public float Cooldown;
        public float curCooldown;
        public float FraqScale; // 1% of its original y-scale
        public float Dist2Center;
        public bool IsCooling;
        public Vector2 StartPos;

    }
}
