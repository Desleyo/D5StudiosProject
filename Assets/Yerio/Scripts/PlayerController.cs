using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Bolt.EntityBehaviour<IPlayerControllerState>
{
    [Header("Stats")]
    [SerializeField] float moveSpeed = 4;

    float horiontal;
    float vertical;
    public override void Attached()
    {
        base.Attached();
        state.SetTransforms(state.PlayerTransform, transform);
    }

    public override void SimulateOwner()
    {
        base.SimulateOwner();
        Movement();
    }
    public void Movement()
    {
        horiontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horiontal, 0, vertical);

        transform.Translate(movement * moveSpeed * BoltNetwork.FrameDeltaTime, Space.Self);
    }

}
