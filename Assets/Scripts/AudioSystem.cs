using UnityEngine;
using System.Collections;
using System;

public class AudioSystem : MonoBehaviour {


    public int BPM = 130; //beat per minute 
    public GameObject[] spawnList; //spawn list
    public GameObject Enemy; //Enemy prefab

    private DamierLoader damLoad;
    private FloorRythm floorRythm;

    public float cooldown = 0.0f;//cooldown in between enemy spawn


    public float spawnThreshold = 0.5f;
    public int frequency=0;


    private float[] samples = new float[1024];
    public FFTWindow fftWindow;


    public float debugvalue;

    private float timerBPM;

    private System.Random random;

	// Use this for initialization
	void Start () {
        damLoad = GameObject.Find("FullDamier").GetComponent<DamierLoader>();
        floorRythm = GameObject.Find("RythmBoxes").GetComponent<FloorRythm>();
        random = new System.Random();
        timerBPM = 1.0f / (BPM / 60.0f);

    }
	
	// Update is called once per frame
	void Update() {

        if (timerBPM > 0.0f)
            timerBPM -= Time.deltaTime;
       if (timerBPM <= 0.0f)
       {
            damLoad.switchDamier();
            floorRythm.switchLane();
            timerBPM = 1.0f / (BPM / 60.0f);
       }

        if (cooldown > 0.0f)
            cooldown -= Time.deltaTime;

        debugvalue = samples[frequency];
        AudioListener.GetSpectrumData(samples, 0, fftWindow);


            

        if (samples[frequency] > spawnThreshold && cooldown<=0.0f)
        {
            GameObject ChosenspawnLocation = spawnList[random.Next(0, spawnList.Length)];
            Instantiate(Enemy, ChosenspawnLocation.transform.position, ChosenspawnLocation.transform.rotation);
            cooldown =  1.0f / (BPM / 60.0f);
            cooldown = cooldown * 2.0f;
        }
    }
}
