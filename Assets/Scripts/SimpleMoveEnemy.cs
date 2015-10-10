using UnityEngine;
using System.Collections;

public class SimpleMoveEnemy : MonoBehaviour {

    public float speed = 3.0f;
    public bool seen = false;

    public float scaleSpeed = 3.0f;

    private float timerdestroy = 0.0f;

    private AudioSystem audioSys;


    // Use this for initialization
    void Start()
    {
        audioSys = GameObject.Find("Audio System").GetComponent<AudioSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerdestroy < 0.0f)
            timerdestroy -= Time.deltaTime;

        Vector3 scale = transform.localScale;
        scale = new Vector3(1,1,1) * ( 1 + audioSys.debugvalue);

        // Condition that provide enemy to flicker (when the change of scale is rly low)
        if (scale.x - transform.localScale.x <= 0.08f && scale.x - transform.localScale.x >= -0.08f) { }
        else
            transform.localScale = scale;

        float t = Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y += t * speed;
        transform.position = pos;

        if (GetComponent<Renderer>().isVisible)
            seen = true;

        if (seen && !GetComponent<Renderer>().isVisible)
            timerdestroy = 2.0f;

        //timer is finished -> destroy the object
        if (timerdestroy < 0.0f)
            Destroy(gameObject);
    }
}
