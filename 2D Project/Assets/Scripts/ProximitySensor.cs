using UnityEngine;

public class ProximitySensor : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private CircleCollider2D col;
    private Color gizmoColor = Color.white;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gizmoColor = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gizmoColor = Color.white;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, col.radius);
    }
#endif
}
