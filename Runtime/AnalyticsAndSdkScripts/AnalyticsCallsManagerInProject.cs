using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Facebook.Unity;
using ShawonGameTools;
//using GameAnalyticsSDK;
//using com.adjust.sdk;
//using LionStudios.Suite.Analytics;
//using LionStudios.Suite.Debugging;


public class AnalyticsCallsManagerInProject : MonoBehaviour
{
    //public static AnalyticsCallsManagerInProject instance;
    private void Awake()
    {
        //instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    LionDebugger.Hide();
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}
    //
    public void AnalyticsCallLevelStarted()
    {
        //if (GameManagementMain.instance == null)
        //{
        //    return;
        //}
        //int level = GameManagementMain.instance.levelIndexDisplayed + 1;
        ////FB.LogAppEvent("Level Start",level);
        //
        ////AdjustEvent adjustEvent = new AdjustEvent("LevelStarted "+ level);
        ////Adjust.trackEvent(adjustEvent);
        //
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
        //LionAnalytics.LevelStart(level, 0, 0);
        //Debug.Log("LevelStarted " + level);
    }
    public void AnalyticsCallLevelCompleted()
    {
        //if (GameManagementMain.instance == null)
        //{
        //    return;
        //}
        //int level = GameManagementMain.instance.levelIndexDisplayed + 1;
        //
        //
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
        //LionAnalytics.LevelComplete(level, 0, 0);
        //Debug.Log("LevelCompleted " + level);
    }
    public void AnalyticsCallLevelFailed()
    {
        //if (GameManagementMain.instance == null)
        //{
        //    return;
        //}
        //int level = GameManagementMain.instance.levelIndexDisplayed + 1;
        //
        //
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
        //LionAnalytics.LevelFail(level, 0, 0);
        //Debug.Log("LevelFailed " + level);
    }
    public void AnalyticsCallLevelRestart()
    {
        //if (GameManagementMain.instance == null)
        //{
        //    return;
        //}
        //int level = GameManagementMain.instance.levelIndexDisplayed + 1;
        ////FB.LogAppEvent("Level Start", level);
        //
        ////AdjustEvent adjustEvent = new AdjustEvent("LevelStarted "+ level);
        ////Adjust.trackEvent(adjustEvent);
        //
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
        //LionAnalytics.LevelRestart(level, 0, 0);
    }
}
