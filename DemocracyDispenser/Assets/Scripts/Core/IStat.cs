using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DemocracyDispenser
{
    public interface IStat 
    {
        public float DefaultValue{get;set;}
        public float InUsageValue{get;set;}

        public void UpgradeUsagePercent(float percentAmount);

        public void SetInUsageValue(float amount);
    }
}
