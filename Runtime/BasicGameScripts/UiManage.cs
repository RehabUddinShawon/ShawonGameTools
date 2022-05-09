using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ShawonGameTools;

namespace ShawonGameTools
{
    public class UiManage : MonoBehaviour
    {
        public GameObject[] panelsSuccess;
        public GameObject[] panelsFail;
        public Text[] levelNumberTexts;
        public Text[] dollarTexts;
        //public Text speedoMeterText;
        public Slider sliderLevelCompletion;
        public Slider sliderPlayerHealth;

        public static UiManage instance;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            LevelResultEvaluationSystem.instance.actionLevelSuccess += AppearSuccessPanels;
            LevelResultEvaluationSystem.instance.actionLevelFail += AppearFailPanels;
            GameStatesControl.instance.menuIdle.actionOnStateTrigger += LevelNumberTextsUpdate;

            //LevelManager.instance.actionLevelCompleteionValueUpdate += SliderLevelCompletionUpdate;

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AppearSuccessPanels()
        {
            for (int i = 0; i < panelsSuccess.Length; i++)
            {
                panelsSuccess[i].SetActive(true);
            }
            for (int i = 0; i < panelsFail.Length; i++)
            {
                panelsFail[i].SetActive(false);
            }
        }
        public void AppearFailPanels()
        {
            for (int i = 0; i < panelsSuccess.Length; i++)
            {
                panelsSuccess[i].SetActive(false);
            }
            for (int i = 0; i < panelsFail.Length; i++)
            {
                panelsFail[i].SetActive(true);
            }
        }
        public void LevelNumberTextsUpdate()
        {
            for (int i = 0; i < levelNumberTexts.Length; i++)
            {
                levelNumberTexts[i].text = "LEVEL " + (GameManagementMain.instance.levelIndexDisplayed + 1);
            }
        }
        public void DollarTextsUpdate(float dollatValue)
        {
            for (int i = 0; i < dollarTexts.Length; i++)
            {
                dollarTexts[i].text = "" + (dollatValue);
            }
        }
        //public void SpeedometerTextUpdate(float speed)
        //{
        //    speedoMeterText.text = speed + "";
        //}
        public void SliderLevelCompletionUpdate(float f)
        {
            if (sliderLevelCompletion != null)
                sliderLevelCompletion.value = f;
        }
        public void SliderPlayerHealthCompletionUpdate(float f)
        {
            if (sliderPlayerHealth != null)
                sliderPlayerHealth.value = f;
        }
    }
}

