using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    Animator anim;

    public bool isRun;

    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("IsRun", isRun);
    }
    
    [ContextMenu("Jump")]
    void Jump()
    {
        anim.SetTrigger("Jump");
    }
}
