using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundboxGenerator : MonoBehaviour
{
    Bounds totalBounds;
    public Bounds TotalBounds { get => totalBounds; private set => totalBounds = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        DefineBoundbox();
    }

    private void DefineBoundbox()
    {
        var child = transform.GetComponentsInChildren<Renderer>(); // get all renderers inside the parent object
        TotalBounds = child[0].bounds; // init the bound box

        for (int i = 1; i < child.Length; i++)
        {
            TotalBounds.Encapsulate(child[i].bounds); // add the renderer boxes to the parent bound box
        }

        // debugging
        //if (TotalBounds != null)
        //{
        //    // Accessing bounds information
        //    Vector3 center = TotalBounds.center;
        //    Vector3 size = TotalBounds.size;
        //    Vector3 extents = TotalBounds.extents;

        //    Debug.Log("Renderer Bounds: Center=" + center + ", Size=" + size + ", Extents=" + extents);
        //}
    }
}
