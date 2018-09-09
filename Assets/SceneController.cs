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

    private String date = "";
    private String temp = "";
    private String humidity = "";
    private String pressure = "";
    private String windSpeed = "";
    private String rainVol = "";
    private String snowVol = "";
    private String warning = "";
    private String precipitation = ""; 

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
        updateInfoBoard(temp, humidity, pressure, windSpeed, rainVol, snowVol, date, warning);
    }

    void QuitOnConnectionErrors()
    {
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            StartCoroutine(CodelabUtils.ToastAndExit("Camera permission is " +
                                                     "needed to run this " +
                                                     "application.", 5));
        }
        else if (Session.Status.IsError())
        {
            StartCoroutine(CodelabUtils.ToastAndExit("ARCore encountered a " +
                                                     "problem connecting. " +
                                                     "Please restart the " +
                                                     "app.", 5));
        }
    }


    public void setWeatherCondition(String precipitationVal) {
        setCloudsActive();
        if (precipitationVal.Equals("rain")) {
            rain.SetActive(true);
        } else if (precipitationVal.Equals("thunderstorm")) {
            rain.SetActive(true);
            setLightingActive();
            flood.SetActive(true);
        } else if (precipitationVal.Equals("snow")) {
            snow.SetActive(true);
        } else if (precipitationVal.Equals("obscured")) {
            fog.SetActive(true);
        }
    }

    private void setCloudsActive() {
        cloud1.SetActive(true);
        cloud2.SetActive(true);
    }

    private void setLightingActive() {
        lightning1.SetActive(true);
        lightning2.SetActive(true);
        lightning3.SetActive(true);
    }

    public void setDate(String date) {
        this.date = date; 
    }

    public void setTemperature(String temp) {
        this.temp = temp;
    }

    public void setHumidity(String humidity) {
        this.humidity = humidity;
    }

    public void setPressure(String pressure) {
        this.pressure = pressure;
    }

    public void setWindSpeed(String windSpeed) {
        this.windSpeed = windSpeed;
    }

    public void setRainVol(String rainVol) {
        this.rainVol = rainVol.ToString(); 
    }

    public void setSnow(String snowVol) {
        this.snowVol = snowVol;
    }

    public void setWarning(String warning){
        this.warning = warning; 
    }

    public void updateInfoBoard(String maxTemp, String humidity, String pressure, String windSpeed,
                        String rain, String snow, String dateTime, String warning) {

        String displayInfo = "Today's date: " + dateTime + "\n" +
                             "Max tempurature: " + maxTemp + "\n" +
                             "Humidity: " + humidity + "\n" +
                             "Pressure: " + pressure + "\n" +
                             "Wind Speed: " + windSpeed + "\n" +
                             "Rain Volume: " + rain + "\n" +
                             "Snow: " + snow + "\n" +
                             "WARNING: " + warning;

        infoBoard.GetComponent<TextMesh>().text = displayInfo;
    }





}

