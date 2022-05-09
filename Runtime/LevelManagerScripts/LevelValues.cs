using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShawonGameTools
{
    public class LevelValues : MonoBehaviour
    {
        public static LevelValues instance;


        [System.Serializable]
        public class LevelValuesToAssign
        {
            public string title;
            public GameObject playerInitialTransformRef;
            //public GameObject richInitialTransformRef;
            public GameObject levelHolder;
            //public MakePathFromGuides richPathToFollow     ;
            public GameObject triggersThisLevel;
            
            public int playerInitialCount;
            public float playerInitialFood;
            public float playerInitialWater;
        }
        public LevelValuesToAssign[] levelValuesToAssign;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void EnableRightLevelElements(int l)
        {
            for (int i = 0; i < levelValuesToAssign.Length; i++)
            {
                if (i == l)
                {

                }
                else
                {

                }
            }
        }
    }
}

