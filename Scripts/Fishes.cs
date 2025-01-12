using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Fishes : MonoBehaviour
{
    private CapsuleCollider2D[] fishes;
    [SerializeField] private int[] numFishes;
    private FishHoarde[] fishHoardes;
    void Start()
    {
        fishes = GetComponentsInChildren<CapsuleCollider2D>();
        if (fishes != null)
        {
            fishHoardes = new FishHoarde[fishes.Length];
            for (int i = 0; i < fishes.Length; i++)
            {
                fishHoardes[i] = new FishHoarde(fishes[i], numFishes[i]);
                fishHoardes[i].SpawnFishes();
                fishes[i].gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("CapsuleCollider2D not found in children");
        }
    }

    private void Update()
    {
        MoveFishes();
    }

    public class FishHoarde
    {
        public CapsuleCollider2D originalFish;
        public CapsuleCollider2D[] fishesInHoarde;
        public int numFishes;
        public float minValue = -0.5f;
        public float maxValue = 0.5f;
        public float[] hoardeSpeed;
        public FishHoarde(CapsuleCollider2D originalFish, int numFishes)
        {
            this.originalFish = originalFish;
            this.numFishes = numFishes;
            fishesInHoarde = new CapsuleCollider2D[numFishes];
            hoardeSpeed = new float[numFishes];

            float minSpeed = .1f;
            float maxSpeed = .4f;
            for (int i = 0; i < numFishes; i++)
            {
                hoardeSpeed[i] = Random.Range(minSpeed * Time.deltaTime, maxSpeed * Time.deltaTime);
                if (Mathf.Round(Random.Range(0, 1)) > 0)
                {
                    hoardeSpeed[i] *= -1; // -ve Velocity for left and +ve velocity for right
                }
            }
        }
        public void SpawnFishes()
        {

            for (int i = 0; i < numFishes; i++)
            {
                CapsuleCollider2D newFish = Instantiate(originalFish);
                newFish.name = originalFish.name + i;
                float xOffset = Random.Range(minValue, maxValue);
                float yOffset = Random.Range(minValue, maxValue);
                float sizeScale = Random.Range(0.25f, 0.75f);
                newFish.transform.position = new Vector3(originalFish.transform.position.x + xOffset, originalFish.transform.position.y + yOffset, 0);
                newFish.transform.localScale *= sizeScale;
                fishesInHoarde[i] = newFish;
            }
        }
    }

    private void MoveFishes()
    {
        foreach (FishHoarde hoarde in fishHoardes)
        {
            for (int i = 0; i < hoarde.fishesInHoarde.Length; i++)
            {
                hoarde.fishesInHoarde[i].transform.position = new Vector3(hoarde.fishesInHoarde[i].transform.position.x + hoarde.hoardeSpeed[i], hoarde.fishesInHoarde[i].transform.position.y, 0);
                FishesCollision collision = hoarde.fishesInHoarde[i].GetComponent<FishesCollision>();
                if (collision.hasCollided)
                {
                    hoarde.hoardeSpeed[i] *= -1;
                    collision.hasCollided = false;
                    float angle = 0f;
                    if (hoarde.hoardeSpeed[i] < 0)
                    {
                        angle = 180f;
                    }
                    hoarde.fishesInHoarde[i].transform.eulerAngles = new Vector3(0, angle, 0); ;
                }
            }
        }
    }
}