using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShawonGameTools
{
    public class LevelValuesCurrent : MonoBehaviour
    {
        public static LevelValuesCurrent instance;
        public LevelValues.LevelValuesToAssign levelValuesCurrentLevel;

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

        public void AssignRightLevelValuesAsCurrent()
        {
            int levelIndex = GameManagementMain.instance.levelIndex;
            levelValuesCurrentLevel = LevelValues.instance.levelValuesToAssign[levelIndex];
            AppearRightLevelElements(levelIndex);
        }
        public void AppearRightLevelElements(int level)
        {
            for (int i = 0; i < LevelValues.instance.levelValuesToAssign.Length; i++)
            {
                if (i == level)
                {
                
                    //LevelValues.instance.levelValuesToAssign[i].levelHolder.SetActive(true);
                }
                else
                {
                    //LevelValues.instance.levelValuesToAssign[i].levelHolder.SetActive(false);
                }
            }
        }
    }
}

