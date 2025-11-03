using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        cam = GameObject.Find("playerCam");
    }

    // Update is called once per frame
    void Update()
    {
        //float z = Input.GetAxis("Horizontal");
        ////transform.position = player.transform.position + new Vector3(0,2,-3);
        //cam.transform.RotateAround(player.transform.position, Vector3.up, -z);
        //cam.transform.LookAt(player.transform);

        float mouse = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0,mouse * 2f, 0));
    }
}
