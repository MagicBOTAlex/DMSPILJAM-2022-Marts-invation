using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public enum BuildingType
    {
        Player,
        Neutral,
        Enemy
    }

    public struct TowerInfo
    {
        public GameObject Object;
        public int TowerLevel;
        public int UnitsInside;
        public BuildingType Type;
        public int IndexInList;
    }
}
