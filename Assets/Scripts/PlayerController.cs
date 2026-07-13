using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 dragStart;
    private Vector2 dragEnd;

    [SerializeField]
    private float launchForce = 5f;

    private bool dragging = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        dragging = true;
        dragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void OnMouseUp()
    {
        if (!dragging) return;

        dragEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = dragStart - dragEnd;

        rb.AddForce(direction * launchForce, ForceMode2D.Impulse);

        dragging = false;
    }
}