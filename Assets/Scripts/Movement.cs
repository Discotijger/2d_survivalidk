using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D RB2;
    [SerializeField] int Speed = 5;
    private Vector2 movement;


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        RB2.MovePosition(RB2.position + movement * Speed * Time.fixedDeltaTime);
    }


}
