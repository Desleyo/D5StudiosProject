using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerCamera : MonoBehaviour
{
    [Header("--Settings--")]
    [Tooltip("Sensitivity of the camera movement")]
    public float sensitivity = 3f;
    public float maxRotX = 45f;
    public float minRotX = -55;
    public Vector3 camOffset;

    [Header("--Player reference--")]
    public GameObject player;  

    [HideInInspector]
    public float rotCamX;
    [HideInInspector]
    public float rotCamY;

    private void Awake()
    {
        HideCursor();
    }

    private void LateUpdate()
    {
        CameraPos();
    }

    void CameraPos()
    {
        rotCamY = Input.GetAxis("Mouse X") * sensitivity;
        rotCamX += Input.GetAxis("Mouse Y") * sensitivity;

        //Clamping the rotX value
        rotCamX = Mathf.Clamp(rotCamX, minRotX, maxRotX);

        //EulerAngles for the camera rotation (this is so it rotates around the player)
        transform.eulerAngles = new Vector3(-rotCamX, transform.eulerAngles.y + rotCamY, 0);
        transform.position = player.transform.position + camOffset;
        player.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + rotCamY, 0);
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
