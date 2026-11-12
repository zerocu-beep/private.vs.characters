using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Serializable]
    public class DriverNavmeshArea
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private int m_Area;
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public int Area => this.m_Area;
    }
}