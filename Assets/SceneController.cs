using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;
using System;

public class SceneController : MonoBehaviour {

    public GameObject lightning1;
    public GameObject lightning2;
    public GameObject lightning3;
    public GameObject rain;
    public GameObject snow;
    public GameObject flood;
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject fog;

    public GameObject infoBoard;

    // Use this for initialization
    void Start () {
        QuitOnConnectionErrors();
        lightning1 = GameObject.Find("SimpleLightningBoltPrefab");
        lightning2 = GameObject.Find("SimpleLightningBoltPrefab (1)");
        lightning3 = GameObject.Find("SimpleLightningBoltPrefab (2)");
        rain = GameObject.Find("Rain");
        snow = GameObject.Find("Snow");
        flood = GameObject.Find("Flooding");
        cloud1 = GameObject.Find("Clouds_Cumulus_G2");
        cloud2 = GameObject.Find("Clouds_Strato_G1");
        fog = GameObject.Find("Fog");
        infoBoard = GameObject.Find("InfoBoard");

        lightning1.SetActive(false);
        lightning2.SetActive(false);
        lightning3.SetActive(false);
        rain.SetActive(false);
        snow.SetActive(false);
        flood.SetActive(false);
        cloud1.SetActive(false);
        cloud2.SetActive(false);
        fog.SetActive(false);


      
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
        updateInfoBoard(3, 4, 5, 6, 6, 2, 2, "asdf");
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

    void setWeather(String info)
    {
        //Cloudy (Cloud)
        //Rain (Rain+cloud)
        //Thunderstorm (Rain+cloud+thunder)
        //Snow (Snow + Cloud)
        //Flooding (Rain+cloud+flood+thunder);
        //Fog (Fod + Cloud);

        //Temperature (2 digit)
        //Humidity(2 digit) 

        //first char is wheather
        
        return;
    }

    public void updateInfoBoard(double maxTemp, int humidity, double pressure, double windSpeed,
                        double rain, double snow, double dateTime, String warning) {

        String displayInfo = "Today's date: " + dateTime.ToString() + "\n" +
                             "Max tempurature: " + maxTemp.ToString() + "\n" +
                             "Humidity: " + humidity.ToString() + "\n" +
                             "Pressure: " + pressure.ToString() + "\n" +
                             "Wind Speed: " + windSpeed.ToString() + "\n" +
                             "Rain Volume: " + rain.ToString() + "\n" +
                             "Snow: " + snow.ToString() + "\n" +
                             "WARNING: " + warning;

        infoBoard.GetComponent<TextMesh>().text = displayInfo;
    }





}

