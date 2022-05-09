using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShawonGameTools
{
    public class LevelResultEvaluationSystem : MonoBehaviour
    {
        public static LevelResultEvaluationSystem instance;
        public enum LevelResultType
        {
            Success, Fail , NotYetDeterMined
        }
        public LevelResultType levelResultCurrent;
        public Action actionLevelSuccess;
        public Action actionLevelFail;
        public Action actionLevelResultNotYetDetermined;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            GameStatesControl.instance.menuIdle.actionOnStateTrigger += InitialTasks;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void SetLevelResultTo(LevelResultType l)
        {
            levelResultCurrent = l;
            switch (levelResultCurrent)
            {
                case LevelResultType.Success:
                    {
                        actionLevelSuccess?.Invoke();

                        break;
                    }
                case LevelResultType.Fail:
                    {
                        actionLevelFail?.Invoke();

                        break;
                    }
                case LevelResultType.NotYetDeterMined:
                    {
                        actionLevelResultNotYetDetermined?.Invoke();

                        break;
                    }
            }
        }
        public void InitialTasks()
        {
            SetLevelResultTo(LevelResultType.NotYetDeterMined);
        }
        public void SetLevelResultToSuccess()
        {
            SetLevelResultTo(LevelResultType.Success);
            GameStatesControl.instance.ChangeGameStateToDelayed(GameStatesControl.instance.levelResult, 1);
            GameStatesControl.instance.ChangeGameStateToDelayed(GameStatesControl.instance.levelEnd, 2f);
        }
        public void SetLevelResultToFail()
        {
            SetLevelResultTo(LevelResultType.Fail);
            GameStatesControl.instance.ChangeGameStateToDelayed(GameStatesControl.instance.levelResult, 1);
            GameStatesControl.instance.ChangeGameStateToDelayed(GameStatesControl.instance.levelEnd, 2f);
        }
        public void SetLevelResultToNotYetDetermined()
        {
            SetLevelResultTo(LevelResultType.NotYetDeterMined);
            
        }
    }
}

