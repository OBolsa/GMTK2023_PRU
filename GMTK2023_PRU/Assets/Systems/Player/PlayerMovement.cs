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

        if (rb.velocity.magnitude > 0.1f)
        {
            DoPlayerRotation();

            playerRenderer.flipY = rb.velocity.x < 0;
        }
    }

    private void DoPlayerMovement()
    {
        inputVelocity.x = Input.GetAxisRaw("Horizontal");
        inputVelocity.y = Input.GetAxisRaw("Vertical");

        Vector2 currentSpeed = rb.velocity;
        Vector2 newSpeed = rb.velocity + ((inputVelocity * movementConfigs.impulseSpeed) * Time.deltaTime);

        if (newSpeed.magnitude > movementConfigs.maxMovementSpeed) newSpeed = newSpeed.normalized * movementConfigs.maxMovementSpeed;

        rb.velocity = newSpeed;
    }

    private void DoPlayerRotation()
    {
        Vector2 direction = rb.velocity.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        targetRotation *= Quaternion.Euler(0f, 0f, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, movementConfigs.rotationSpeed);
    }
}