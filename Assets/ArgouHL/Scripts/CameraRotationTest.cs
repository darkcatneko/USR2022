using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotationTest : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float rotationSpeed;
    





   public void test(InputAction.CallbackContext inpuValue)
    {
        if (!Mouse.current.rightButton.isPressed)
            return;


        float XValue = inpuValue.ReadValue<Vector2>().x;
        float YValue = -inpuValue.ReadValue<Vector2>().y;
        _camera.transform.rotation = Quaternion.Euler(YValue* rotationSpeed + _camera.transform.rotation.eulerAngles.x, XValue * rotationSpeed + _camera.transform.rotation.eulerAngles.y, 0f);

    }
}
