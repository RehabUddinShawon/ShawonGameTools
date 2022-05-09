using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShawonGameTools
{
    public class GameManagementMain : MonoBehaviour
    {
        [SerializeField]
        public bool usePlayerPrefs;
        public int levelIndexDisplayed;
        [SerializeField]
        private int levelDisplayed
        {
            get
            {
                return levelIndexDisplayed + levelIndexToLevelIncrement;
            }
        }
        public int levelIndex;
        [SerializeField]
        int maxLevelIndex;
        public bool sceneRestartOnLevelTransition;
        [SerializeField]
        private bool autoGameStartAtMenuIdleBool;
        private int autoGameStartAtMenuIdleInt;
        public static GameManagementMain instance;
        [Header("levelIndexToLevelConversion")]
        [SerializeField]
        private int levelIndexToLevelIncrement = 1;


        private void Awake()
        {

            instance = this;
            if (usePlayerPrefs)
            {

                levelIndexDisplayed = PlayerPrefs.GetInt("levelIndexDisplayed", 0);
                
            }

            CalculateLevelIndex();

        }
        // Start is called before the first frame update
        void Start()
        {
            Application.targetFrameRate = 60;

            //#if UNITY_EDITOR
            //        Debug.unityLogger.logEnabled = true;
            //#else
            //             Debug.unityLogger.logEnabled=false;
            //#endif
        }

        // Update is called once per frame
        void Update()
        {

        }
        public int GetLevelDisplayed()
        {
            return levelDisplayed;
        }
        public void NextLevelUpdate()
        {
            levelIndexDisplayed += 1;
            PlayerPrefs.SetInt("levelIndexDisplayed", levelIndexDisplayed);
            CalculateLevelIndex();
            if (autoGameStartAtMenuIdleBool)
            {
                SetAutoGameStartInGameAndPlayerPref();
            }

           
        }
        public void LevelUpdateTo(int l)
        {
            levelIndexDisplayed = l;
            PlayerPrefs.SetInt("levelIndexDisplayed", levelIndexDisplayed);
            CalculateLevelIndex();
        }
        void CalculateLevelIndex()
        {
            levelIndex = (levelIndexDisplayed) % (maxLevelIndex + 1);
        }

        public void TimeFreeze()
        {
            Time.timeScale = 0;
        }
        public void TimeUnFreeze()
        {
            Time.timeScale = 1;
        }
        public bool AutoGameStartAtMenuIdleOrNot()
        {
            autoGameStartAtMenuIdleInt = PlayerPrefs.GetInt("autoGameStartAtMenuIdle", 0);
            bool auto = false;
            if(autoGameStartAtMenuIdleInt > 0)
            {
                auto = true;
            }
            return auto;
        }
        public void SetAutoGameStartInGameAndPlayerPref()
        {
            autoGameStartAtMenuIdleInt = 1;
            PlayerPrefs.SetInt("autoGameStartAtMenuIdle", autoGameStartAtMenuIdleInt);
        }

    }
}

