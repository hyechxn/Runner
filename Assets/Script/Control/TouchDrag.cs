using System.Collections;
using TMPro;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
    private float speed = 0.25f;
    private Vector2 nowPos, prePos;
    private Vector2 movePos;

    public bool isJump = false;

    public Transform player;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    Rigidbody rigid;
    public Animator anim;
    public bool isRotate;
    public float rotationSpeed;

    private void Awake()
    {
        rigid = player.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {

        text1.text = "TouchCount : " + Input.touchCount;
        text2.text = "prePos : " + prePos;
        text3.text = "nowPos : " + nowPos;
        if (Input.touchCount == 1)
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

            if (!isJump && touch.deltaPosition.y > 100)
            {
                Jump();
            }
            if (touch.deltaPosition.y < -100)
            {
                StartCoroutine(Slam());
            }
            if (!isRotate)
            {
                if (touch.deltaPosition.x > 100)
                {
                    Debug.Log("¿À¸¥ÂÊ");
                    Quaternion targetRotation = player.rotation * Quaternion.Euler(0, 90f, 0);
                    player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                    isRotate = true;
                }

                else if (touch.deltaPosition.x < -100)
                {
                    Debug.Log("¿ÞÂÊ");
                    Quaternion targetRotation = player.rotation * Quaternion.Euler(0, -90f, 0);
                    player.rotation = Quaternion.Lerp(player.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                    isRotate = true;
                }
            }





        }
        else if (Input.touchCount == 3)
        {
            anim.SetBool("IsRun", false);
            transform.position += player.forward * 5 * Time.deltaTime;
        }
        else if (Input.touchCount == 4)
        {
            transform.position += player.forward * 20 * Time.deltaTime;
            anim.SetBool("IsRun", true);

        }
        else if (Input.touchCount == 5)
            transform.position += player.forward * 200 * Time.deltaTime;
        if (Input.touchCount != 2)
        {
            isRotate = false;
        }


    }

    void Jump()
    {
        isJump = true;
        rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
        transform.position += player.forward * 8 * Time.deltaTime;
        Debug.Log("Á¡ÇÁ");
    }

    IEnumerator Slam()
    {
        rigid.AddForce(Vector3.down * 100, ForceMode.Impulse);
        yield return new WaitForSeconds(0.3f);
        rigid.velocity = Vector3.zero;
        Debug.Log("³»·Á°«");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
        }
    }
}
