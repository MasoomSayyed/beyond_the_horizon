using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private float parallaxEffect; // Adjusts the speed of parallax for each layer

    private float startPosX = 125f;
    private float endPosX = -150f;

    private float startingPosition;
    private float cameraPos;
    private Transform cameraTransform;

    void Start()
    {
        startingPosition = transform.position.x;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {

        float tempParallax = (cameraTransform.position.x * parallaxEffect);
        float distToMove = startingPosition + tempParallax;
        transform.position = new Vector3(distToMove, transform.position.y, transform.position.z);

    }

}