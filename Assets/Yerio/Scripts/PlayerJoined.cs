using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoined : Bolt.EntityBehaviour<IPlayerControllerState>
{
    [SerializeField] Camera playerCamera;

    public override void Attached()
    {
        base.Attached();       
    }

    private void Update()
    {
        if(entity.IsOwner && !playerCamera.gameObject.activeInHierarchy)
        {            
           playerCamera.gameObject.SetActive(true);           
        }
    }
}
