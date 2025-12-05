using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] public float skinWidth = 0.05f;
    [SerializeField] GameObject player;
    [SerializeField] float distances;
    [SerializeField] LayerMask layerMask;
    [SerializeField] public float radius;
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //player.transform.position += moveVec * MovementSpeed * Time.deltaTime;
        Vector3 move = moveVec * MovementSpeed * Time.deltaTime;

        if (moveVec != Vector3.zero)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, moveVec, out hit, move.magnitude + skinWidth))
            {
                float distanceToWall = hit.distance - skinWidth;
                transform.position += moveVec * Mathf.Max(0, distanceToWall);
            }
            else
            {
                transform.position += move;
            }
        }
    }
}
