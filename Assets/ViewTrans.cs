using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTrans : MonoBehaviour
{
    bool isBackView = true;
    [SerializeField]
    public Transform cameraHolder;


    Vector3 backPos = new Vector3(0, 11, -9.9f);
    Vector3 frontPos = new Vector3(0, 11, 9.9f);
    Quaternion backRot = Quaternion.Euler(25, 0, 0);
    Quaternion frontRot = Quaternion.Euler(30, 180, 0);

    void Update()
    {
        if (isBackView)
        {
            cameraHolder.localPosition = backPos;
            cameraHolder.localRotation = backRot;
        }
        else
        {
            cameraHolder.localPosition = frontPos;
            cameraHolder.localRotation = frontRot;
        }
    }

    public void TransView()
    {
        isBackView = !isBackView;
    }
}
