using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;

    void Update()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = moveVec * MovementSpeed * Time.deltaTime;

        if (moveVec != Vector3.zero) 
        transform.position += moveVec;
    }

}
