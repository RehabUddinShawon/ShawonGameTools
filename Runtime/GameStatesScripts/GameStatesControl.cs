using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShawonGameTools
{
    public class GameStatesControl : MonoBehaviour
    {
        public static GameStatesControl instance;

        public GameState gameStateCurrent;
        [Header("DefinedStates")]
        public GameState initialization;
        public GameState menuIdle;
        public GameState gameStart;
        public GameState levelStart;
        public GameState gamePlay;
        public GameState levelResult;
        //public GameState levelSuccessOrFail;
        public GameState levelEnd;
        //[Header("List of States Serially")]
        //[SerializeField]
        //public List<GameState> gameStatesSeriallyListed;
        bool init;
        public Action actionLevelStartAnalyticsCall;
        public Action actionLevelCompletedAnalyticsCall;
        public Action actionLevelFailedAnalyticsCall;
        //int lastLevelIndex = -1;
        //[System.Serializable]
        //public class GameState
        //{
        //    public string title;
        //    public int index = -1;
        //    public Action actionOnStateTrigger;
        //    public PanelGameStateScript panelOfThisState;
        //
        //}
        public Action<int> actionOnNewStateIndex;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            //MakeListSerially();
            InitialTasks();
            AssignFuntionsOfUi();

        }

        // Update is called once per frame
        void Update()
        {
            if (!init)
            {
                init = true;
                ChangeGameStateTo(initialization);
            }
        }
        public void MakeListSerially()
        {
            //gameStatesSeriallyListed.Clear();
            List<GameState> list = new List<GameState>();
            list.Add(initialization);
            list.Add(menuIdle);
            list.Add(gameStart);
            list.Add(levelStart);
            list.Add(gamePlay);
            list.Add(levelResult);
            list.Add(levelEnd);


            //gameStatesSeriallyListed = new List<GameState>(list);
        }
        public void ChangeGameStateToDelayed(GameState state, float f)
        {
            StartCoroutine(ChangeStateCoroutine(state, f));
        }
        IEnumerator ChangeStateCoroutine(GameState state, float f)
        {
            yield return new WaitForSeconds(f);
            ChangeGameStateTo(state);
        }
        public void ChangeGameStateTo(GameState state)
        {
            if (state == gameStateCurrent)
            {
                return;
            }
            gameStateCurrent = state;
            int ind = gameStateCurrent.index;
            actionOnNewStateIndex?.Invoke(ind);

            if (ind == initialization.index)
            {
                initialization.actionOnStateTrigger?.Invoke();
                ChangeGameStateTo(menuIdle);
            }
            else if (ind == menuIdle.index)
            {
                menuIdle.actionOnStateTrigger?.Invoke();

                if (GameManagementMain.instance.AutoGameStartAtMenuIdleOrNot())
                {
                    ChangeGameStateTo(gameStart);
                }
            }
            else if (ind == gameStart.index)
            {
                gameStart.actionOnStateTrigger?.Invoke();
                ChangeGameStateTo(levelStart);

            }
            else if (ind == levelStart.index)
            {
                levelStart.actionOnStateTrigger?.Invoke();
                ChangeGameStateTo(gamePlay);

                LevelStartOrRestartAnalyticsCall();

            }
            else if (ind == gamePlay.index)
            {
                gamePlay.actionOnStateTrigger?.Invoke();
            }
            else if (ind == levelResult.index)
            {
                levelResult.actionOnStateTrigger?.Invoke();
                LevelSuccededOrFailAnalyticsCall();
            }

            else if (ind == levelEnd.index)
            {
                levelEnd.actionOnStateTrigger?.Invoke();
            }


        }
        public void InitialTasks()
        {
            //MakeListSerially();
            if (UiPanelsControlAccordingToStates.instance != null)
            {
                UiPanelsControlAccordingToStates.instance.PreparePanelStatesList();
                UiPanelsControlAccordingToStates.instance.gameStatesControl = this;
            }
        }
        public void AssignFuntionsOfUi()
        {
            if (UiPanelsControlAccordingToStates.instance != null)
            {
                actionOnNewStateIndex += UiPanelsControlAccordingToStates.instance.AppearPanelState;
            }
        }

        public void LevelStartOrRestartAnalyticsCall()
        {
            actionLevelStartAnalyticsCall?.Invoke();
            //if (AnalyticsCallsManagerInProject.instance != null) { AnalyticsCallsManagerInProject.instance.AnalyticsCallLevelStarted(); }
            //int levelInd = GameManagementMain.instance.levelIndexDisplayed;
            //if(levelInd == lastLevelIndex)
            //{
            //    if (AnalyticsCallsManagerInProject.instance != null) { AnalyticsCallsManagerInProject.instance.AnalyticsCallLevelRestart(); }
            //}
            //else
            //{
            //    if (AnalyticsCallsManagerInProject.instance != null) { AnalyticsCallsManagerInProject.instance.AnalyticsCallLevelStarted(); }
            //}
            //lastLevelIndex = levelInd;
        }
        public void LevelSuccededOrFailAnalyticsCall()
        {

            switch (LevelResultEvaluationSystem.instance.levelResultCurrent)
            {
                case LevelResultEvaluationSystem.LevelResultType.Success:
                    {
                        actionLevelCompletedAnalyticsCall?.Invoke();
                        //if (AnalyticsCallsManagerInProject.instance != null) { AnalyticsCallsManagerInProject.instance.AnalyticsCallLevelCompleted(); }
                        break;
                    }
                case LevelResultEvaluationSystem.LevelResultType.Fail:
                    {
                        actionLevelFailedAnalyticsCall?.Invoke();
                        //if (AnalyticsCallsManagerInProject.instance != null) { AnalyticsCallsManagerInProject.instance.AnalyticsCallLevelFailed(); }
                        break;
                    }
            }

        }
    }
}

