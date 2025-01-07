using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("GameController");
        if (gameManagers.Length > 1)
        {
            Destroy(gameManagers[1]);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
