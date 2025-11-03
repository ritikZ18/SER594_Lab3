using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovementRevised : MonoBehaviour
{
    GameObject cam;
    
    public float moveSpeed = 25f;
    public float JumpSpeed = 300f;
    public float xInput;
    public float zInput;

    Rigidbody rb;

    public SpawnerScript sp;

    bool isGrounded()
    {
        return GetComponent<Rigidbody>().velocity.y == 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("playerCam");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        transform.Translate(cam.transform.forward * moveSpeed * zInput * Time.deltaTime);
        transform.Translate(cam.transform.right * moveSpeed * xInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            transform.Translate(Vector3.up * JumpSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("shifted");
            transform.rotation = Quaternion.identity;
        }

        if (dialouge) return; // no movement during dialogue
    }

    


    static public bool dialouge = false; 
}
