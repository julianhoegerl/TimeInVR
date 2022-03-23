using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ToogleScreenMWDLeftTPRight_MWDStart : MonoBehaviour
{
    private LoggingSystem logger;
    //private GameObject gyroscope;
    
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

        _screenRightNumberA.SetActive(false);
        _screenRightNumberB.SetActive(false);
        _screenRightNumberC.SetActive(false);
        _screenRightNumberD.SetActive(false);

        _screenLeftArrowA.SetActive(false);
        _screenLeftArrowB.SetActive(false);
        _screenLeftArrowC.SetActive(false);
        _screenLeftArrowD.SetActive(false);


        // instantiate arrays
        screenRightNumbers = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers2 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers3 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers4 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};
        screenRightNumbers5 = new GameObject[] {_screenRightNumberA, _screenRightNumberB, _screenRightNumberC, _screenRightNumberD};

        screenLeftArrows = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows2 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows3 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows4 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};
        screenLeftArrows5 = new GameObject[] {_screenLeftArrowA, _screenLeftArrowB, _screenLeftArrowC, _screenLeftArrowD};

        // In dieser Szene fangen wir mit MWD an!
        arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);
        print(arrowIndex);

        screenLeftArrows[arrowIndex].SetActive(true);
        _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
        _rendScreenLeft.enabled = true;
        _rendScreenLeft.sharedMaterial = material[_x];

        /*
        _rendScreenRight = _screenRightArrowA.GetComponent<Renderer>();
        _rendScreenRight.enabled = false;
        _rendScreenRight.sharedMaterial = material[_x];
        */
        
        
        // write headings to logfile
        //logger.writeHeadings();
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
                    
                    logger.writeMessageToLog ("Aufgabe 1");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    ChangeMaterialLeftScreen();
                    break;
                case 1:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");


                   
                    //screenLeftNumbers[numberIndex].SetActive(false);
                    screenLeftArrows[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);

                    // berechneten Screen aktiv setzen
                    screenRightNumbers[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    break;
                case 2:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    ChangeMaterialRightScreen();
                    break;
                case 3:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    
                    screenRightNumbers[numberIndex].SetActive(false);
                    // benutzte number aus array entfernen
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();
                    
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);
                    screenLeftArrows[arrowIndex].SetActive(true);
                    break;
                case 4:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    

                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 5:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows[arrowIndex].SetActive(false);
                    screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);
                    screenRightNumbers[numberIndex].SetActive(true);
                    break;
                case 6:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 7:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);
                    screenLeftArrows[arrowIndex].SetActive(true);
                    break;
                case 8:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 9:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);
                    screenRightNumbers[numberIndex].SetActive(true);
                    break;
                case 10:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");
                    
                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 11:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers = screenRightNumbers.Where((source, index) => index != numberIndex).ToArray();
                    
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows.Length);
                    screenLeftArrows[arrowIndex].SetActive(true);
                    break;
                case 12:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 13:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows = screenLeftArrows.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers.Length);
                    screenRightNumbers[numberIndex].SetActive(true);
                    break;
                case 14:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeMessageToLog ("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 15:
                    // Logging
                    Debug.Log ("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog ("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers[numberIndex].SetActive(false);
                    Debug.Log(" 1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen)");
                    // ##########   1ter Durchgang beendet (4 x TP & 4 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 16:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 17:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftArrows2[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);

                    // berechneten Screen aktiv setzen
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenLeft = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 18:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 19:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightNumbers2[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 20:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 21:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows2[arrowIndex].SetActive(false);
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 22:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 23:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers2[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 24:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 25:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows2[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 26:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 27:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers2[numberIndex].SetActive(false);
                    // benutzter number aus array entfernen
                    screenRightNumbers2 = screenRightNumbers2.Where((source, index) => index != numberIndex).ToArray();
                    
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows2.Length);
                    screenLeftArrows2[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 28:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows2[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 29:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows2[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows2 = screenLeftArrows2.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers2.Length);
                    screenRightNumbers2[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 30:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers2[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 31:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers2[numberIndex].SetActive(false);
                    Debug.Log("2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen)");
                    // ##########   2ter Durchgang beendet (8 x TP & 8 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 32:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 33:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftArrows3[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);

                    // berechneten Screen aktiv setzen
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 34:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 35:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightNumbers3[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 36:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 37:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows3[arrowIndex].SetActive(false);
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 38:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 39:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers3[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 40:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 41:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows3[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 42:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 43:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers3[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers3 = screenRightNumbers3.Where((source, index) => index != numberIndex).ToArray();
                    
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows3.Length);
                    screenLeftArrows3[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 44:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows3[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 45:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows3[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows3 = screenLeftArrows3.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers3.Length);
                    screenRightNumbers3[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 46:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers3[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 47:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers3[numberIndex].SetActive(false);
                    Debug.Log("3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen)");
                    // ##########   3ter Durchgang beendet (12 x TP & 12 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 48:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 49:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftArrows4[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);

                    // berechneten Screen aktiv setzen
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 50:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 51:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightNumbers4[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 52:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 53:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows4[arrowIndex].SetActive(false);
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 54:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 55:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers4[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 56:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 57:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows4[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 58:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 59:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers4[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers4 = screenRightNumbers4.Where((source, index) => index != numberIndex).ToArray();
                    
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows4.Length);
                    screenLeftArrows4[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 60:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows4[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 61:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows4[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows4 = screenLeftArrows4.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers4.Length);
                    screenRightNumbers4[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 62:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers4[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 63:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers4[numberIndex].SetActive(false);
                    Debug.Log("4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen)");
                    // ##########   4ter Durchgang beendet (16 x TP & 16 x MWD abgeschlossen) ##########
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.enabled = true;
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 64:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 9");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    Debug.Log("Spacebar pressed");
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 65:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    screenLeftArrows5[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    // numberIndex berechnen
                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);

                    // berechneten Screen aktiv setzen
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.enabled = true;
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 66:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 2");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 67:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");


                    screenRightNumbers5[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 68:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 3");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");



                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 69:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows5[arrowIndex].SetActive(false);
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 70:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 4");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 71:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers5[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();

                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 72:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 5");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 73:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows5[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 74:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 6");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 75:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers5[numberIndex].SetActive(false);
                    // benutzter arrow aus array entfernen
                    screenRightNumbers5 = screenRightNumbers5.Where((source, index) => index != numberIndex).ToArray();
                    
                    arrowIndex = UnityEngine.Random.Range(0, screenLeftArrows5.Length);
                    screenLeftArrows5[arrowIndex].SetActive(true);
                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[0];
                    break;
                case 76:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 7");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenLeft = screenLeftArrows5[arrowIndex].GetComponent<Renderer>();
                    _rendScreenLeft.sharedMaterial = material[1];
                    break;
                case 77:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenLeftArrows5[arrowIndex].SetActive(false);
                    // entfernt bereits benutztes Item aus array
                    screenLeftArrows5 = screenLeftArrows5.Where((source, index) => index != arrowIndex).ToArray();

                    numberIndex = UnityEngine.Random.Range(0, screenRightNumbers5.Length);
                    screenRightNumbers5[numberIndex].SetActive(true);
                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[0];
                    break;
                case 78:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeMessageToLog("Aufgabe 8");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    _rendScreenRight = screenRightNumbers5[numberIndex].GetComponent<Renderer>();
                    _rendScreenRight.sharedMaterial = material[1];
                    break;
                case 79:
                    // Logging
                    Debug.Log("[Logging] Key down = Space");
                    logger.writeAOTMessageWithTimestampToLog("KEY_DOWN", "KEYBOARD", "SPACE");

                    screenRightNumbers5[numberIndex].SetActive(false);
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
    
}
