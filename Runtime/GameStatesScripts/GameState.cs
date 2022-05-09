using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShawonGameTools
{
    public class GameState : MonoBehaviour
    {
        public string title;
        public int index = -1;
        public Action actionOnStateTrigger;
        public PanelGameStateScript panelOfThisState;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

