using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;


    public Quaternion currentAngle;

    Vector3 moveVec;


    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }   
    


    void Update()
    {
        Turn();
        Getinput();
        Move();


    }
    void Getinput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
    }
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;



        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);

        if (hAxis == 0 && vAxis == 0)
        {
            Debug.Log("asdsaad");
        }
        else
        {
            Quaternion newRotation = Quaternion.LookRotation(moveVec);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 1f * Time.deltaTime);
            Debug.Log("결과 : " + hAxis);
            Debug.Log("결과 : " + vAxis);
        }

            
    }
}
