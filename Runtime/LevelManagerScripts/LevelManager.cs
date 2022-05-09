using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShawonGameTools
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;
        public Action<int> actionLevelInitialization;
        public Action actionAfterLevelInitialization;
        public Action<int> actionLevelStart;
        public float levelCompletionValue;
        public Action<float> actionLevelCompleteionValueUpdate;
        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            GameStatesControl.instance.menuIdle.actionOnStateTrigger += LevelInitilizationFun;
            GameStatesControl.instance.gamePlay.actionOnStateTrigger += LevelStartFun;
            GameStatesControl.instance.gamePlay.actionOnStateTrigger += LevelCompletionDetect;

        }

        // Update is called once per frame
        void Update()
        {
            //LevelCompletionDetect();
        }
        public void LevelInitilizationFun()
        {
            LevelValuesCurrent.instance.AssignRightLevelValuesAsCurrent();

            actionLevelInitialization?.Invoke(GameManagementMain.instance.levelIndex);
            actionAfterLevelInitialization?.Invoke();

        }
        public void LevelStartFun()
        {
            actionLevelStart?.Invoke(GameManagementMain.instance.levelIndex);

        }
        public void LevelCompletionDetect()
        {
            
            actionLevelCompleteionValueUpdate?.Invoke(levelCompletionValue);
        }
    }
}

