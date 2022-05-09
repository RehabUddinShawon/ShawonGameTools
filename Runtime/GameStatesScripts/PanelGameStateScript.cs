using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using UnityEngine.Events;

namespace ShawonGameTools
{
    public class PanelGameStateScript : MonoBehaviour
    {
        public int uiStateIndex;
        public Text textTitle;
        public List<Image> imagesUnderPanel;
        public Text[] textsUnderPanel;
        public Image imageTouchBlock;

        private void Awake()
        {
            Image[] imagesUnderPanelArray = GetComponentsInChildren<Image>();
            imagesUnderPanel = new List<Image>(imagesUnderPanelArray);
            imagesUnderPanel.Remove(imageTouchBlock);
            textsUnderPanel = GetComponentsInChildren<Text>();
        }
        // Start is called before the first frame update
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }
        public void BlockTouch()
        {
            imageTouchBlock.gameObject.SetActive(true);
        }
        public void UnBlockTouch()
        {
            imageTouchBlock.gameObject.SetActive(false);
        }
        //public void ChangeStateTo()
        //{
        //    int i = uiStateIndex + 1;
        //    if(i == GameStatesControl.instance.gameStatesSeriallyListed.Count)
        //    {
        //        i = 1;
        //    }
        //    GameStatesControl.instance.ChangeGameStateTo(GameStatesControl.instance.gameStatesSeriallyListed[i]);
        //}
        public void InitialTasks(string s, int i)
        {
            textTitle.text = s;
            uiStateIndex = i;
        }

        public void SetPanelTransparencyTo(float f)
        {
            for (int i = 0; i < imagesUnderPanel.Count; i++)
            {
                Color c = imagesUnderPanel[i].color;
                c.a = f;
                imagesUnderPanel[i].color = c;
            }
            for (int i = 0; i < textsUnderPanel.Length; i++)
            {
                Color c = textsUnderPanel[i].color;
                c.a = f;
                textsUnderPanel[i].color = c;
            }
        }
        public void PanelTransitionFadeOut()
        {
            PanelGameStateScript a = this;
            GameObject go = a.gameObject;
            SmoothGainValuesManager.instance.TransitionValueSetTo(1, 0,
                () => {
                    go.SetActive(true);
                    a.SetPanelTransparencyTo(1);
                    BlockTouch();
                },
                (float f) => {
                    a.SetPanelTransparencyTo(f);

                },
                () => {

                    go.SetActive(false);
                    Debug.Log("Complete");
                    UnBlockTouch();

                }, 2f);
        }
        public void PanelTransitionFadeIn()
        {
            PanelGameStateScript a = this;
            GameObject go = a.gameObject;
            SmoothGainValuesManager.instance.TransitionValueSetTo(0, 1,
                () => {
                    go.SetActive(true);
                    a.SetPanelTransparencyTo(0);
                    BlockTouch();
                }, (
                float f) => {
                    a.SetPanelTransparencyTo(f);

                },
                () => {
                    Debug.Log("Complete2");
                    UnBlockTouch();

                }, 2f);



        }
        public void PanelTransitionLeftToIn()
        {
            PanelGameStateScript a = this;
            GameObject go = a.gameObject;
            a.SetPanelTransparencyTo(1);
            SmoothGainValuesManager.instance.TransitionValueSetTo(-Screen.width, 0,
                () => {
                    go.SetActive(true);
                    go.transform.localPosition = new Vector3(-Screen.width, 0, 0);
                    BlockTouch();
                },
                (float f) => {

                    go.transform.localPosition = new Vector3(f, 0, 0);
                },
                () => {
                //go.SetActive(false);
                Debug.Log("Complete2");
                    UnBlockTouch();
                }, 2f);
        }
        public void PanelTransitionCenterToOut()
        {
            PanelGameStateScript a = this;
            GameObject go = a.gameObject;
            a.SetPanelTransparencyTo(1);
            SmoothGainValuesManager.instance.TransitionValueSetTo(0, Screen.width,
                () => {
                    go.SetActive(true);
                    go.transform.localPosition = new Vector3(0, 0, 0);
                    BlockTouch();
                },
                (float f) => {

                    go.transform.localPosition = new Vector3(f, 0, 0);
                },
                () => {
                    go.SetActive(false);
                    Debug.Log("Complete");
                    UnBlockTouch();
                }, 2f);
        }
        public void PanelTransitionInstantOut()
        {
            gameObject.SetActive(false);
        }
        public void PanelTransitionInstantIn()
        {
            gameObject.SetActive(true);
            UnBlockTouch();
        }

    }
}

