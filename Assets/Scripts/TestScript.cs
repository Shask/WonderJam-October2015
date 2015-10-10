using UnityEngine;
using System.Collections;


public class TestScript : MonoBehaviour, AudioProcessor.AudioCallbacks
{

	// Use this for initialization
	void Start () {
        Debug.Log("Test");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onOnbeatDetected()
    {
        Debug.Log("Beat!!!");
    }

    public void onSpectrum(float[] spectrum)
    {

    }
}
