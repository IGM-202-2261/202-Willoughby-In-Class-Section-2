using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] private float maxSelectDistance = 5.0f;
    [SerializeField] private LayerMask interactableLayerMask;

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            RaycastHit hit;
            bool hitAnObject = Physics.Raycast(
                transform.position,
                transform.forward,
                out hit,
                maxSelectDistance,
                interactableLayerMask);

            if(hitAnObject)
            {
                Material hitMat = hit.collider.gameObject.GetComponent<Renderer>().material;
                hitMat.color = Random.ColorHSV();
            }
        }
    }
}
