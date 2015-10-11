using UnityEngine;
using System.Collections;

public class DamierLoader : MonoBehaviour {

    private GameObject[] Dam1;
    private GameObject[] Dam2;


    private float timer;
    // Use this for initialization
    void Start () {

        timer = 1.0f / (SceneSetup.BPM / 60.0f);


        float y = -14f;
        while(y<15.0f)
        { 
            GameObject go = (GameObject)Instantiate(Resources.Load("FlippableDamier"), new Vector3(-1.0f, y, 0.0f),new Quaternion());
            go.transform.parent = transform;
            y += 5;
        }

        if (Dam1 == null)
            Dam1 = GameObject.FindGameObjectsWithTag("Damier1");
        if (Dam2 == null)
            Dam2 = GameObject.FindGameObjectsWithTag("Damier2");

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    void FixedUpdate()
    {
        /*if (timer > 0.0f)
            timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
           
            timer = 1.0f / (BPM / 60.0f);
        }*/
    }
    public void switchDamier()
    {
        Material MDam1 = Dam1[0].GetComponent<Renderer>().material;
        Material MDam2 = Dam2[0].GetComponent<Renderer>().material;
        foreach (GameObject damier in Dam1)
        {
            damier.GetComponent<Renderer>().material = MDam2;
        }
        foreach (GameObject damier in Dam2)
        {
            damier.GetComponent<Renderer>().material = MDam1;
        }
    }
}
