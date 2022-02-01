using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class test_TPLeftMWDRight_MWDStart : MonoBehaviour
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

    //public GameObject screenRight Arrows for Filling Levels;
    private GameObject _screenRightArrowA;
    private GameObject _screenRightArrowB;
    private GameObject _screenRightArrowC;
    private GameObject _screenRightArrowD;
    //public GameObject screenLeft Numbers for Time Production;
    private GameObject _screenLeftNumberA;
    private GameObject _screenLeftNumberB;
    private GameObject _screenLeftNumberC;
    private GameObject _screenLeftNumberD;

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

    private GameObject[] screenLeftNumbers;
    private GameObject[] screenLeftNumbers2;
    private GameObject[] screenLeftNumbers3;
    private GameObject[] screenLeftNumbers4;
    private GameObject[] screenLeftNumbers5;
    //private GameObject[] screenRightNumbers;
    //private GameObject[] screenLeftArrows;
    private GameObject[] screenRightArrows;
    private GameObject[] screenRightArrows2;
    private GameObject[] screenRightArrows3;
    private GameObject[] screenRightArrows4;
    private GameObject[] screenRightArrows5;

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

        // left screens
        _screenLeftNumberA = GameObject.Find("ScreenLeftA");
        _screenLeftNumberB = GameObject.Find("ScreenLeftB");
        _screenLeftNumberC = GameObject.Find("ScreenLeftC");
        _screenLeftNumberD = GameObject.Find("ScreenLeftD");

        // right screens
        _screenRightArrowA = GameObject.Find("ScreenRightA");
        _screenRightArrowB = GameObject.Find("ScreenRightB");
        _screenRightArrowC = GameObject.Find("ScreenRightC");
        _screenRightArrowD = GameObject.Find("ScreenRightD");

        // fixation crosses
        fixationCrossRight = GameObject.Find("FixationskreuzRechts");
        fixationCrossLeft = GameObject.Find("FixationskreuzLinks");

        _screenLeftNumberA.SetActive(false);
        _screenLeftNumberB.SetActive(false);
        _screenLeftNumberC.SetActive(false);
        _screenLeftNumberD.SetActive(false);

        _screenRightArrowA.SetActive(false);
        _screenRightArrowB.SetActive(false);
        _screenRightArrowC.SetActive(false);
        _screenRightArrowD.SetActive(false);

        fixationCrossLeft.SetActive(false);
        fixationCrossRight.SetActive(false);


        // instantiate arrays
        screenLeftNumbers = new GameObject[] {_screenLeftNumberA, _screenLeftNumberB, _screenLeftNumberC, _screenLeftNumberD};
        screenLeftNumbers2 = new GameObject[] {_screenLeftNumberA, _screenLeftNumberB, _screenLeftNumberC, _screenLeftNumberD};
        screenLeftNumbers3 = new GameObject[] {_screenLeftNumberA, _screenLeftNumberB, _screenLeftNumberC, _screenLeftNumberD};
        screenLeftNumbers4 = new GameObject[] {_screenLeftNumberA, _screenLeftNumberB, _screenLeftNumberC, _screenLeftNumberD};
        screenLeftNumbers5 = new GameObject[] {_screenLeftNumberA, _screenLeftNumberB, _screenLeftNumberC, _screenLeftNumberD};

        screenRightArrows = new GameObject[] {_screenRightArrowA, _screenRightArrowB, _screenRightArrowC, _screenRightArrowD};
        screenRightArrows2 = new GameObject[] {_screenRightArrowA, _screenRightArrowB, _screenRightArrowC, _screenRightArrowD};
        screenRightArrows3 = new GameObject[] {_screenRightArrowA, _screenRightArrowB, _screenRightArrowC, _screenRightArrowD};
        screenRightArrows4 = new GameObject[] {_screenRightArrowA, _screenRightArrowB, _screenRightArrowC, _screenRightArrowD};
        screenRightArrows5 = new GameObject[] {_screenRightArrowA, _screenRightArrowB, _screenRightArrowC, _screenRightArrowD};

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

        // In dieser Szene fangen wir mit MWD an!
        arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);
        print(arrowIndex);

        screenRightArrows[arrowIndex].SetActive(true);
        _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
        _rendScreenRight.enabled = true;
        _rendScreenRight.sharedMaterial = material[_x];

        timeToStart = Time.realtimeSinceStartup.ToString();
        timeIntervall = screenRightArrows[arrowIndex].transform.GetChild(0).name;
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

                    task = "MWD";
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




                    //screenLeftNumbers[numberIndex].SetActive(false);
                    screenRightArrows[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftNumbers[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 2:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

                    task = "TP";
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



                    screenLeftNumbers[numberIndex].SetActive(false);
                    // benutzte number aus array entfernen
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows[arrowIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 4:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "2";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
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


                    screenRightArrows[arrowIndex].SetActive(false);
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    screenLeftNumbers[numberIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 6:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "2";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);

                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows[arrowIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 8:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "3";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
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


                    screenRightArrows[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    screenLeftNumbers[numberIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 10:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "3";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows[arrowIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 12:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "4";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
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


                    screenRightArrows[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    screenLeftNumbers[numberIndex].SetActive(true);

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 14:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "4";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers[numberIndex].SetActive(false);
                    Debug.Log(" 1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen)");
                    // ##########   1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);

                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 16:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "5";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
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




                    screenRightArrows2[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);

                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 18:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");

                    task = "TP";
                    trial = "5";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
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



                    screenLeftNumbers2[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 20:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "6";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows2[arrowIndex].SetActive(false);
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 22:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "6";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers2[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 24:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "7";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows2[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();


                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 26:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "7";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers2[numberIndex].SetActive(false);
                    // benutzter number aus array entfernen
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows2[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 28:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "8";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
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


                    screenRightArrows2[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers2[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 30:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "8";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers2[numberIndex].SetActive(false);
                    Debug.Log("2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen)");
                    // ##########   2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 32:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "9";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
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



                    screenRightArrows3[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 34:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "9";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
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



                    screenLeftNumbers3[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 36:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "10";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
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


                    screenRightArrows3[arrowIndex].SetActive(false);
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];


                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 38:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "10";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers3[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 40:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "11";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows3[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 42:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "11";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers3[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows3[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 44:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "12";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows3[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers3[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 46:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "12";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers3[numberIndex].SetActive(false);
                    Debug.Log("3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen)");
                    // ##########   3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 48:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "13";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
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



                    screenRightArrows4[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 50:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "13";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers4[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 52:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "14";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows4[arrowIndex].SetActive(false);
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 54:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "14";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers4[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 56:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "15";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows4[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 58:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "15";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers4[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows4[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 60:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "16";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows4[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers4[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 62:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "16";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers4[numberIndex].SetActive(false);
                    Debug.Log("4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen)");
                    // ##########   4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 64:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "17";
                    press1 = Time.realtimeSinceStartup.ToString();


                    Debug.Log("Spacebar pressed");
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
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



                    screenRightArrows5[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    // berechneten Screen aktiv setzen
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 66:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "17";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
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


                    screenLeftNumbers5[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 68:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "18";
                    press1 = Time.realtimeSinceStartup.ToString();



                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows5[arrowIndex].SetActive(false);
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 70:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "18";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers5[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 72:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "19";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows5[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 74:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "19";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers5[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // Fixation
                    fixationCrossRight.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossRight.SetActive(false);

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenRightArrows5[arrowIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 76:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "MWD";
                    trial = "20";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
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

                    screenRightArrows5[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // Fixation
                    fixationCrossLeft.SetActive(true);
                    yield return new WaitForSecondsRealtime(fixationTime);
                    fixationCrossLeft.SetActive(false);

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];

                    // berechnetes zeitintervall abspeichern für log
                    timeIntervall = screenLeftNumbers5[numberIndex].transform.GetChild(0).name;
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 78:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    task = "TP";
                    trial = "20";
                    press1 = Time.realtimeSinceStartup.ToString();

                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
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

                    screenLeftNumbers5[numberIndex].SetActive(false);
                    Debug.Log("5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen)");
                    // ##########   5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen) ##########
                    break;
            }
            _spaceKeyCodeCounter += 1;
        }
    }

}
