using UnityEngine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField]public TMP_Text directionText;
    [SerializeField]public float fieldOfView;
    [SerializeField]public float speed;

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
        float rotateSpeed = speed * Time.deltaTime;
        if (dot > 0)
        {
            Debug.Log("Player is IN FRONT of this object.");
            directionText.text = "FRONT";

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, toPlayer, rotateSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        else
        {
            Debug.Log("Player is BEHIND this object.");
            directionText.text = "BEHIND";
        }
        
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
