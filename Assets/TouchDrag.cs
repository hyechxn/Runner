using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
    private float speed = 0.25f;
    private Vector2 nowPos, prePos;
    private Vector2 movePos;

    private bool isJump = false;

    public Transform player;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    Rigidbody rigid;
    public Animator anim;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        text1.text = "TouchCount : " + Input.touchCount;
        text2.text = "prePos : " + prePos;
        text3.text = "nowPos : " + nowPos;
        if (Input.touchCount == 1)
        {
           
        }
        else if (Input.touchCount == 2)
        {
            Touch touch = Input.GetTouch(0);
            text4.text = "deltaPos : " + touch.deltaPosition;
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                prePos = touch.position - touch.deltaPosition;
            }

            if (!isJump)
            {
                Jump();
                touch.deltaPosition = Vector2.zero;
            }
            if (touch.deltaPosition.y < -100)
            {
                StartCoroutine(Slam());
                touch.deltaPosition = Vector2.zero;
            }


        }


        else if (Input.touchCount == 3)
        {
            anim.SetBool("IsRun", false);
            rigid.velocity = Vector2.zero;
            rigid.velocity = transform.forward * 5;
        }
        else if (Input.touchCount == 4)
        {
            rigid.velocity = transform.forward * 20;
            anim.SetBool("IsRun", true);

        }
        else if(Input.touchCount == 5)
            rigid.velocity = transform.forward * 200;
    }

    void Jump()
    {
        isJump = true;
        rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
        rigid.velocity = transform.forward * 8;
        Debug.Log("Á¡ÇÁ");
    }

    IEnumerator Slam()
    {
        rigid.velocity = Vector3.zero;
        rigid.AddForce(Vector3.down * 100, ForceMode.Impulse);
        yield return new WaitForSeconds(0.3f);
        rigid.velocity = Vector3.zero;
        Debug.Log("³»·Á°«");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }
}
