using UnityEngine;

public class FieldLineResetZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("BallTag"))
            return;

        GameManager.Instance.ResetLevel();
    }
}