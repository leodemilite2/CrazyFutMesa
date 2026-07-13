using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 startMousePosition;

    private void OnMouseDown()
    {
        startMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        startMousePosition.z = 0;

        Debug.Log("Começou: " + startMousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        currentMousePosition.z = 0;

        Debug.Log("Arrastando: " + currentMousePosition);
    }

    private void OnMouseUp()
    {
        Debug.Log("Soltou");
    }
}