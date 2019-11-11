using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    public Text locationText;
    void Awake()
    {
        StartCoroutine("Start");
    }
    IEnumerator Start()
    {
        // First, check if user has location service enabled
        locationText.text="ran";
        print ("ran");
        if (!Input.location.isEnabledByUser)
        {
            locationText.text="no permission";
            yield break;
        }
        // Start service before querying location
        Input.location.Start(5);

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            locationText.text="cannot connect to sensor";
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            locationText.text="Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }
        StartCoroutine("LocationUpdate");
        // Stop service if there is no need to query location updates continuously
    }
    IEnumerator LocationUpdate()
    {
        locationText.text="Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("LocationUpdate");

    }
}