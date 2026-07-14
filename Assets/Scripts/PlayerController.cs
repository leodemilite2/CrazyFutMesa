using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameConfig config;
    private Rigidbody2D rb;

    private Vector2 dragStart;
    private Vector2 dragEnd;

    private bool dragging = false;

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();

    config = Resources.Load<GameConfig>("GameConfig");

    if (config == null)
    {
        Debug.LogError("GameConfig não encontrado!");
        return;
    }


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

      	rb.AddForce(direction * config.launchForce, ForceMode2D.Impulse);

        dragging = false;
    }
}