using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShawonGameTools;
using System;

namespace ShawonGameTools
{
    public class UiButtonsFunctions : MonoBehaviour
    {

        public Action actionOnSceneRestart;
        public static UiButtonsFunctions instance;
        

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
        public void ButtonTapToStart()
        {
            GameStatesControl.instance.ChangeGameStateTo(GameStatesControl.instance.gameStart);
        }
        public void ButtonNextLevel()
        {
            GameManagementMain.instance.NextLevelUpdate();
            LoadNewLevel();
        }
        public void ButtonRetry()
        {
            LoadNewLevel();
        }
        void LoadNewLevel()
        {
            if(GameManagementMain.instance.sceneRestartOnLevelTransition)
            {
               
                actionOnSceneRestart?.Invoke();
                Application.LoadLevel(Application.loadedLevel);
            }
            else
            {
                
                GameStatesControl.instance.ChangeGameStateTo(GameStatesControl.instance.menuIdle);
            }
            
            
        }
    }
}

