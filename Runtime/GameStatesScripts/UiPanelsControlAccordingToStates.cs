using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShawonGameTools
{
    public class UiPanelsControlAccordingToStates : MonoBehaviour
    {
        public List<GameObject> panelStates;
        public GameObject panelStateCurrent;
        public static UiPanelsControlAccordingToStates instance;
        public GameObject statePanelsHolder;
        public GameStatesControl gameStatesControl;
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
        public void PreparePanelStatesList()
        {
            int childCount = statePanelsHolder.transform.childCount;
            //for (int i = 0; i < childCount && theComponent == null; ++i)
            //{
            //    GameObject child = transform.GetChild(i).gameObject;
            //    if (!child.activeSelf)
            //        theComponent = child.GetComponent<TheComponentYouWant>();
            //}
            //PanelGameStateScript[] panels = statePanelsHolder.GetComponentsInChildren<PanelGameStateScript>();

            for (int i = 0; i < childCount; i++)
            {
                panelStates.Add(statePanelsHolder.transform.GetChild(i).gameObject);
            }

        }
        public void AppearPanelState(int index)
        {
            for (int i = 0; i < panelStates.Count; i++)
            {

                if (i == index)
                {
                    //panelStates[i].SetActive(true);
                }
                else if (panelStateCurrent != null && panelStates[i] == panelStateCurrent)
                {
                    //panelStates[i].SetActive(true);
                }
                else
                {
                    panelStates[i].SetActive(false);
                }


            }

            if (panelStateCurrent != null)
            {
                panelStateCurrent.GetComponent<PanelGameStateScript>().PanelTransitionInstantOut();
                //panelStates[index].GetComponent<PanelGameStateScript>().PanelTransitionFadeOut();
            }

            //panelStates[index].GetComponent<PanelGameStateScript>().PanelTransitionFadeIn();
            panelStates[index].GetComponent<PanelGameStateScript>().PanelTransitionInstantIn();
            panelStateCurrent = panelStates[index];


        }

    }
}

