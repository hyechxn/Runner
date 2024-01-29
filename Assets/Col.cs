using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col : MonoBehaviour
{
    private BoxCollider col;
    private const float defaultNum = 2.5f;
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        col.center = new Vector3(0, transform.localPosition.y + defaultNum, 0);
    }
}
