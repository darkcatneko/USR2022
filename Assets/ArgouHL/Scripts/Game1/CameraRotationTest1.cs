using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationTest1 : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float rotationSpeed;


    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void Update()
    {


        float XValue = inputManager.WASD().x;
        float YValue = -inputManager.WASD().y;
        _camera.transform.rotation = Quaternion.Euler(YValue * rotationSpeed + _camera.transform.rotation.eulerAngles.x, XValue * rotationSpeed + _camera.transform.rotation.eulerAngles.y, 0f);

    }
}
