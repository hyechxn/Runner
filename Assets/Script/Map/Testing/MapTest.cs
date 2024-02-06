using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapTest : MonoBehaviour
{
    public Transform pointer;
    public GameObject grass;
    public GameObject clearPoint;
    Transform player;
    [Range(10, 50)]
    public int count = 10;
    public Transform holder;

    private void Start()
    {
        player = GameManager.Instance.player;
        StartCoroutine(Mount());
    }
    private IEnumerator Mount()
    {
        GameObject temp1 = Instantiate(grass, pointer.position, Quaternion.identity);
        temp1.transform.SetParent(holder);
        int n=0;
        do
        {
            int ranNum = Random.Range(0, 7);
            
            switch (ranNum)
            {
                case 0:
                case 1:
                    movePointer("r");
                    break;
                case 2:
                case 3:
                    movePointer("l");
                    break;
                case 4:
                case 5:
                case 6:
                    movePointer("f");
                    break;
            }
            if (!checkAlready())
            {
                n++;
            }
            GameObject temp2 = Instantiate(grass, pointer.position, Quaternion.identity);
            temp2.transform.SetParent(holder);
            yield return null;
        }while(n<=count);
        Instantiate(clearPoint, pointer.position, Quaternion.identity);
    }

    void movePointer(string direct)
    {
        switch (direct)
        {
            case "r":
                pointer.position = new Vector3(pointer.position.x, pointer.position.y, pointer.position.z + 10);
                break;
            case "l":
                pointer.position = new Vector3(pointer.position.x, pointer.position.y, pointer.position.z - 10);
                break;
            case "f":
                pointer.position = new Vector3(pointer.position.x + 10, pointer.position.y, pointer.position.z);
                break;

        }
    }

    bool checkAlready()
    {
        return Physics.Raycast(pointer.position, Vector3.down, 1f, 6);
    }
}
