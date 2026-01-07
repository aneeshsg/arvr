using UnityEngine;

public class Raycast2DSimple : MonoBehaviour
{
    public float rayDistance = 5f;

    private Collider2D lastHit = null;
    private SpriteRenderer lastRenderer = null;
    private Color lastOriginalColor;

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0f;

        Vector2 origin = transform.position;
        Vector2 direction = (mouseWorld - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance);

        if (hit.collider != null)
        {
            if (hit.collider != lastHit)
            {
                // Reset previous hit color
                ResetLastHitColor();

                // Store new hit
                lastHit = hit.collider;
                lastRenderer = hit.collider.GetComponent<SpriteRenderer>();

                if (lastRenderer != null)
                {
                    lastOriginalColor = lastRenderer.color;
                    lastRenderer.color = Color.red; // change color on hit
                }

                Debug.Log("Hit: " + hit.collider.name);
            }
        }
        else
        {
            // No hit → reset color
            ResetLastHitColor();
        }

        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }

    void ResetLastHitColor()
    {
        if (lastRenderer != null)
        {
            lastRenderer.color = lastOriginalColor;
        }

        lastHit = null;
        lastRenderer = null;
    }
}
