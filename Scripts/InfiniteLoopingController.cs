using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteLoopingController : MonoBehaviour
{

    Vector2 screenBound;
    BoundboxGenerator[] boundBoxes;

    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        boundBoxes = GetComponentsInChildren<BoundboxGenerator>();
    }

    private void LateUpdate()
    {
        RepositionObjects(boundBoxes);
    }

    void RepositionObjects(BoundboxGenerator[] boxes)
    {
        var children = boxes;

        if (children.Length > 1)
        {
            GameObject firstChild = children[0].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<BoundboxGenerator>().TotalBounds.extents.x;
            if (transform.position.x + screenBound.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBound.x < lastChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
        }
    }
}