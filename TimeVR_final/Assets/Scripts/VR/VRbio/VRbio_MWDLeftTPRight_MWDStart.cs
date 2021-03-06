using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class VRbio_MWDLeftTPRight_MWDStart : MonoBehaviour
{
    private GameObject slowCameraScript;
    private LoggingSystem logger;
    private GameObject gyroscope;

    public AudioSource audioSource;
    // Zeit nach der Fixationskreuz verschwindet
    public int fixationTimeBeforeSignal;
    public int fixationTimeAfterSignal;


    // creating variables for logging
    public String id;
    private String condition = "VRbio";
    public String blockNumber;
    private String task;
    private String trial;
    private String timeIntervall;
    private String blockStart;
    private String blockEnd;
    private String blockStartFormat = "yyyy-MM-dd_HH-mm-ss";
    private String trialStart;
    private String press1;
    private String press2;
    private String timeToStart;
    private String estimation;


    private float press1Float;
    private float press2Float;
    private float trialStartFloat;
    private float timeToStartFloat;
    private float estimationFloat;

    

    //public GameObject screenRight Arrows for Filling Levels;
    private GameObject _screenLeftArrowA;
    private GameObject _screenLeftArrowB;
    private GameObject _screenLeftArrowC;
    private GameObject _screenLeftArrowD;

    //public GameObject screenLeft Numbers for Time Production;
    private GameObject _screenRightNumberA;
    private GameObject _screenRightNumberB;
    private GameObject _screenRightNumberC;
    private GameObject _screenRightNumberD;


    private GameObject fixationCrossLeft;
    private GameObject fixationCrossRight;


    //public Material greyMaterial;
    //public Material greenMaterial;
    public Material[] material;
    private Renderer _rendScreenRight;
    private Renderer _rendScreenLeft;
    private int _x;
    private int _spaceKeyCodeCounter;


    private int _taskNumber;
    private int _testCounter;
    private int frameCounter;

    private GameObject[] screenRightNumbers;
    private GameObject[] screenRightNumbers2;
    private GameObject[] screenRightNumbers3;
    private GameObject[] screenRightNumbers4;
    private GameObject[] screenRightNumbers5;

    //private GameObject[] screenRightNumbers;
    //private GameObject[] screenLeftArrows;
    private GameObject[] screenLeftArrows;
    private GameObject[] screenLeftArrows2;
    private GameObject[] screenLeftArrows3;
    private GameObject[] screenLeftArrows4;
    private GameObject[] screenLeftArrows5;

    private GameObject screenLeft;
    

    private GameObject screenRight;
    

    private int numberIndex;
    private int arrowIndex;

    

    

    // Start is called before the first frame update
    void Start()
    {

        slowCameraScript = GameObject.FindGameObjectWithTag("MainCamera");
        

        //testObject = GameObject.Find("CanvasLeft").transform.GetChild(4).gameObject;
        //testObject.SetActive(false);

        _taskNumber = 1;
        _testCounter = 0;
        frameCounter = 0;


        logger = GameObject.Find("LoggingSystem").GetComponent<LoggingSystem>();
        if (logger == null)
            Debug.Log("[LoggingDemo] Unable to set reference to Logging System.");

        gyroscope = GameObject.FindWithTag("MainCamera");

        _x = 0;
        _spaceKeyCodeCounter = 0;

        screenLeft = GameObject.Find("LeftMonitor").transform.GetChild(0).gameObject;
        /*
        screenLeftB = GameObject.Find("ScreenLeftB");
        screenLeftC = GameObject.Find("ScreenLeftC");
        screenLeftD = GameObject.Find("ScreenLeftD");
        */

        screenRight = GameObject.Find("RightMonitor").transform.GetChild(0).gameObject;
        /*
        screenRightB = GameObject.Find("ScreenRightB");
        screenRightC = GameObject.Find("ScreenRightC");
        screenRightD = GameObject.Find("ScreenRightD");
        */


        // right screens
        _screenRightNumberA = GameObject.Find("CanvasRight").transform.GetChild(4).gameObject;
        _screenRightNumberB = GameObject.Find("CanvasRight").transform.GetChild(5).gameObject;
        _screenRightNumberC = GameObject.Find("CanvasRight").transform.GetChild(6).gameObject;
        _screenRightNumberD = GameObject.Find("CanvasRight").transform.GetChild(7).gameObject;

        // left screens
        _screenLeftArrowA = GameObject.Find("CanvasLeft").transform.GetChild(0).gameObject;
        _screenLeftArrowB = GameObject.Find("CanvasLeft").transform.GetChild(1).gameObject;
        _screenLeftArrowC = GameObject.Find("CanvasLeft").transform.GetChild(2).gameObject;
        _screenLeftArrowD = GameObject.Find("CanvasLeft").transform.GetChild(3).gameObject;


        // fixation crosses
        fixationCrossRight = GameObject.Find("FixationskreuzRechts");
        fixationCrossLeft = GameObject.Find("FixationskreuzLinks");


        _screenRightNumberA.SetActive(false);
        _screenRightNumberB.SetActive(false);
        _screenRightNumberC.SetActive(false);
        _screenRightNumberD.SetActive(false);

        _screenLeftArrowA.SetActive(false);
        _screenLeftArrowB.SetActive(false);
        _screenLeftArrowC.SetActive(false);
        _screenLeftArrowD.SetActive(false);

        fixationCrossLeft.SetActive(false);
        fixationCrossRight.SetActive(false);


        // instantiate text arrays
        screenRightNumbers = new GameObject[]
            {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers2 = new GameObject[]
            {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers3 = new GameObject[]
            {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers4 = new GameObject[]
            {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers5 = new GameObject[]
            {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};

        screenLeftArrows = new GameObject[]
            {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows2 = new GameObject[]
            {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows3 = new GameObject[]
            {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows4 = new GameObject[]
            {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows5 = new GameObject[]
            {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};

        /*
        // instantiate Screen arrays
        screenLeft = new GameObject[] {screenLeftA, screenLeftB, screenLeftC, screenLeftD};
        screenLeft2 = new GameObject[] {screenLeftA, screenLeftB, screenLeftC, screenLeftD};
        screenLeft3 = new GameObject[] {screenLeftA, screenLeftB, screenLeftC, screenLeftD};
        screenLeft4 = new GameObject[] {screenLeftA, screenLeftB, screenLeftC, screenLeftD};
        screenLeft5 = new GameObject[] {screenLeftA, screenLeftB, screenLeftC, screenLeftD};
        
        screenRight = new GameObject[] {screenRightA, screenRightB, screenRightC, screenRightD};
        screenRight2 = new GameObject[] {screenRightA, screenRightB, screenRightC, screenRightD};
        screenRight3 = new GameObject[] {screenRightA, screenRightB, screenRightC, screenRightD};
        screenRight4 = new GameObject[] {screenRightA, screenRightB, screenRightC, screenRightD};
        screenRight5 = new GameObject[] {screenRightA, screenRightB, screenRightC, screenRightD};
        */

        screenLeft.SetActive(true);
        screenRight.SetActive(true);

        _rendScreenLeft = screenLeft.GetComponent<Renderer>();
        _rendScreenLeft.enabled = true;
        // Screen Links wird wei??
        _rendScreenLeft.sharedMaterial = material[0];


        _rendScreenRight = screenRight.GetComponent<Renderer>();
        _rendScreenRight.enabled = true;
        // Screen Rechts wird wei??
        _rendScreenRight.sharedMaterial = material[0];


        StartCoroutine(waiter());


        blockStart = System.DateTime.UtcNow.ToString(blockStartFormat);
        trialStart = Time.realtimeSinceStartup.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter2());


        // Logging Position and Rotation of VR-Headset in extra csv-File
        //string positionString = "" + gyroscope.transform.position;
        //string rotationString = "" + gyroscope.transform.localEulerAngles;

        // Aufteilung der Logs in die einzelnen Frames
        //logger.writeMessageToLogGyroscope("Frame " + frameCounter);

        // writing position into Log-File
        //logger.writeMessageWithTimestampToLogGyroscope("GYROSCOPE", "Position", positionString);
        // writing rotation into Log-File
        //logger.writeMessageWithTimestampToLogGyroscope("GYROSCOPE", "Rotation", rotationString);

        //frameCounter += 1;
    }

    /*
    void ChangeMaterialLeftScreen()
    {
        _x += 1;
        _rendScreenLeft.sharedMaterial = material[_x];
    }
    
    void ChangeMaterialRightScreen()
    {
        _x += 1;
        _rendScreenRight.sharedMaterial = material[_x];
    }
    
    
    
    
    void FixationRight()
    {
        StartCoroutine(RemoveAfterSeconds(fixationTime, fixationCrossRight));
    }
    
    void FixationLeft()
    {
        StartCoroutine(RemoveAfterSeconds(fixationTime, fixationCrossLeft));
    }
    
    */

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);

        /*
        // In dieser Szene fange wir mit TP an!
        numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);
        print(numberIndex);

        screenLeftNumbers[numberIndex].SetActive(true);
        _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
        _rendScreenLeft.enabled = true;
        _rendScreenLeft.sharedMaterial = material[_x];
        
        */
    }


    IEnumerator waiter()
    {

        fixationCrossLeft.SetActive(true);
        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
        audioSource.Play();
        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
        fixationCrossLeft.SetActive(false);
        // In dieser Szene fange wir mit TP an!
        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);
        print(arrowIndex);
        if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
        {
            screenLeftArrows[arrowIndex].SetActive(true);

            //slowCameraScript.GetComponent<SlowMotion>().switchTrackedPoseDriverOnOff();
            //yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
            ////slowCameraScript.GetComponent<SlowMotion>().switchBoolean();
            //slowCameraScript.GetComponent<SlowMotion>().switchTrackedPoseDriverOnOff();
            //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

            //timeToStart = Time.realtimeSinceStartup.ToString();
            trialStart = Time.realtimeSinceStartup.ToString();
            timeIntervall = screenLeftArrows[arrowIndex].name;
        }
    }

    IEnumerator waiter2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (_spaceKeyCodeCounter)
            {
                case 0:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");

                        // write headings to logfile
                        logger.writeHeadings();
                        

                        task = "MWD";
                        trial = "1";
                        press1 = Time.realtimeSinceStartup.ToString();
                        //trialStart = Time.realtimeSinceStartup.ToString();


                        //logger.writeMessageToLog("Aufgabe 1");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");


                        Debug.Log("Spacebar pressed");
                        //ChangeMaterialLeftScreen();
                        _rendScreenLeft.sharedMaterial = material[1];
                    }

                    break;
                case 1:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute difference
                        estimationFloat = press2Float - press1Float;
                        timeToStartFloat = press1Float - trialStartFloat;

                        // convert back to string
                        estimation = estimationFloat.ToString("N");
                        timeToStart = timeToStartFloat.ToString("N");

                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                        screenLeftArrows[arrowIndex].SetActive(false);

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                        // numberIndex berechnen
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        ////slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        // berechneten Screen aktiv setzen
                        screenRightNumbers[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 2:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 2");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                        task = "TP";
                        trial = "1";
                        press1 = Time.realtimeSinceStartup.ToString();

                        //ChangeMaterialRightScreen();
                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 3:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();


                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 4:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 3");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "2";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }

                    break;
                case 5:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);


                        screenRightNumbers[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 6:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 4");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "2";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 7:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);


                        screenLeftArrows[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 8:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 5");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "3";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }

                    break;
                case 9:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];


                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 10:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 6");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "3";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 11:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 12:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 7");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "4";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }

                    break;
                case 13:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 14:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog ("Aufgabe 8");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "4";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 15:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        Debug.Log(" 1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen)");
                        // ##########   1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen) ##########
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);

                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);


                        screenLeftArrows2[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 16:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 9");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "5";
                        press1 = Time.realtimeSinceStartup.ToString();

                        Debug.Log("Spacebar pressed");

                        _rendScreenLeft.sharedMaterial = material[1];
                    }

                    break;
                case 17:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows2[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                        // numberIndex berechnen
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);

                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);


                        // berechneten Screen aktiv setzen
                        screenRightNumbers2[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();


                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 18:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 2");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "5";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 19:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers2[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzte number aus array entfernen
                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                        screenLeftArrows2[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 20:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 3");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "6";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }

                    break;
                case 21:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows2[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                        screenRightNumbers2[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 22:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 4");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "6";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 23:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers2[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                        screenLeftArrows2[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 24:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 5");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "7";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 25:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows2[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                        screenRightNumbers2[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 26:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 6");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "7";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 27:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers2[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();


                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows2[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 28:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 7");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "8";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 29:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows2[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);


                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                        screenRightNumbers2[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 30:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 8");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "8";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 31:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers2[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        Debug.Log("2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen)");
                        // ##########   2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen) ##########
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows3[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();


                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 32:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 9");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "9";
                    press1 = Time.realtimeSinceStartup.ToString();

                    Debug.Log("Spacebar pressed");

                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 33:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows3[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                        // arrowIndex berechnen
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        // berechneten Screen aktiv setzen
                        screenRightNumbers3[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 34:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 2");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "9";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 35:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers3[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                        screenLeftArrows3[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 36:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 3");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "10";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 37:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows3[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                        screenRightNumbers3[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 38:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 4");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "10";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 39:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers3[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                        screenLeftArrows3[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 40:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 5");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "11";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 41:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows3[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                        screenRightNumbers3[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 42:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 6");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "11";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 43:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers3[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();


                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);


                        screenLeftArrows3[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 44:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 7");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "12";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 45:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows3[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();


                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);


                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                        screenRightNumbers3[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 46:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 8");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "12";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 47:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers3[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        Debug.Log("3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen)");
                        // ##########   3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen) ##########
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows4[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();


                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 48:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 9");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "13";
                    press1 = Time.realtimeSinceStartup.ToString();

                    Debug.Log("Spacebar pressed");

                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 49:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows4[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                        // arrowIndex berechnen
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);


                        // berechneten Screen aktiv setzen
                        screenRightNumbers4[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();


                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 50:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 2");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "13";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 51:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers4[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                        screenLeftArrows4[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 52:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 3");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "14";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 53:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows4[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                        screenRightNumbers4[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 54:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 4");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "14";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 55:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers4[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                        screenLeftArrows4[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 56:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 5");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "15";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 57:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows4[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();


                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = arrowIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                        screenRightNumbers4[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 58:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 6");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "15";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 59:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers4[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();


                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows4[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 60:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 7");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "16";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 61:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows4[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                        screenRightNumbers4[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 62:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 8");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "16";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 63:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                        screenRightNumbers4[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        Debug.Log("4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen)");
                        // ##########   4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen) ##########
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows5[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();


                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 64:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 9");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "17";
                    press1 = Time.realtimeSinceStartup.ToString();

                    Debug.Log("Spacebar pressed");

                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 65:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows5[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                        // arrowIndex berechnen
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        // berechneten Screen aktiv setzen
                        screenRightNumbers5[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.enabled = true;
                        _rendScreenRight.sharedMaterial = material[0];


                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 66:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 2");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "17";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 67:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers5[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                        screenLeftArrows5[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 68:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 3");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "18";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 69:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows5[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                        screenRightNumbers5[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 70:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 4");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "18";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 71:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers5[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                        screenLeftArrows5[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 72:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 5");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "19";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 73:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows5[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                        screenRightNumbers5[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 74:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 6");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "19";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 75:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers5[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // benutzter arrow aus array entfernen
                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();


                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                        screenLeftArrows5[arrowIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 76:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 7");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "MWD";
                    trial = "20";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 77:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenLeft.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenLeftArrows5[arrowIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        // entfernt bereits benutztes Item aus array
                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();


                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTimeBeforeSignal);
                        audioSource.Play();
                        yield return new WaitForSecondsRealtime(fixationTimeAfterSignal);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                        screenRightNumbers5[numberIndex].SetActive(true);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern f??r log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }

                    break;
                case 78:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    //logger.writeMessageToLog("Aufgabe 8");
                    //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    task = "TP";
                    trial = "20";
                    press1 = Time.realtimeSinceStartup.ToString();


                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 79:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);
                        trialStartFloat = float.Parse(trialStart);

                        // compute differences
                        timeToStartFloat = press1Float - trialStartFloat;
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        timeToStart = timeToStartFloat.ToString("N");
                        estimation = estimationFloat.ToString("N");

                        // write log
                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                        screenRightNumbers5[numberIndex].SetActive(false);

                        //slowCameraScript.GetComponent<SlowMotion>().switchBoolean();

                        _rendScreenLeft.sharedMaterial = material[0];
                        Debug.Log("5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen)");
                        // ##########   5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen) ##########
                    }

                    break;
            }

            if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
            {
                _spaceKeyCodeCounter += 1;
                Debug.Log(_spaceKeyCodeCounter);
            }
        }
        if(frameCounter == 0)
        {
            logger.writeHeadingsToLogGyroscope();
        }
        string positionStringX = "" + gyroscope.transform.position.x;
        string positionStringY = "" + gyroscope.transform.position.y;
        string positionStringZ = "" + gyroscope.transform.position.z;
        string rotationStringX = "" + gyroscope.transform.localEulerAngles.x;
        string rotationStringY = "" + gyroscope.transform.localEulerAngles.y;
        string rotationStringZ = "" + gyroscope.transform.localEulerAngles.z;

        logger.writeMessageToLogGyroscope(id + ";" + condition + ";" + blockNumber + ";" + frameCounter + ";" + Time.deltaTime + ";" + positionStringX + ";" + positionStringY + ";" + positionStringZ + ";" + rotationStringX + ";" + rotationStringY + ";" + rotationStringZ + ";" + Time.realtimeSinceStartup.ToString());
        frameCounter += 1;
    }
}