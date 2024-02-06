using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [Range(5,20)]
    public float speed = 8f;
    private Vector2 nowPos, prePos;
    private Vector2 movePos;

    public bool isJump = false;

    public TextMeshProUGUI text;

    public Transform player;

    Rigidbody rigid;
    public Animator anim;
    public bool isRotate;
    public float rotationSpeed;

    private void Awake()
    {
        rigid = player.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();
    }
    private void Start()
    {
        Debug.Log(transform);
        Debug.Log(GameManager.instance);
        GameManager.Instance.player = transform;
        
    }

    private void Update()
    {
        if (!GameManager.Instance.isPause)
        {
            transform.position += player.forward * speed * Time.deltaTime;
        
        
        text.text = "curSpeed : " + speed;
        anim.SetBool("IsRun", true);

        if (Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                prePos = touch.position - touch.deltaPosition;
            }

            if (!isJump && touch.deltaPosition.y > 100)
            {
                Jump();
            }
            //if (!isRotate)
            //{
            //    if (touch.deltaPosition.x > 100)
            //    {
            //        Debug.Log("오른쪽");
            //        Quaternion targetRotation = player.rotation * Quaternion.Euler(0, 90f, 0);
            //        player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            //        isRotate = true;
            //    }

            //    else if (touch.deltaPosition.x < -100)
            //    {
            //        Debug.Log("왼쪽");
            //        Quaternion targetRotation = player.rotation * Quaternion.Euler(0, -90f, 0);
            //        player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            //        isRotate = true;
            //    }
            //}
        }
        else if (Input.touchCount == 0)
        {
            isRotate = false;
        }
        }


    }

    void Jump()
    {
        isJump = true;
        rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
        transform.position += player.forward * 8 * Time.deltaTime;
        Debug.Log("점프");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
        else if(collision.gameObject.tag == "Water")
        {
            anim.SetTrigger("Die");
            GameManager.Instance.isPause = true;
        }
    }
}
