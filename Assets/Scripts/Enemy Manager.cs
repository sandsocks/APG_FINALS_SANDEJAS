using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform player;
    public float fieldOfView = 45f;
    void Update()
    {
        CheckIfPlayerIsInFront();
        CheckFieldOfView();
    }
    // ---------------------------------------------
    // 1. Check if the player is in front of the object
    // ---------------------------------------------
    void CheckIfPlayerIsInFront()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPlayer);
        if (dot > 0)
        Debug.Log("Player is IN FRONT of this object.");
        else
        Debug.Log("Player is BEHIND this object.");
        Debug.Log(HitFromFront(toPlayer));
    }
    // ---------------------------------------------
    // 2. Field of View (FOV) Detection
    // ---------------------------------------------
    void CheckFieldOfView()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toPlayer);
        float threshold = Mathf.Cos(fieldOfView * Mathf.Deg2Rad);
        if (dot > threshold)
        Debug.Log("Player is INSIDE the field of view.");
        else
        Debug.Log("Player is OUTSIDE the field of view.");
    }
    // ---------------------------------------------
    // 3. Hit direction detection
    // ---------------------------------------------
    public bool HitFromFront(Vector3 hitDirection)
    {
        hitDirection.Normalize();
        float dot = Vector3.Dot(transform.forward, hitDirection);
        return dot > 0;
    }
    // ---------------------------------------------
    // (Bonus) Draw Gizmos for Visualization
    // ---------------------------------------------
    void OnDrawGizmos()
    {
        if (player == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward
        * 3);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, player.position);
        // FOV cone lines
        Gizmos.color = Color.yellow;
        Quaternion leftRot = Quaternion.Euler(0, -fieldOfView, 0);
        Quaternion rightRot = Quaternion.Euler(0, fieldOfView, 0);
        Gizmos.DrawLine(transform.position, transform.position + leftRot *
        transform.forward * 3);
        Gizmos.DrawLine(transform.position, transform.position + rightRot *
        transform.forward * 3);
    }
}
