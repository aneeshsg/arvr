using UnityEngine;

public class Raycast2DSimple : MonoBehaviour
{
    public float rayDistance = 5f; // how far the ray checks
    private Collider2D lastHit = null; // remember the last collider hit

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;
        Vector2 origin = transform.position;
        Vector2 direction = (mouseWorld - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance);

        if (hit.collider != null)
        {
            // Only log if the hit object changed
            if (hit.collider != lastHit)
            {
                Debug.Log("Hit: " + hit.collider.name);
                lastHit = hit.collider;
            }
        }
        else
        {
            // Clear log when no object is hit
            if (lastHit != null)
            {
                Debug.Log("No Hit");
                lastHit = null;
            }
        }

        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }
}
