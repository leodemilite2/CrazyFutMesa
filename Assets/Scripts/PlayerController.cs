using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameConfig config;
    private Rigidbody2D rb;
    private LineRenderer aimLine;

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

        aimLine = GetComponentInChildren<LineRenderer>();

        aimLine.positionCount = 2;
        aimLine.enabled = false;
    }

    private void OnMouseDown()
    {
        dragging = true;

        dragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        aimLine.enabled = true;
    }

    private void OnMouseUp()
    {
        if (!dragging)
            return;

        dragEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = dragStart - dragEnd;

        // Limita a força máxima
        if (direction.magnitude > config.maxDragDistance)
        {
            direction = direction.normalized * config.maxDragDistance;
        }

        rb.AddForce(direction * config.launchForce, ForceMode2D.Impulse);

	GameManager.Instance.RegisterShot();

        dragging = false;
        aimLine.enabled = false;
    }

    private void Update()
    {
        if (!dragging)
            return;

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;

        Vector3 localMouse = transform.InverseTransformPoint(mouse);

        // Linha aponta para o lado oposto ao arrasto
        Vector3 direction = -localMouse;

        // Limita o tamanho da linha
        if (direction.magnitude > config.maxDragDistance)
        {
            direction = direction.normalized * config.maxDragDistance;
        }

        // Calcula a potência (0 a 1)
        float power = direction.magnitude / config.maxDragDistance;

        // Cor dinâmica
        Color lineColor;

        if (power < 0.33f)
            lineColor = Color.green;
        else if (power < 0.66f)
            lineColor = Color.yellow;
        else
            lineColor = Color.red;

        aimLine.startColor = lineColor;
        aimLine.endColor = lineColor;

        // Espessura dinâmica
        float width = Mathf.Lerp(0.05f, 0.15f, power);

        aimLine.startWidth = width;
        aimLine.endWidth = width;

        // Atualiza a linha
        aimLine.SetPosition(0, Vector3.zero);
        aimLine.SetPosition(1, direction);
    }


}