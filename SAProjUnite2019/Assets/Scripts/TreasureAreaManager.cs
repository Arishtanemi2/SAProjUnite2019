using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureAreaManager : MonoBehaviour
{
    // Start is called before the first frame update
    WaitForSeconds waittime=new WaitForSeconds(2f);
    void Start()
    {
        StartCoroutine("VibrateDevice");
    }

    // Update is called once per frame
    IEnumerator VibrateDevice()
    {
        Handheld.Vibrate();
        yield return waittime;
        StartCoroutine("VibrateDevice");
    }
}
