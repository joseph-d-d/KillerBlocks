using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    //how many times the player can jump
    public int maxJump = 2;
    public int jumpcount = 2;

    private Vector3 moveDirection = Vector3.zero;

    Vector3 temp;
    float tempX;
    float tempY;

    void Update()
    {
        Transform transform = GetComponent<Transform>();

        //reset the rotation to 0s
        transform.rotation = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        //reset the z-axis to 0s
        tempX = transform.position.x;
        tempY = transform.position.y;
        temp = giveZeroZ(tempX, tempY);
        transform.position = temp;

        CharacterController controller = GetComponent<CharacterController>();
        float move = Input.GetAxis("Horizontal");

        if (controller.isGrounded)
        {
            jumpcount = maxJump;
            moveDirection = new Vector3(move, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        else
        {
            move *= 5;
            moveDirection.x = move;
        }

        if (Input.GetButton("Jump") && jumpcount != 0)
        {
            moveDirection.y = jumpSpeed;
            jumpcount--;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.collisionFlags == CollisionFlags.CollidedBelow)
            Destroy(gameObject);

    }

    Vector3 giveZeroZ(float fX, float fY)
    {
        Vector3 t = new Vector3(fX, fY, 0f);
        return t;
    }
}