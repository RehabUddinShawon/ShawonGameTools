using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShawonGameTools;

public class EditorScriptFunctions : MonoBehaviour
{
    public GameObject panelState;
    public GameStatesControl gameStatesControl;
    public UiPanelsControlAccordingToStates uiPanelsControlAccordingToStates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MakeGameStatesList()
    {
        gameStatesControl.MakeListSerially();
    }
    public void GenerateStatePanels()
    {
        
        //uiPanelsControlAccordingToStates.panelStates.Clear();
        //for (int i = 0; i < gameStatesControl.gameStatesSeriallyListed.Count; i++)
        //{
        //    if(gameStatesControl.gameStatesSeriallyListed[i].panelOfThisState == null)
        //    {
        //        GameObject go = Instantiate(panelState, uiPanelsControlAccordingToStates.statePanelsHolder.gameObject.transform.position, uiPanelsControlAccordingToStates.statePanelsHolder.gameObject.transform.rotation);
        //        go.transform.SetParent(uiPanelsControlAccordingToStates.statePanelsHolder.gameObject.transform);
        //        go.name = "panel" + gameStatesControl.gameStatesSeriallyListed[i].title;
        //        gameStatesControl.gameStatesSeriallyListed[i].panelOfThisState = go.GetComponent<PanelGameStateScript>();
        //        go.GetComponent<PanelGameStateScript>().InitialTasks(gameStatesControl.gameStatesSeriallyListed[i].title, i);
        //        uiPanelsControlAccordingToStates.panelStates.Add(go);
        //    }
        //    else
        //    {
        //        uiPanelsControlAccordingToStates.panelStates.Add(gameStatesControl.gameStatesSeriallyListed[i].panelOfThisState.gameObject);
        //    }
        //
        //    
        //}
    }
}
