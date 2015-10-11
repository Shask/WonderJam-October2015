using UnityEngine;
using System.Collections;

public class SceneSetup : MonoBehaviour {

    //Rappel  public static String[] difficultyLevels = { "Tutoriel", "Facile", "Moyen", "Difficile" };
    public struct difficultySettup
    {
        public string songName;
        public int BPM;
    }
    private int difficulty;


    public static int BPM;
    public static string songName;

    public AudioClip[] songs;
    private difficultySettup[] d;


    // Use this for initialization
    void Start()
    {
        d = new difficultySettup[4];
        d[0].songName = "Unwritten Return.mp3";
        d[0].BPM = 80;

        d[1].songName = "Dirty_Ways.mp3";
        d[1].BPM = 130;

        d[2].songName = "Sonic_RoyalFree.mp3";
        d[2].BPM = 140;

        d[3].songName = "MegaMan_RoyalFree.mp3";
        d[3].BPM = 180;

        for (int i = 0; i < MenuCtrl.difficultyLevels.Length; i++)
            if (MenuCtrl.difficultyLevels[i] == MenuCtrl.FinalDifficulty)
                difficulty = i;

        BPM = d[difficulty].BPM;
        songName = d[difficulty].songName;

        Debug.Log(BPM);

        GetComponent<AudioSource>().clip = songs[difficulty];
        GetComponent<AudioSource>().Play();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
