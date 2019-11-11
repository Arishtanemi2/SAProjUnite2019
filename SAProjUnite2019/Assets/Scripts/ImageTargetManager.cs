using UnityEngine;
using System.Collections;
using Vuforia;
public class ImageTargetManager : MonoBehaviour, ITrackableEventHandler {
	
	private TrackableBehaviour mTrackableBehaviour;
	
    public Animator anim;
    public GameObject TextPanel;
    public GameObject congoPanel;
	
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
	}
	
	public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            anim.SetTrigger("openchest");
            TextPanel.SetActive(false);
            congoPanel.SetActive(true);
        }
        else
        {
            anim.ResetTrigger("openchest");
             TextPanel.SetActive(true);
            congoPanel.SetActive(false);
        }
    }
	
}