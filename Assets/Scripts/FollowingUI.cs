using UnityEngine;
using System.Collections;

public class FollowingUI : MonoBehaviour
{

    public Transform target;
    public Vector3 Offset;
    // Use this for initialization
    void Start()
    {
        Offset = new Vector3(0.0f, 0.75f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = target.position + Offset;
        transform.position = Camera.main.WorldToViewportPoint(pos);
      //  guiTest

    }
}