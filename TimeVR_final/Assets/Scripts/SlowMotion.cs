using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlowMotion : MonoBehaviour
{
    public GameObject camera;

    public bool delayOn;
    public bool slowMotionOn;
    Quaternion rotation;
    Vector3 position;
    public float delay;
    public float rotationTime;
    private float timeToUpdate = 0f;
    public float rotationAngle;
    Quaternion lastRotation;
    Quaternion currentRotation;
    Vector3 currentPosition;
    bool rotationFinished;
    bool rotating;
    float _Speed;
    // Start is called before the first frame update

    //Liste erstellen
    List<Quaternion> listOfQuaternions;
    List<Vector3> listOfPositions;
    void Start()
    {
        

        //UnityEngine.XR.InputTracking.disablePositionalTracking = true;

        // Liste instanziieren
        listOfQuaternions = new List<Quaternion>();
        listOfPositions = new List<Vector3>();


        // Versuch den offset zu korrigieren, Kamera wird aber immernoch aus den Raum geschubst
        //transform.Translate(new Vector3(3, 1, 0));


    }

    // Update is called once per frame
    void Update()
    {

        timeToUpdate += Time.deltaTime;
        //rotation = UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye);
        rotation = camera.transform.rotation;
        //position = UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
        position = camera.transform.position;
        currentRotation = transform.rotation;
        currentPosition = transform.position;

        if (slowMotionOn)
        {
            //this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>().trackingType = 2;

            // "Slow Motion"
            transform.rotation = Quaternion.Lerp(currentRotation, rotation, rotationAngle);
            transform.position = Vector3.Lerp(currentPosition, position, rotationAngle);
        }



        if (delayOn)
        {
            //this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>().trackingType = 2;

            // Latency

            listOfQuaternions.Add(rotation);
            listOfPositions.Add(position);

            if (listOfQuaternions.Count == 60)
            {
                listOfQuaternions.RemoveAt(0);
            }

            if (listOfPositions.Count == 60)
            {
                listOfPositions.RemoveAt(0);
            }


            transform.rotation = listOfQuaternions[listOfQuaternions.Count / 2];
            transform.position = listOfPositions[listOfPositions.Count / 2];
            Debug.Log(listOfQuaternions.Count / 2);
            Debug.Log(Time.deltaTime);
        }

        if (slowMotionOn == false && delayOn == false)
        {
            Debug.Log("Test!!!");
            transform.position = camera.transform.position;
            transform.rotation = camera.transform.rotation;
            
        }
    }

    public void switchTrackedPoseDriverOnOff()
    {
			if (this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>() == null)
			{
				this.gameObject.AddComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>();
        }
        else
        {
            Destroy(this.gameObject.GetComponent<UnityEngine.SpatialTracking.TrackedPoseDriver>());
        }
    }

    public void switchBoolean()
    {
        slowMotionOn = !slowMotionOn;
    }
}