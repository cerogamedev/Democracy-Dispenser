using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DemocracyDispenser
{
    public class Wallet : MonoSingleton<Wallet>
    {
        public int Diamond;
        public TextMeshProUGUI DiamondText;
        void Start()
        {
            Diamond = 0;
        }

        // Update is called once per frame
        void Update()
        {
            DiamondText.text = Diamond.ToString();
        }
    }
}
