﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;


public class SceneController : MonoBehaviour {



    // Use this for initialization
    void Start () {
        QuitOnConnectionErrors();
	}
	
	// Update is called once per frame
	void Update () {
        if (Session.Status != SessionStatus.Tracking)
        {
            int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
            return;
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Camera permission is needed to run this application.", 5));
        }
        else if (Session.Status.IsError())
        {
            StartCoroutine(CodelabUtils.ToastAndExit("ARCore encountered a problem connecting. Please restart the app.", 5));
        }
    }

    void setWeather()
    {
        return;
    }


}

