using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.CompilerServices;

public class new_MWDLeftTPRight_TPStart : MonoBehaviour
{
    private LoggingSystem logger;
    //private GameObject gyroscope;

    // Zeit nach der Fixationskreuz verschwindet
    public int fixationTime;


    // creating variables for logging
    public String id;
    private String condition = "RE";
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

    /*
    
    // Zeitintervalle zum loggen
    private String arrowIntervall_1 = "1";
    private String arrowIntervall_2 = "2";
    private String arrowIntervall_4 = "4";
    private String arrowIntervall_7 = "7";
    
    private String numberIntervall_1 = "1";
    private String numberIntervall_2 = "2";
    private String numberIntervall_4 = "4";
    private String numberIntervall_7 = "7";
    
    */

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
    /*
    private GameObject[] screenLeft2;
    private GameObject[] screenLeft3;
    private GameObject[] screenLeft4;
    private GameObject[] screenLeft5;
    */

    private GameObject screenRight;
    /*
    private GameObject[] screenRight2;
    private GameObject[] screenRight3;
    private GameObject[] screenRight4;
    private GameObject[] screenRight5;
    */

    private int numberIndex;
    private int arrowIndex;

    /*
    // GameObjects for changing Screen color due to Text mesh pro changes
    private GameObject screenRightA;
    private GameObject screenRightB;
    private GameObject screenRightC;
    private GameObject screenRightD;
    
    private GameObject screenLeftA;
    private GameObject screenLeftB;
    private GameObject screenLeftC;
    private GameObject screenLeftD;
    */

    //private GameObject testObject;

