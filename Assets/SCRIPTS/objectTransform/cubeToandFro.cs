using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeToandFro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.PingPong(Time.time * 0.2f, 1) * 6 - 3;
        transform.position = transform.position + new Vector3(0, 0, z * Time.deltaTime);
    }
}
