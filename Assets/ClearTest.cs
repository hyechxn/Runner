using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            GameManager.instance.isPause = true;
            GameManager.instance.player.GetComponent<PlayerTest>().anim.SetTrigger("Win");
            Debug.Log("clear");
        }
    }
}
