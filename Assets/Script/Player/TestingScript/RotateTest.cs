using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    static float rotateSpeed = 360f;

    bool isLButtonDowning;
    bool isRButtonDowning;

    private void Update()
    {
        if (GameManager.Instance.isPause) return;
        if (isLButtonDowning)
            LeftRotate();
        else if (isRButtonDowning)
            RightRotate();
    }
    public void LeftRotate()
    {
        Debug.Log("¿ÞÂÊ");
        Quaternion targetRotation = GameManager.Instance.player.rotation * Quaternion.Euler(0, -1f, 0);
        GameManager.Instance.player.rotation = Quaternion.Slerp(GameManager.Instance.player.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    public void RightRotate()
    {
        Debug.Log("¿À¸¥ÂÊ");
        Quaternion targetRotation = GameManager.Instance.player.rotation * Quaternion.Euler(0, 1f, 0);
        GameManager.Instance.player.rotation = Quaternion.Slerp(GameManager.Instance.player.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    public void LeftButtonDown()
    {
        isLButtonDowning = true;
    }
    public void LeftButtonUp()
    {
        isLButtonDowning = false;
    }
    public void RightButtonDown()
    {
        isRButtonDowning = true;
    }
    public void RightButtonUp()
    {
        isRButtonDowning = false;
    }
}
