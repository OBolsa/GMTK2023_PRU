using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer playerRenderer;
    public PlayerMovementConfigs movementConfigs;
    Vector2 inputVelocity = new Vector2();

    private void Update()
    {
        DoPlayerMovement();

        if(rb.velocity.magnitude > 0.1f)
            playerRenderer.flipX = rb.velocity.x < 0;

        if (inputVelocity.magnitude > 0.1f)
        {
            DoPlayerRotation();
        }
        else
        {
            DoPlayerTurnBackToRotation();
        }
    }

    private void DoPlayerTurnBackToRotation()
    {
        Vector2 direction = Vector2.right;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, movementConfigs.rotationSpeed * 0.2f * Time.deltaTime);
    }

    private void DoPlayerMovement()
    {
        inputVelocity.x = Input.GetAxisRaw("Horizontal");
        inputVelocity.y = Input.GetAxisRaw("Vertical");

        rb.velocity = Vector2.ClampMagnitude(rb.velocity + movementConfigs.impulseSpeed * Time.deltaTime * inputVelocity, movementConfigs.maxMovementSpeed);
    }

    private void DoPlayerRotation()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        targetRotation *= Quaternion.Euler(0f, 0f, -90f);
        
            transform.rotation = targetRotation;
    }
}