using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private CharacterController controller;

    public float speed;

    private bool onground;
    public Transform bottom;
    public float radius;
    public LayerMask lm;
    Vector3 Gravity;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        gravityandjump();
    }

    void movement(){
        float x=Input.GetAxis("Horizontal");
        float z=Input.GetAxis("Vertical");

        Vector3 movevector= transform.right * x + transform.forward *z;

        controller.Move(movevector*speed* Time.deltaTime);
    }

    void gravityandjump(){
        onground =Physics.CheckSphere(bottom.position, radius,lm);

        if(onground){
            Gravity.y=-1f*Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.Space)){
                Gravity.y=jump;
            }
        }
        else{
            Gravity.y+=  -15f*Time.deltaTime;
        }
        controller.Move(Gravity* Time.deltaTime);
    }
}
