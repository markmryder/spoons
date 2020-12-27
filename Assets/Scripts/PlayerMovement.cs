using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D body;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        Vector3 scale = transform.localScale;
        //scale.x = movement.x;
        if(movement.x < 0)
		{
            scale.x = -1;
		}
		else
		{
            scale.x = 1;
		}
        transform.localScale = scale;

    }

	void FixedUpdate()
	{
        body.MovePosition(body.position + (movement * MoveSpeed * Time.fixedDeltaTime));
	}
}
