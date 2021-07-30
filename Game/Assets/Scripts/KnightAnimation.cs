using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
            anim.SetBool("isIdle", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
            anim.SetBool("isUp", false);
            anim.SetBool("isDown", false);
        }
    }
}
