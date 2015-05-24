/*
using UnityEngine;
using System.Collections;

public class PlayerControllerBoxman : MonoBehaviour
{

     Rigidbody PlayerRigid;
     public int JumpPower;
     public float Speed;
     public Animator anim;
     Vector3 prevPos;
     bool PlayerHasTurnedRight;
     bool PlayerHasturnedLeft;
     // Use this for initialization
     void Start()
     {
          PlayerRigid = GetComponent<Rigidbody>();
          anim = GetComponent<Animator>();
          PlayerHasTurnedRight = true;
          PlayerHasturnedLeft = true;
     }

     // Update is called once per frame
     void Update()
     {
          Movement();
     }

     public void Movement()
     {
          if (Input.GetButton("right"))
          {

               anim.SetBool("Running", true);
               transform.position += -transform.right * Speed;

               if(PlayerHasturnedLeft == true)
               {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    PlayerHasTurnedRight = true;
                    PlayerHasturnedLeft = false;
               }
          }
          if (Input.GetButton("left"))
          {

               anim.SetBool("Running", true);
               transform.position += -transform.right * Speed;

               if (PlayerHasTurnedRight == true)
               {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    PlayerHasTurnedRight = false;
                    PlayerHasturnedLeft = true;
               }
          }
          if (Input.GetButtonDown("Jump"))
          {
               PlayerRigid.AddForce(0, JumpPower, 0);

          }
          anim.SetBool("Running", false);
     }
     
}
*/
using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerControllerBoxman : MonoBehaviour
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

    bool PlayerHasTurnedRight;
    bool PlayerHasturnedLeft;
    public Animator anim;

    CharacterController controller;

    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerHasTurnedRight = true;
        PlayerHasturnedLeft = true;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Transform transform = GetComponent<Transform>();
        controller = GetComponent<CharacterController>();
        //reset the rotation to 0s
        //transform.rotation = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f));
        //reset the z-axis to 0s
        tempX = transform.position.x;
        tempY = transform.position.y;
        temp = giveZeroZ(tempX, tempY);
        transform.position = temp;

        float move = Input.GetAxis("Horizontal");

        if (Input.GetButton("right"))
        {
            anim.SetBool("Running", true);
            transform.position += -transform.right * speed;

            if (PlayerHasturnedLeft == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                PlayerHasTurnedRight = true;
                PlayerHasturnedLeft = false;
            }
        }
        else if (Input.GetButton("left"))
        {
            anim.SetBool("Running", true);
            transform.position += -transform.right * speed;
            
            if (PlayerHasTurnedRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                PlayerHasTurnedRight = false;
                PlayerHasturnedLeft = true;
            }
        }

        if (Input.GetButton("Jump") && jumpcount != 0)
        {
            GetComponent<AudioSource>().Play();
            moveDirection.y = jumpSpeed;
            jumpcount--;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        anim.SetBool("Running", false);

        if (controller.isGrounded)
        {
            jumpcount = maxJump;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (controller.collisionFlags == CollisionFlags.CollidedBelow)
        {
             GetComponent<AudioSource>().Play();
             //Destroy(gameObject);
        }
             
    }

    Vector3 giveZeroZ(float fX, float fY)
    {
        Vector3 t = new Vector3(fX, fY, 0f);
        return t;
    }

}
