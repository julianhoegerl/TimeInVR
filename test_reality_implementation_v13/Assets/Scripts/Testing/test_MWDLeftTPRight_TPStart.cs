using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class test_MWDLeftTPRight_TPStart : MonoBehaviour
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

    //public GameObject screenLeft Arrows for Filling Levels;
    private GameObject _screenLeftArrowA;
    private GameObject _screenLeftArrowB;
    private GameObject _screenLeftArrowC;
    private GameObject _screenLeftArrowD;
    //public GameObject screenRight Numbers for Time Production;
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

    private int numberIndex;
    private int arrowIndex;






    // Start is called before the first frame update
    void Start()
    {
        _taskNumber = 1;
        _testCounter = 0;
        frameCounter = 1;


        logger = GameObject.Find ("LoggingSystem").GetComponent<LoggingSystem> ();
        if (logger == null)
           Debug.Log ("[LoggingDemo] Unable to set reference to Logging System.");

        //gyroscope = GameObject.FindWithTag("MainCamera");
        
        _x = 0;
        _spaceKeyCodeCounter = 0;

        // right screens
        _screenRightNumberA = GameObject.Find("ScreenRightA");
        _screenRightNumberB = GameObject.Find("ScreenRightB");
        _screenRightNumberC = GameObject.Find("ScreenRightC");
        _screenRightNumberD = GameObject.Find("ScreenRightD");

        // left screens
        _screenLeftArrowA = GameObject.Find("ScreenLeftA");
        _screenLeftArrowB = GameObject.Find("ScreenLeftB");
        _screenLeftArrowC = GameObject.Find("ScreenLeftC");
        _screenLeftArrowD = GameObject.Find("ScreenLeftD");

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


        // instantiate arrays
        screenLeftArrows = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows2 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows3 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows4 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows5 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};

        screenRightNumbers = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers2 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers3 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers4 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers5 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};

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

    IEnumerator waiter()
    {
        fixationCrossRight.SetActive(true);
        yield return new WaitForSecondsRealtime(fixationTime);
        fixationCrossRight.SetActive(false);

        // In dieser Szene fange wir mit TP an!
        numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);
        print(numberIndex);

        screenRightNumbers[numberIndex].SetActive(true);
        _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
        _rendScreenRight.enabled = true;
        _rendScreenRight.sharedMaterial = material[_x];

        timeToStart = Time.realtimeSinceStartup.ToString();
        timeIntervall = screenRightNumbers[numberIndex].transform.GetChild(0).name;
    }

    IEnumerator waiter2()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            switch (_spaceKeyCodeCounter)
            {
                case 0:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

                    // write headings to logfile
                    logger.writeHeadings();

                    task = "TP";
                    trial = "1";
                    press1 = Time.realtimeSinceStartup.ToString();
                    trialStart = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    ChangeMaterialRightScreen();
                    break;
                case 1:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

                    press2 = Time.realtimeSinceStartup.ToString();

                    // convert press1 & press2 to computable numbers
                    press1Float = float.Parse(press1);
                    press2Float = float.Parse(press2);

                    // compute difference
                    estimationFloat = press2Float - press1Float;

                    // convert back to string
                    estimation = estimationFloat.ToString("N");

                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);




                    screenRightNumbers[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftArrows[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 2:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

                    task = "MWD";
                    trial = "1";
                    press1 = Time.realtimeSinceStartup.ToString();

                    ChangeMaterialLeftScreen();
                    break;
                case 3:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);



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
                    timeIntervall = screenRightNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 4:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "2";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 5:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenRightNumbers[numberIndex].SetActive(false);
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    screenLeftArrows[arrowIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 6:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "2";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 7:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenLeftArrows[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightNumbers[numberIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 8:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "3";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 9:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenRightNumbers[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    screenLeftArrows[arrowIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 10:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "3";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 11:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

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
                    timeIntervall = screenRightNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 12:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "4";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 13:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    screenLeftArrows[arrowIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 14:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "4";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 15:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenLeftArrows[arrowIndex].SetActive(false);
                    Debug.Log(" 1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen)");
                    // ##########   1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);

                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 16:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "5";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 17:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);




                    screenRightNumbers2[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);

                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 18:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

                    task = "MWD";
                    trial = "5";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 19:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);



                    screenLeftArrows2[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 20:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "6";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 21:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers2[numberIndex].SetActive(false);
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 22:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "6";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 23:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows2[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 24:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "7";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 25:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers2[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 26:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "7";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 27:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenLeftArrows2[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 28:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "8";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 29:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenRightNumbers2[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 30:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "8";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 31:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenLeftArrows2[arrowIndex].SetActive(false);
                    Debug.Log("2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen)");
                    // ##########   2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 32:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "9";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 33:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);



                    screenRightNumbers3[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 34:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "9";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 35:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);



                    screenLeftArrows3[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 36:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "10";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 37:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenRightNumbers3[numberIndex].SetActive(false);
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];


                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 38:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "10";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 39:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows3[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 40:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "11";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 41:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers3[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 42:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "11";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 43:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows3[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 44:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "12";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 45:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers3[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 46:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "12";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 47:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows3[arrowIndex].SetActive(false);
                    Debug.Log("3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen)");
                    // ##########   3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 48:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "13";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 49:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);



                    screenRightNumbers4[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);

                    // berechneten Screen aktiv setzen
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 50:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "13";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 51:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenLeftArrows4[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 52:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "14";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 53:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers4[numberIndex].SetActive(false);
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 54:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "14";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 55:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows4[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 56:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "15";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 57:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers4[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 58:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "15";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 59:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows4[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 60:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "16";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 61:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers4[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 62:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "16";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 63:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows4[arrowIndex].SetActive(false);
                    Debug.Log("4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen)");
                    // ##########   4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 64:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "17";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 65:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);



                    screenRightNumbers5[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);

                    // berechneten Screen aktiv setzen
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 66:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "17";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 67:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);


                    screenLeftArrows5[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 68:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "18";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 69:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers5[numberIndex].SetActive(false);
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 70:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "18";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 71:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows5[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 72:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "19";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 73:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers5[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 74:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "19";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 75:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows5[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 76:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "20";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 77:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenRightNumbers5[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 78:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "20";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 79:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
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
                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + blockStart + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);

                    screenLeftArrows5[arrowIndex].SetActive(false);
                    Debug.Log("5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen)");
                    // ##########   5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen) ##########
                    break;
            }
            _spaceKeyCodeCounter += 1;
        }
    }

}
