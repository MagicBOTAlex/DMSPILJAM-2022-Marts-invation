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
        public GameObject Overlay;
        public float Cooldown;
        public float curCooldown;

    }
}
