using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float Gravity = 21f;	 //downward force
    public float TerminalVelocity = 20f;	//max downward speed
    public float JumpSpeed = 6f;
    public float MoveSpeed = 10f;

    public Texture CursorImage; // image to draw on the screen as the player's crosshair

    public Vector3 MoveVector { get; set; }
    public float VerticalVelocity { get; set; }

    public CharacterController CharacterController;

    public GameObject BulletObject;
    public GameObject GunObject;

    private float shootCooldown = 0.1f;
    private float r_shootCooldown;
    private bool canShoot = true;

    // Use this for initialization
    private void Awake()
    {
		// for some weird reason, attempt to locate and bind a CharacterController that is attached to the player gameobject...
        CharacterController = gameObject.GetComponent("CharacterController") as CharacterController;  // ??????
    }

    private void Start()
    {
        Screen.showCursor = false;
        r_shootCooldown = shootCooldown;
    }

    // Update is called once per frame
    private void Update()
    {
        checkMovement();
        HandleActionInput();
        processMovement();
        rotateGun();
    }

    private void checkMovement()
    {
        //move l/r
        var deadZone = 0.1f;
        VerticalVelocity = MoveVector.y;
        MoveVector = Vector3.zero;
        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            MoveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        //jump

    }


    private void rotateGun()
    {
        RaycastHit hit;
        // use raycasting to place mouse coordinates onto a plane in the level, get position of ray hit. 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
        // LAYER CHANGED, ray "target" now at layer 10 !!!!!
        
        int layerMask = 1 << 10; // this mask sets the raycast to ignore all the layers except layer 10 (which is used by the aimcube attached to the player)
        
        
        if (Physics.Raycast(ray, out hit, 50000f, layerMask))  // out, pass as a ref
        {
            if (hit.collider.gameObject.tag == "Aim")
            {
				Vector3 lookAtVector = new Vector3(hit.point.x, hit.point.y, transform.position.z);
                // Rotate gun to look at position
                GunObject.transform.LookAt(lookAtVector);
            }
        }
    }

    private void HandleActionInput()
    {
		// jump if player pressed the jump button
        if (Input.GetButton("Jump"))
        {
            jump();
        }
		
		// player pressed Left MouseButton
        if (Input.GetMouseButton(0))
        {
			// if can shoot, shoot a bullet
            if (canShoot)
            {
				//RaycastHit hit;
                canShoot = false;
                //Instantiate(BulletObject, GunObject.transform.position, GunObject.transform.rotation);

				//GameObject bullet = 
                    
                //Instantiate(BulletObject, GunObject.transform.position, GunObject.transform.rotation) as GameObject;
                Instantiate(BulletObject, GunObject.transform.position, GunObject.transform.rotation);
            }
        }
		
		// if can't shoot, reduce cooldown of gun until zero
        if (!canShoot)
        {
            r_shootCooldown -= Time.deltaTime;
            if (r_shootCooldown <= 0)
            {
				// can shoot again, reselt cooldown
                canShoot = true;
                r_shootCooldown = shootCooldown;
            }
        }
    }

    private void processMovement() // from some script on the internets :D -Mikko
    {
        //transform moveVector into world-space relative to character rotation
        MoveVector = transform.TransformDirection(MoveVector);

        //normalize moveVector if magnitude > 1
        if (MoveVector.magnitude > 1)
        {
            MoveVector = Vector3.Normalize(MoveVector);
        }

        //multiply moveVector by moveSpeed
        MoveVector *= MoveSpeed;

        //reapply vertical velocity to moveVector.y
        MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);

        //apply gravity
        applyGravity();

        //move character in world-space
        CharacterController.Move(MoveVector * Time.deltaTime);
    }

    private void applyGravity() // some simple gravity, from the internets :D -Mikko
    {
        if (MoveVector.y > -TerminalVelocity)
        {
            MoveVector = new Vector3(MoveVector.x, (MoveVector.y - Gravity * Time.deltaTime), MoveVector.z);
        }
        if (CharacterController.isGrounded && MoveVector.y < -1)
        {
            MoveVector = new Vector3(MoveVector.x, (-1), MoveVector.z);
        }
    }

    public void jump()
    {
        if (CharacterController.isGrounded)
        {
            VerticalVelocity = JumpSpeed;
        }
    }

    private void OnGUI()
    {
        // draw cursor graphic at mouse cursor using gui texture
        Rect cursorPos = new Rect(Input.mousePosition.x - 16, Screen.height - Input.mousePosition.y - 16, 32, 32);
        GUI.DrawTexture(cursorPos, CursorImage);
    }
}