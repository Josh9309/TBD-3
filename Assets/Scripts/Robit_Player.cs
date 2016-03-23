using UnityEngine;
using System.Collections;

public class Robit_Player : MonoBehaviour {

    [System.Serializable] //allows variables to be seen in constructor
    public class MoveSettings
    {
        //movement Variables
        public float moveSpeed = 5.0f;
        public float jumpPower = 2.0f;
        public float distToGrounded = 0.5f; // distance from origin to ground
        private float jumpMax;
        internal bool jumpingUp = false; // tells whether play is still jumping up to max jump height
        public LayerMask ground;

        //properities 
        public float JumpMax
        {
            get { return jumpMax; }
            set
            {
                jumpMax = value;
            }
        }
    }

    [System.Serializable]
    public class PhysSettings
    {
        //physics variables
        public float downGrav = 0.075f;
        public bool grounded;
        public float upGrav = 0.075f;
    }

    [System.Serializable]
    public class InputSettings
    {
        //Input variables
        public float delay = 0.3f;
        public float fwdInput, jumpInput;
        public string JUMP_AXIS = "Jump";
    }

    //class variables
    public MoveSettings move = new MoveSettings();
    public PhysSettings physics = new PhysSettings();
    public InputSettings input = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Vector3 position = Vector3.zero;
    Rigidbody rbody;
    
    //Methods 
    bool isGrounded()
    {
        physics.grounded = Physics.Raycast(transform.position, Vector3.down, move.distToGrounded, move.ground);
        return physics.grounded;
    }

    void GetInput()
    {
        input.fwdInput = Input.GetAxis("Horizontal");
        input.jumpInput = Input.GetAxisRaw(input.JUMP_AXIS);
    }

    // Use this for initialization
    void Start ()
    {
        input.fwdInput = 0;
        //input.jumpInput = 0;

        position = transform.position;
        rbody = GetComponent<Rigidbody>();
        rbody.mass = 1.0f;
        
	}
	
    
	// Update is called once per frame
	void Update ()
    {
        GetInput();

        //get amount of distance to move fowards or backwards
        //float fwd =  input.fwdInput * move.moveSpeed * Time.deltaTime;

        //move robit
        // Run();
        //Jump();

        // this.transform.TransformDirection(velocity);
        

    }

    void FixedUpdate()
    {

        Run();
        Jump();

        rbody.velocity = transform.TransformDirection(velocity);
        position += rbody.velocity;

        this.transform.position = position;
    }

    void Run()
    {
        if(Mathf.Abs(input.fwdInput) > input.delay)
        {
            velocity = -transform.right * input.fwdInput * move.moveSpeed * Time.deltaTime;
           // velocity.x = input.fwdInput * move.moveSpeed;
        }
        else
        {
            velocity = Vector3.zero;
        }
    }

    void Jump()
    {
        if(input.jumpInput > 0 && isGrounded())
        {
            move.JumpMax = transform.position.y + move.jumpPower;
            velocity.y = physics.upGrav;
            move.jumpingUp = true;
        }
        else if(input.jumpInput == 0 && isGrounded())
        {
            velocity.y = 0;
        }
        else
        {
            if (transform.position.y < move.JumpMax && move.jumpingUp) 
            {
                velocity.y += physics.upGrav;
            }
            else if(transform.position.y >= move.JumpMax)
            {
                move.jumpingUp = false;
                velocity.y -= physics.downGrav;
            }
            else
            {
                velocity.y -= physics.downGrav;
            }
            
        }
    }
}
