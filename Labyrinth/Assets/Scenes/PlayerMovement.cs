using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;             //Floating point variable to store the player's movement speed.
    public Vector2 MoveVel;
    private Rigidbody2D Rb;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public Animator Animator;
    public Animator ShoulderAnimator;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxisRaw("Vertical");
        Animator.SetFloat("Walking", Mathf.Abs(moveVertical)+ Mathf.Abs(moveHorizontal));
        //ShoulderAnimator.SetFloat("Walking", Mathf.Abs(moveVertical) + Mathf.Abs(moveHorizontal));
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 MoveInput = new Vector2(moveHorizontal, moveVertical);
        MoveVel = MoveInput.normalized * Speed;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;
 
        Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
 
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Rb.MovePosition(MoveVel * Speed);
        Rb.MovePosition(Rb.position + MoveVel * Time.fixedDeltaTime);
        //Debug.Log(MoveVel);
    }
}