    // Start is called before the first frame update
    void Start()
    {
        //testObject = GameObject.Find("CanvasLeft").transform.GetChild(4).gameObject;
        //testObject.SetActive(false);

        _taskNumber = 1;
        _testCounter = 0;
        frameCounter = 1;


        logger = GameObject.Find("LoggingSystem").GetComponent<LoggingSystem>();
        if (logger == null)
            Debug.Log("[LoggingDemo] Unable to set reference to Logging System.");

        //gyroscope = GameObject.FindWithTag("MainCamera");

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
        // Screen Links wird weiß
        _rendScreenLeft.sharedMaterial = material[0];


        _rendScreenRight = screenRight.GetComponent<Renderer>();
        _rendScreenRight.enabled = true;
        // Screen Rechts wird weiß
        _rendScreenRight.sharedMaterial = material[0];


        StartCoroutine(waiter());


        blockStart = System.DateTime.UtcNow.ToString(blockStartFormat);
        trialStart = Time.realtimeSinceStartup.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waiter2());
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }


    IEnumerator waiter()
    {
        fixationCrossRight.SetActive(true);
        yield return new WaitForSecondsRealtime(fixationTime);
        fixationCrossRight.SetActive(false);
        // In dieser Szene fange wir mit TP an!
        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);
        print(numberIndex);

        if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
        {
            screenRightNumbers[numberIndex].SetActive(true);

            timeToStart = Time.realtimeSinceStartup.ToString();
            timeIntervall = screenRightNumbers[numberIndex].name;
        }
    }

    IEnumerator waiter2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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


                        task = "TP";
                        trial = "1";
                        press1 = Time.realtimeSinceStartup.ToString();
                        trialStart = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }

                    break;
                case 1:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Screen Links wird weiß
                        _rendScreenRight.sharedMaterial = material[0];

                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                        press2 = Time.realtimeSinceStartup.ToString();

                        // convert press1 & press2 to computable numbers
                        press1Float = float.Parse(press1);
                        press2Float = float.Parse(press2);

                        // compute difference
                        estimationFloat = press2Float - press1Float;

                        // convert back to string
                        estimation = estimationFloat.ToString("N");

                        logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" +
                                                 task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" +
                                                 press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                        screenRightNumbers[numberIndex].SetActive(false);

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers =
                            screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        // arrowIndex berechnen
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        // berechneten Screen aktiv setzen
                        screenLeftArrows[arrowIndex].SetActive(true);


                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
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
                        task = "MWD";
                        trial = "1";
                        press1 = Time.realtimeSinceStartup.ToString();

                        //ChangeMaterialRightScreen();
                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 3:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers[numberIndex].SetActive(true);


                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers[numberIndex].name;
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

                        task = "TP";
                        trial = "2";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 5:
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

                        screenRightNumbers =
                            screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);


                        screenLeftArrows[arrowIndex].SetActive(true);

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
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

                        task = "MWD";
                        trial = "2";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 7:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);


                        screenRightNumbers[numberIndex].SetActive(true);

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers[numberIndex].name;
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

                        task = "TP";
                        trial = "3";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 9:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers =
                            screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows[arrowIndex].SetActive(true);

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
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

                        task = "MWD";
                        trial = "3";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 11:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers[numberIndex].SetActive(true);

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers[numberIndex].name;
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

                        task = "TP";
                        trial = "4";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 13:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers =
                            screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        screenLeftArrows[arrowIndex].SetActive(true);

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows[arrowIndex].name;
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

                        task = "MWD";
                        trial = "4";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 15:
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

                        Debug.Log(" 1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen)");
                        // ##########   1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen) ##########
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);

                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);


                        screenRightNumbers2[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
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

                        task = "TP";
                        trial = "5";
                        press1 = Time.realtimeSinceStartup.ToString();

                        Debug.Log("Spacebar pressed");

                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 17:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                        // arrowIndex berechnen
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);

                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);


                        // berechneten Screen aktiv setzen
                        screenLeftArrows2[arrowIndex].SetActive(true);


                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
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

                        task = "MWD";
                        trial = "5";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 19:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                        screenRightNumbers2[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
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

                        task = "TP";
                        trial = "6";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 21:
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

                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                        screenLeftArrows2[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
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

                        task = "MWD";
                        trial = "6";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 23:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                        screenRightNumbers2[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 24:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 5");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "7";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 25:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                        screenLeftArrows2[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 26:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 6");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "7";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 27:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers2[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers2[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 28:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 7");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "8";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 29:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers2 =
                            screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);


                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                        screenLeftArrows2[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows2[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 30:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 8");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "8";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 31:
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

                        Debug.Log("2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen)");
                        // ##########   2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen) ##########
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers3[numberIndex].SetActive(true);


                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 32:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 9");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "9";
                        press1 = Time.realtimeSinceStartup.ToString();

                        Debug.Log("Spacebar pressed");

                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 33:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                        // arrowIndex berechnen
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        // berechneten Screen aktiv setzen
                        screenLeftArrows3[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 34:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 2");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "9";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 35:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                        screenRightNumbers3[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 36:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 3");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "10";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 37:
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

                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                        screenLeftArrows3[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 38:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 4");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "10";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 39:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                        screenRightNumbers3[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 40:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 5");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "11";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 41:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                        screenLeftArrows3[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 42:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 6");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "11";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 43:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);


                        screenRightNumbers3[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers3[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 44:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 7");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "12";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 45:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers3 =
                            screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();


                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);


                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                        screenLeftArrows3[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows3[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 46:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 8");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "12";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 47:
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

                        Debug.Log("3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen)");
                        // ##########   3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen) ##########
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers4[numberIndex].SetActive(true);


                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 48:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 9");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "13";
                        press1 = Time.realtimeSinceStartup.ToString();

                        Debug.Log("Spacebar pressed");

                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 49:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                        // arrowIndex berechnen
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);


                        // berechneten Screen aktiv setzen
                        screenLeftArrows4[arrowIndex].SetActive(true);


                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 50:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 2");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "13";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 51:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                        screenRightNumbers4[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 52:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 3");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "14";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 53:
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

                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                        screenLeftArrows4[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 54:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 4");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "14";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 55:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                        screenRightNumbers4[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 56:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 5");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "15";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 57:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();


                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                        screenLeftArrows4[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 58:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 6");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "15";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 59:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers4[numberIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers4[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 60:

                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 7");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "16";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 61:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers4 =
                            screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                        screenLeftArrows4[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows4[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 62:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 8");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "16";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 63:
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

                        Debug.Log("4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen)");
                        // ##########   4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen) ##########
                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        screenRightNumbers5[numberIndex].SetActive(true);


                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 64:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 9");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "17";
                        press1 = Time.realtimeSinceStartup.ToString();

                        Debug.Log("Spacebar pressed");

                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 65:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                        // arrowIndex berechnen
                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        // berechneten Screen aktiv setzen
                        screenLeftArrows5[arrowIndex].SetActive(true);


                        _rendScreenLeft.sharedMaterial = material[0];


                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 66:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 2");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "17";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 67:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                        screenRightNumbers5[numberIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 68:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 3");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "18";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 69:
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

                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                        screenLeftArrows5[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 70:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 4");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "18";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 71:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                        screenRightNumbers5[numberIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 72:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 5");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "19";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 73:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                        screenLeftArrows5[arrowIndex].SetActive(true);

                        _rendScreenRight.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 74:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 6");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "19";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 75:
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

                        // benutzter arrow aus array entfernen
                        screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();


                        // Fixation
                        fixationCrossRight.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossRight.SetActive(false);

                        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                        screenRightNumbers5[numberIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenRightNumbers5[numberIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 76:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 7");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "TP";
                        trial = "20";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenRight.sharedMaterial = material[1];
                    }


                    break;
                case 77:
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

                        // entfernt bereits benutztes Item aus array
                        screenRightNumbers5 =
                            screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();


                        // Fixation
                        fixationCrossLeft.SetActive(true);
                        yield return new WaitForSecondsRealtime(fixationTime);
                        fixationCrossLeft.SetActive(false);

                        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                        screenLeftArrows5[arrowIndex].SetActive(true);

                        _rendScreenLeft.sharedMaterial = material[0];

                        // berechnetes zeitintervall abspeichern für log
                        timeIntervall = screenLeftArrows5[arrowIndex].name;
                        trialStart = Time.realtimeSinceStartup.ToString();
                    }


                    break;
                case 78:
                    if (!(fixationCrossLeft.activeSelf || fixationCrossRight.activeSelf))
                    {
                        // Logging
                        Debug.Log("[Logging] Key down = Space");
                        //logger.writeMessageToLog("Aufgabe 8");
                        //logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                        task = "MWD";
                        trial = "20";
                        press1 = Time.realtimeSinceStartup.ToString();


                        _rendScreenLeft.sharedMaterial = material[1];
                    }


                    break;
                case 79:
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

            Debug.Log(_spaceKeyCodeCounter);
        }
    }
}