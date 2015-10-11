using UnityEngine;
using System.Collections;

public class FloorHitBox : MonoBehaviour {

    private string DangerTag;
    private float timer;
    private bool overlaping = false;
    private AudioSystem audioSys;
    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        DangerTag = transform.parent.GetComponent<FloorRythm>().DangerTag;
        audioSys = GameObject.Find("Audio System").GetComponent<AudioSystem>();
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();


    }

    // Update is called once per frame
    void Update () {

        if (overlaping )
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f && tag == DangerTag)
            { 
                scoreManager.MissPlacement();
                timer = ResetTimer();
            }
            else if (tag != DangerTag)
                overlaping = false;

        }
	}
    void OnTriggerEnter(Collider co)
    {

        if(tag== DangerTag)
        overlaping = true;
    }
    void OnTriggerExit(Collider co)
    {
        overlaping = false;
        timer = ResetTimer();
    }
    void OnTriggerStay(Collider co)
    {
        if (tag == DangerTag)
            overlaping = true;
        else
        {
            overlaping = false;
            timer = ResetTimer();
        }
    }


    //return the the time between every Beat divided by 2;
    float ResetTimer()
    {
        return (1.0f / (audioSys.BPM * 60.0f))/2;
    }
}
