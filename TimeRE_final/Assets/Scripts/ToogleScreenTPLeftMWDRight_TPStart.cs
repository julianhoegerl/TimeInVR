using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ToogleScreenTPLeftMWDRight_TPStart : MonoBehaviour
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
        
        
        //FixationLeft();
        
        
        
        
        // In dieser Szene fange wir mit TP an!
        numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);
        print(numberIndex);

        screenLeftNumbers[numberIndex].SetActive(true);
        _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
        _rendScreenLeft.enabled = true;
        _rendScreenLeft.sharedMaterial = material[_x];
        
        
        
        

        /*
        _rendScreenRight = _screenRightArrowA.GetComponent<Renderer>();
        _rendScreenRight.enabled = false;
        _rendScreenRight.sharedMaterial = material[_x];
        */
        
        // write headings to logfile
        // klappt hier irgendwie nicht :/
        //logger.writeHeadings();
        //logger.writeMessageToLog("Test");
        
        

        blockStart = System.DateTime.UtcNow.ToString(blockStartFormat);
        trialStart = Time.realtimeSinceStartup.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            switch (_spaceKeyCodeCounter)
            {
                case 0:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    
                    // write headings to logfile
                    logger.writeHeadings();


                    task = "TP";
                    trial = "1";
                    timeIntervall = "";
                    //trialStart
                    press1 = Time.realtimeSinceStartup.ToString();
                    timeToStart = Time.realtimeSinceStartup.ToString();
                    
                    
                    
                    //logger.writeMessageToLog("Aufgabe 1");
                    //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    ChangeMaterialLeftScreen();
                    break;
                case 1:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    press2 = Time.realtimeSinceStartup.ToString();
                    
                    // convert press1 & press2 to computable numbers
                    press1Float = float.Parse(press1);
                    press2Float = float.Parse(press2);
                    
                    // compute difference
                    estimationFloat = press2Float - press1Float;
                    
                    // convert back to string
                    estimation = estimationFloat.ToString("N");

                    logger.writeMessageToLog(id + ";" + condition + ";" + blockNumber + ";" + task + ";" + trial + ";" + timeIntervall + ";" + trialStart + ";" + press1 + ";" + press2 + ";" + timeToStart + ";" + estimation);
                   
                    screenLeftNumbers[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);

                    // berechneten Screen aktiv setzen
                    screenRightArrows[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    
                    trialStart = Time.realtimeSinceStartup.ToString();
                    break;
                case 2:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    //logger.writeMessageToLog ("Aufgabe 2");
                    //logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    task = "MWD";
                    trial = "1";
                    timeIntervall = "";
                    //trialStart
                    press1 = Time.realtimeSinceStartup.ToString();
                    
                    ChangeMaterialRightScreen();
                    break;
                case 3:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
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

                    
                    screenRightArrows[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();
                    
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);
                    screenLeftNumbers[numberIndex].SetActive(true);
                    break;
                case 4:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    

                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 5:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers[numberIndex].SetActive(false);
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);
                    screenRightArrows[arrowIndex].SetActive(true);
                    break;
                case 6:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 7:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);
                    screenLeftNumbers[numberIndex].SetActive(true);
                    break;
                case 8:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 9:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);
                    screenRightArrows[arrowIndex].SetActive(true);
                    break;
                case 10:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 11:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows = screenRightArrows.Where((source, index) => index != arrowIndex).ToArray();
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers.Length);
                    screenLeftNumbers[numberIndex].SetActive(true);
                    break;
                case 12:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 13:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers = screenLeftNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows.Length);
                    screenRightArrows[arrowIndex].SetActive(true);
                    break;
                case 14:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 15:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows[arrowIndex].SetActive(false);
                    Debug.Log(" 1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen)");
                    // ##########   1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 16:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 17:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftNumbers2[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);

                    // berechneten Screen aktiv setzen
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 18:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 19:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightArrows2[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 20:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 21:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers2[numberIndex].SetActive(false);
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 22:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 23:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows2[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 24:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 25:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers2[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 26:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 27:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows2[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows2 = screenRightArrows2.Where((source, index) => index != arrowIndex).ToArray();
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers2.Length);
                    screenLeftNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 28:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 29:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers2[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers2 = screenLeftNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows2.Length);
                    screenRightArrows2[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 30:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 31:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows2[arrowIndex].SetActive(false);
                    Debug.Log("2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen)");
                    // ##########   2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 32:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 33:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftNumbers3[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);

                    // berechneten Screen aktiv setzen
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 34:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 35:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightArrows3[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 36:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 37:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers3[numberIndex].SetActive(false);
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 38:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 39:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows3[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 40:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 41:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers3[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 42:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 43:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows3[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows3 = screenRightArrows3.Where((source, index) => index != arrowIndex).ToArray();
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers3.Length);
                    screenLeftNumbers3[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 44:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 45:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers3[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers3 = screenLeftNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows3.Length);
                    screenRightArrows3[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 46:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 47:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows3[arrowIndex].SetActive(false);
                    Debug.Log("3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen)");
                    // ##########   3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 48:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 49:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftNumbers4[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);

                    // berechneten Screen aktiv setzen
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 50:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 51:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightArrows4[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 52:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 53:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers4[numberIndex].SetActive(false);
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 54:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 55:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows4[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 56:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 57:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers4[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 58:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 59:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows4[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows4 = screenRightArrows4.Where((source, index) => index != arrowIndex).ToArray();
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers4.Length);
                    screenLeftNumbers4[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 60:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 61:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers4[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers4 = screenLeftNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows4.Length);
                    screenRightArrows4[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 62:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 63:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows4[arrowIndex].SetActive(false);
                    Debug.Log("4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen)");
                    // ##########   4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen) ##########
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 64:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 65:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftNumbers5[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    // arrowIndex berechnen
                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);

                    // berechneten Screen aktiv setzen
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 66:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 67:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightArrows5[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 68:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 69:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers5[numberIndex].SetActive(false);
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 70:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 71:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows5[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 72:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 73:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers5[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 74:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 75:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows5[arrowIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightArrows5 = screenRightArrows5.Where((source, index) => index != arrowIndex).ToArray();
                    numberIndex = UnityEngine.Random.Range(0, screenLeftNumbers5.Length);
                    screenLeftNumbers5[numberIndex].SetActive(true);
                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 76:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 77:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftNumbers5[numberIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftNumbers5 = screenLeftNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenRightArrows5.Length);
                    screenRightArrows5[arrowIndex].SetActive(true);
                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 78:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 79:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightArrows5[arrowIndex].SetActive(false);
                    Debug.Log("5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen)");
                    // ##########   5ter Durchgang beendet (20 x TP & 20 x MWD abgeschlossen) ##########
                    break;
            }
            _spaceKeyCodeCounter += 1;
        }

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
    
    void FixationRight()
    {
        StartCoroutine(RemoveAfterSeconds(fixationTime, fixationCrossRight));
    }
    
    void FixationLeft()
    {
        //Time.timeScale = 0;
        StartCoroutine(RemoveAfterSeconds(fixationTime, fixationCrossLeft));
        //Time.timeScale = 1;
    }
    
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
    
}
