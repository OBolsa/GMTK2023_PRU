using UnityEngine;

public class Floater : DynamicItem, IInteractable
{
    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public FishingSpotArea areaRelated;

    [Header("Configs")]
    public string floaterName = "Floater";
    public Sprite defaultSprite;
    public Sprite mountedSprite;
    public float speed = 20;
    public float maxSpeed = 4;
    public bool isMounted;
    public bool canMove;

    private Vector2 inputVelocity;

    private void Start()
    {
        toolTip.itemText.text = floaterName;
        areaRelated.myFloater = this;
    }

    public void DoInteraction()
    {
        AttatchToTheFloater();
    }

    public void StartFloater()
    {
        canMove = true;
    }

    public void StopFloater()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
    }

    public void AttatchToTheFloater()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        player.transform.parent = transform;
        player.gameObject.SetActive(false);
        isMounted = true;

        toolTip.CloseToolTip();
        toolTip.enabled = false;
        toolTip.canShowTooltip = false;

        spriteRenderer.sprite = mountedSprite;

        areaRelated.gameObject.SetActive(true);

        FollowPoint.Instance.SetTarget(transform);
        FollowPoint.Instance.StartFollow();

        StartFloater();
    }

    public void DetachToTheFLoater()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>(true);
        player.transform.parent = null;
        player.gameObject.SetActive(true);
        isMounted = false;

        toolTip.CloseToolTip();
        toolTip.enabled = true;
        toolTip.canShowTooltip = true;
        spriteRenderer.sprite = defaultSprite;

        areaRelated.gameObject.SetActive(false);

        FollowPoint.Instance.SetTarget(player.transform);
        FollowPoint.Instance.StartFollow();
    }

    private void Update()
    {
        if (isMounted)
        {
            if(canMove)
                inputVelocity.x = Input.GetAxisRaw("Horizontal");

            rb.velocity = Vector2.ClampMagnitude(rb.velocity + speed * Time.deltaTime * inputVelocity, maxSpeed);

            spriteRenderer.flipX = rb.velocity.x < 0;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                DetachToTheFLoater();
            }
        }
    }
}