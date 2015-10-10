using UnityEngine;
using System.Collections;

public class SimpleMoveEnemy : MonoBehaviour {

    public float speed = 3.0f;
    public bool seen = false;

    private float timerdestroy = 0.0f;



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timerdestroy < 0.0f)
            timerdestroy -= Time.deltaTime;



        float t = Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y -= t * speed;
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
