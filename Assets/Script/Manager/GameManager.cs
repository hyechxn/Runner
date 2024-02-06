using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject tempGm = new GameObject("GameObject");
                instance = tempGm.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    public Transform player;
    public bool isPause;
}
