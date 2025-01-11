using System.Collections;
using UnityEngine;
using System.Collections;


public class DestroyObject : MonoBehaviour
{

    private void Update()
    {
        DestroyEvent();
    }
    public void DestroyEvent()
    {
        Destroy(gameObject, 0.42f);
    }
}