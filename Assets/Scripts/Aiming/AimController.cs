using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AimController : MonoBehaviour
{
    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
        line.enabled = false;
    }

    public void Show(Vector2 start, Vector2 end)
    {
        line.enabled = true;

        line.SetPosition(0, start);
        line.SetPosition(1, end);
    }

    public void Hide()
    {
        line.enabled = false;
    }
}