using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private float mouseSensivity;

    [SerializeField]
    private Transform playerBody;
    private float xAxisClamp;

    private void Awake()
    {
        mouseSensivity = 150.0f;
        xAxisClamp = 0.0f;
        LockCursor();
    }

    private void Update()
    {
        if (MySceneManager.gameWon || MySceneManager.gameLost)
            Cursor.lockState = CursorLockMode.None;

        if(!MySceneManager.gameWon)
            CameraRotation();

    }

    private void LockCursor()
    {
        //lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xAxisClamp += mouseY;

        //if looking up
        if (xAxisClamp > 90.0f)
        {
            //clamp camera
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotation(270);
        }

        //if looking down
        else if (xAxisClamp < -90.0f)
        {
            //clamp camera
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotation(90);
        }
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotation(float _value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = _value;
        transform.eulerAngles = eulerRotation;
    }
}
