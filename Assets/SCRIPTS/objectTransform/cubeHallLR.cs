using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeHallLR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.PingPong(Time.time * 0.2f, 1) * 6 - 3;
        transform.position = transform.position + new Vector3(x *Time.deltaTime,0, 0);
    }
}
