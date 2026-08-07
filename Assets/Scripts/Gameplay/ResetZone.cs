using UnityEngine;

public class ResetZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PlayerTag") &&
            !other.CompareTag("BallTag"))
            return;

        GameManager.Instance.ResetLevel();
    }
}