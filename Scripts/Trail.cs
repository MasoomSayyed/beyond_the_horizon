using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private PlayerInput playerInput;
    private TrailRenderer trailRenderer;
    private ParticleSystem bubbles;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        trailRenderer = playerInput.GetComponentInChildren<TrailRenderer>();
        trailRenderer.enabled = false;
        bubbles = playerInput.GetComponentInChildren<ParticleSystem>();
        var bubblesSimulationSystem = bubbles.main;
        bubblesSimulationSystem.simulationSpace = ParticleSystemSimulationSpace.World;
    }

    void Update()
    {
        ToggleTrail();
    }

    private void ToggleTrail()
    {
        if (playerInput.shipMode == PlayerInput.ShipModes.Sailing)
        {
            trailRenderer.enabled = true;
            bubbles.Pause();
            bubbles.Clear();
        }
        else
        {
            trailRenderer.enabled = false;
            bubbles.Play();
            HandleBubblesRotation();
        }
    }

    private void HandleBubblesRotation()
    {
        bubbles.transform.rotation = Quaternion.LookRotation(Vector3.up, Vector3.up);
    }
}