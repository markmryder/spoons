using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D body;
    public Animator animator;
    Vector2 movement;


    public BoxCollider2D bCol2d;


    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        Vector3 scale = transform.localScale;
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
        if 
            (
            CheckGround(body.position + (movement * MoveSpeed * Time.fixedDeltaTime)) &&
            CheckLeft(body.position + (movement * MoveSpeed * Time.fixedDeltaTime)) &&
            CheckRight(body.position + (movement * MoveSpeed * Time.fixedDeltaTime)) &&
            CheckUp(body.position + (movement * MoveSpeed * Time.fixedDeltaTime))
            )
		{
            
            body.MovePosition(body.position + (movement * MoveSpeed * Time.fixedDeltaTime));
        }
        
	}

	private bool CheckLeft(Vector2 position)
	{
        float laserLength = 0.025f;
        position = position - new Vector2(bCol2d.bounds.extents.x - 0.05f, 0);

        int layerMask = LayerMask.GetMask("Grass");
        //Check if the laser hit something
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.left, laserLength, layerMask);
        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        //If the object is not nullw
        if (hit.collider != null)
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.green;
        }
        else
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
        }
        //Draw the ray for debug purpose
        Debug.DrawRay(position, Vector2.left * laserLength, rayColor);
        //If the ray hits the floor return true, false otherwise
        return hit.collider != null;
    }
    private bool CheckRight(Vector2 position)
    {
        float laserLength = 0.025f;
        position = position + new Vector2(bCol2d.bounds.extents.x + 0.05f, 0);

        int layerMask = LayerMask.GetMask("Grass");
        //Check if the laser hit something
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.right, laserLength, layerMask);
        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        //If the object is not nullw
        if (hit.collider != null)
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.green;
        }
        else
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
        }
        //Draw the ray for debug purpose
        Debug.DrawRay(position, Vector2.right * laserLength, rayColor);
        //If the ray hits the floor return true, false otherwise
        return hit.collider != null;
    }
    private bool CheckGround(Vector2 position)
    {
        float laserLength = 0.25f;
        //Start point of the laser
        position = position - new Vector2(0, (bCol2d.bounds.extents.y + 0.75f));
        //Hit only the objects of Floor layer
        int layerMask = LayerMask.GetMask("Grass");
        //Check if the laser hit something
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, laserLength, layerMask);
        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        //If the object is not null
        if (hit.collider != null)
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.green;
        }
        else
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
        }
        //Draw the ray for debug purpose
        Debug.DrawRay(position, Vector2.down * laserLength, rayColor);
        //If the ray hits the floor return true, false otherwise
        return hit.collider != null;
    }
    private bool CheckGround()
	{
        float laserLength = 0.25f;
        //Start point of the laser
        Vector2 startPosition = (Vector2)transform.position - new Vector2(0, (bCol2d.bounds.extents.y + 0.75f));
        //Hit only the objects of Floor layer
        int layerMask = LayerMask.GetMask("Grass");
        //Check if the laser hit something
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.down, laserLength, layerMask);
        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        //If the object is not null
        if (hit.collider != null)
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.green;
        }
        else
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
        }
        //Draw the ray for debug purpose
        Debug.DrawRay(startPosition, Vector2.down * laserLength, rayColor);
        //If the ray hits the floor return true, false otherwise
        return hit.collider != null;
    }
    private bool CheckUp(Vector2 position)
    {
        float laserLength = 0.025f;
        //Start point of the laser
        position = position + new Vector2(0, (bCol2d.bounds.extents.y + 0.05f));
        //Hit only the objects of Floor layer
        int layerMask = LayerMask.GetMask("Grass");
        //Check if the laser hit something
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.up, laserLength, layerMask);
        //The color of the ray for debug purpose
        Color rayColor = Color.red;
        //If the object is not null
        if (hit.collider != null)
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.green;
        }
        else
        {
            //Change the color of the ray for debug purpose
            rayColor = Color.red;
        }
        //Draw the ray for debug purpose
        Debug.DrawRay(position, Vector2.up * laserLength, rayColor);
        //If the ray hits the floor return true, false otherwise
        return hit.collider != null;
    }


}
