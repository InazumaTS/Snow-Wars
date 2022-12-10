using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondmovement : MonoBehaviour
{
    private float moveHorizontalInput;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;
    [SerializeField]
    private float velPower;
    [SerializeField]
    private float frictionAmount;
    [SerializeField]
    private float jumpForce;
    Rigidbody rb;
    [SerializeField]
    private float fallGravityMultiplier;
    [SerializeField]
    private float JumpcutMultiplier;
    [SerializeField]
    private GameObject snowBallPrefab;
    private float canFire = -1;
    [SerializeField]
    private float fireCoolDown = 0.5f;

    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] collidedObjects = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, 3);
        if (collidedObjects.Length > 0)
        {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontalInput = Input.GetAxis("LeftRight");

        float targetSpeed = moveSpeed * moveHorizontalInput;

        float speedDif = targetSpeed - rb.velocity.x;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

        rb.AddForce(movement * Vector2.right);

        if (moveHorizontalInput == 0)
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode.Impulse);
        }
        if (isGrounded && Input.GetKey(KeyCode.O))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
        }
        if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.O))
        {
            rb.AddForce(Vector2.down * rb.velocity.y * (1 - JumpcutMultiplier), ForceMode.Impulse);
        }
        if (rb.velocity.y < 0)
            rb.AddForce(Vector2.down * 9.8f * fallGravityMultiplier);

        if (Input.GetKey(KeyCode.P) && Time.time > canFire)
        {
            canFire = Time.time + fireCoolDown;
            Instantiate(snowBallPrefab, transform.position + new Vector3(-0.5f, 0.0f,0.0f), Quaternion.identity);
        }
    }

    public void startDeath()
    {
        Destroy(this.gameObject);
    }
}
