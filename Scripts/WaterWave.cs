using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.U2D;

public class WaterWave : MonoBehaviour
{
    private int numSplinePoints = 1; //1 spline points for X scale of 1
    [SerializeField] private float spread = 0.5f; // Variable to control the amount of reverberations on the water surface
    [SerializeField] public float stiffness = 0.1f;
    [SerializeField] public float damping = 0.1f;
    private float force = -0.25f; // -1/0.25 for Y scale of 1
    private List<WaterSpring> waterSprings;
    private SpriteShapeController spriteShapeController;
    private UnityEngine.U2D.Spline spline;
    [SerializeField] private float volume;

    private void Start()
    {
        numSplinePoints = 1 * (int)gameObject.transform.localScale.x;
        force = -0.25f / gameObject.transform.localScale.y;
        spriteShapeController = GetComponent<SpriteShapeController>();
        if (spriteShapeController != null)
        {
            spline = spriteShapeController.spline;
            // Convert the coordinate system for every spline point: Local -> World
            /*for (int i = 0; i < spline.GetPointCount(); i++)
            {
                Vector3 worldPoint = spriteShapeController.transform.TransformPoint(spline.GetPosition(i));
                spline.SetPosition(i, new Vector3(worldPoint.x, spline.GetPosition(i).y, 0));
            }
            for (int i = 0; i < spline.GetPointCount(); i++)
            {
                Vector3 localPoint = spline.GetPosition(i);
                localPoint.x *= 1f/gameObject.transform.localScale.x;
                spriteShapeController.spline.SetPosition(i, localPoint);
            }*/
            // Insert the number of numSplinePoints between the second and third spline points
            var xDiff = Math.Abs(spline.GetPosition(2).x - spline.GetPosition(1).x);
            var xPos = spline.GetPosition(1).x;
            for (int i = 1; i <= numSplinePoints; i++)
            {
                xPos += xDiff / (numSplinePoints + 1);
                spline.InsertPointAt(i + 1, new Vector3(xPos, spline.GetPosition(1).y, 0));
                spline.SetTangentMode(i + 1, ShapeTangentMode.Continuous);
            }
            // Create water springs for every spline on the water surface
            waterSprings = new List<WaterSpring>(numSplinePoints + 2);
            for (int i = 0; i < numSplinePoints; i++)
            {
                waterSprings.Add(new WaterSpring(spline.GetPosition(i + 2).y, spline.GetPosition(i + 2).y, stiffness, damping));
            }
        }
        else
        {
            Debug.LogError("SpriteShapeController component not found on WaterWave GameObject.");
        }
    }
    // Function to create a splash by adding velocity to the water spring's height
    private void CreateSplash(int index, float velocity)
    {
        if (index >= 0 && index < waterSprings.Count)
        {
            waterSprings[index].velocity = velocity;
        }
    }

    void FixedUpdate()
    {
        PropagateWaves();
    }

    public void PropagateWaves()
    {
        // Update Water Springs
        for (int i = 0; i < waterSprings.Count; i++)
        {
            spline.SetPosition(i + 2, waterSprings[i].WaterSpringEffect(spline.GetPosition(i + 2).x, spline.GetPosition(i + 2).y)); // Adding water springs to every spline position
        }
        float[] leftHeightDiffs = new float[waterSprings.Count]; // Array to contain the height differences of the water springs to the left of the one in contact with the PlayerShip
        float[] rightHeightDiffs = new float[waterSprings.Count]; // Array to contain the height differences of the water springs to the right of the one in contact with the PlayerShip
        for (int i = 0; i < waterSprings.Count; i++)
        {
            if (i > 0)
            {
                leftHeightDiffs[i] = spread * (waterSprings[i].height - waterSprings[i - 1].height);
                waterSprings[i - 1].velocity += leftHeightDiffs[i];
                waterSprings[i - 1].height += leftHeightDiffs[i];
            }
            if (i < waterSprings.Count - 1)
            {
                rightHeightDiffs[i] = spread * (waterSprings[i].height - waterSprings[i + 1].height);
                waterSprings[i + 1].velocity += rightHeightDiffs[i];
                waterSprings[i + 1].height += rightHeightDiffs[i];
            }
        }
    }
    // A class for the springs in water
    private class WaterSpring
    {
        public float stiffness; // Stiffness of the water
        public float damping; // Damping effect of the water spring
        public float height; // Height of the water spring
        public float targetHeight; // Target height of the water spring
        public float velocity = 0f; // Velocity to add to the height and change its y position
        private float force = 0f; // Force of the PlayerShip
        private float mass = 1f; // Generalized mass of the PlayerShip

        // Constructor
        public WaterSpring(float height, float targetHeight, float stiffness, float damping)
        {
            this.height = height;
            this.targetHeight = targetHeight;
            this.stiffness = stiffness;
            this.damping = damping;
        }

        // Function to update the y position of the WaterSpring
        public Vector3 WaterSpringEffect(float xPos, float yPos)
        {
            force = -1 * ((stiffness * (height - targetHeight)) + (damping * velocity)); // F = - ((stiffness * dy) + k(dx/dt))
            velocity += force / mass; // integral(F/m)
            height = yPos + velocity;
            return new Vector3(xPos, height, 0);
        }
    }

    // A function to handle triggers when the PlayerShip enters/exits the water collider
    private void PlayerTrigger(Collider2D collider, float force)
    {
        if (collider.CompareTag("Player"))
        {
            Rigidbody2D ship = collider.GetComponent<Rigidbody2D>(); // Getting the RigidBody2D component
            if (ship != null)
            {
                Bounds spriteBounds = ship.GetComponentInChildren<SpriteRenderer>().bounds; // Getting the bounds of the PlayerShip
                var contactPointStartX = spriteBounds.center[0] - (spriteBounds.size[0] / 2); // Getting the X value of the starting contact point
                var contactPointEndX = spriteBounds.center[0] + (spriteBounds.size[0] / 2); // Getting the X value of the ending contact point
                List<int> splineContactIndices = new List<int>(); // Creating a List to handle spilne indices
                for (int i = 0; i < waterSprings.Count; i++)
                {
                    var splineWolrdPosX = transform.TransformPoint(spline.GetPosition(i + 2)).x;
                    if (splineWolrdPosX >= contactPointStartX && splineWolrdPosX <= contactPointEndX) // Adding the spline point only if it is in contact with the PlayerShip
                    {
                        splineContactIndices.Add(i);
                    }
                }
                // Creating a splash using the List of spline point indices
                for (int i = 0; i < splineContactIndices.Count; i++)
                {
                    CreateSplash(splineContactIndices[i], force);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerTrigger(collider, force);
        TriggerToSailing.Instance.SetIsJumpingFalse();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        PlayerTrigger(collider, -force);
    }
}