
#region Namespaces
using UnityEngine;
using System.Collections;
using System;

#endregion

#region Metodi luokka

[Serializable]
public class ViiveLuokka
{
	// Overloaded function
    public void DoTimedUpdate()
    {
        Shooter.Intervals++;	// GET + SET invocation... Get return 0 because <0, then ++it through Set invovation
        Debug.Log ("Inputs : ");
        Debug.Log("Bling, bling    "+Shooter.Intervals);

    }

    public bool DoTimedUpdate(float value1,float value2)
    {
        Shooter.Intervals++;
        //Debug.Log ("Inputs : "+value1+" , "+value2+"\n");
        //Debug.Log("Bling, bling    "+Shooter.Intervals);

        return true;
    }
	
	
    public void Method1(string message) { }
    public void Method2(string message) { }
}

#endregion

public class Shooter : MonoBehaviour
{
	
	#region Varibles
	
	private Vector2 touchi = Vector2.zero;
    public Rigidbody bullet;
	
	public Rigidbody droidi;
	
    private float power = 1000f;
    private float moveSpeed = 30f;
	
	public Texture crossHair; // image to draw on the screen as the player's crosshair

    // Timers
    protected float accumulator = 0f;
    protected float waitTime = 1.0f;
	
	private float bulletLifeSpan=10f;
	
	private bool canShoot=true;
    private bool canShoot2 = true;
    private bool canShoot3 = true;
    private bool canShoot4 = true;

	private float r_shootCooldown = 0.1f;
    private float shootCooldown = 0.1f;

    private float r_shootCooldown2 = 0.1f;
    private float shootCooldown2 = 0.1f;

    private float r_shootCooldown3 = 0.1f;
    private float shootCooldown3 = 0.1f;

    private float r_shootCooldown4 = 0.1f;
    private float shootCooldown4 = 0.1f;

    public Camera playerCamera;
	
	private float currentWidth;
    private float currentHeight;
	
	private Rect startRect; 
    private Rect targetRect; 
	
	//private Color color = Color.white; 
    //private string sFPS = ""; // The fps formatted into a string.
    private GUIStyle style;
	
	
	private bool allowDrag = true;
	
	private Vector3 uusPositio = Vector3.zero;
	private Vector3 p = Vector3.zero;
	
    private Vector3 uusPositio2 = Vector3.zero;
	private Vector3 p2 = Vector3.zero;

    private Vector3 uusPositio3 = Vector3.zero;
    private Vector3 p3 = Vector3.zero;

    private Vector3 uusPositio4 = Vector3.zero;
    private Vector3 p4 = Vector3.zero;


    private int kosketuksia = 0;
	
	private static int intervals=-100;   // the name field
	
    public static int Intervals   // the Name property
	{
   		get 
   		{
			// if below zero check
      		return intervals >= 0 ? intervals : 0; 
   		}
		
		set
		{
			intervals=value;
		}
	}
	
	
	
	private ViiveLuokka obj = new ViiveLuokka();


    #region Delegates
    public delegate void Delegaatio(string message);

    // Instantiate the delegate.
    Delegaatio handler = DelegateMethod;

    // Create a method for a delegate.
    public static void DelegateMethod(string message)
    {
        Debug.Log (message);
    }

    public static void MethodWithCallback(int param1, int param2, Delegaatio callback)
    {
        callback("The number is: " + (param1 + param2).ToString());
    }


    #endregion
	
	
	
	#endregion
	
    public void Start()
    {
        Delegaatio d3 = DelegateMethod;

		//Intervals=0;
        // Call the delegate methods
        handler += d3;
        handler("Hello World");
        MethodWithCallback(1, 2, handler);  
		
		currentWidth = Screen.width/3.5F;
        currentHeight = Screen.height/4F;

        startRect = new Rect(10, 500, currentWidth+80, currentHeight+80); 
    }

    public void Update()
    {

        // Local variables -->
		
		// Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1

		
        float h = Input.GetAxis("Horizontal") * moveSpeed;
            
		float translationH = h * Time.deltaTime; // Make it move 10 meters per second instead of 10 meters per frame...

        // (The time in seconds it took to complete the last frame (Read Only)) (0.02?)
        
		float v = Input.GetAxis("Vertical") * moveSpeed;
           
		float translationV = v * Time.deltaTime; // Make it move 10 meters per second instead of 10 meters per frame...
		
		// Move (inverted) !
		//GameObject.Find("Main Camera").GetComponent<Transform>().Translate(translationH/**=-1*/,translationV/**=-1*/,0);    
		
		// Check if fired
		//if(Input.GetButtonUp("Fire1") || Input.GetButtonUp("Fire2") || Input.GetButtonUp("Fire3"))
		
		Vector3 dir = Vector3.zero;
		
		
        dir.x = Input.acceleration.x;
        dir.y = -Input.acceleration.y-0.5f;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();
        
        dir *= Time.deltaTime;
			
		// Actual movement implementation
		transform.Translate(dir * moveSpeed);		

        #region MoveBoundaries
        
        if(transform.position.y<=3f)
			SetTransformY(3.0f);		
		
		if(transform.position.y>=10f)
			SetTransformY(10.0f);
		
		if(transform.position.x>=14f)
			SetTransformX(14.0f);

		if(transform.position.x<=-5f)
			SetTransformX(-5.0f);

        #endregion


        #region ShootingTimeCoolers

        if (!canShoot)
        {
            r_shootCooldown -= Time.deltaTime;
            if (r_shootCooldown <= 0)
            {
				// Can shoot again, reset cooldown
                canShoot = true;
                r_shootCooldown = shootCooldown;
            }
        }

        if (!canShoot2)
        {
            r_shootCooldown2 -= Time.deltaTime;
            if (r_shootCooldown2 <= 0)
            {
				// Can shoot again, reset cooldown
                canShoot2 = true;
                r_shootCooldown2 = shootCooldown2;
            }
        }

        if (!canShoot3)
        {
            r_shootCooldown3 -= Time.deltaTime;
            if (r_shootCooldown3 <= 0)
            {
                // Can shoot again, reset cooldown
                canShoot3 = true;
                r_shootCooldown3 = shootCooldown3;
            }
        }

        if (!canShoot4)
        {
            r_shootCooldown4 -= Time.deltaTime;
            if (r_shootCooldown4 <= 0)
            {
                // Can shoot again, reset cooldown
                canShoot4 = true;
                r_shootCooldown4 = shootCooldown4;
            }
        }

        #endregion

        kosketuksia = Input.touchCount;
		if (Input.touchCount > 0)
        {
           
            #region Sormi2
            if (Input.touchCount >= 2 && canShoot2)
            {
                // Sormi kaksi
                Vector2 j = Input.GetTouch(1).position;
                canShoot2 = false;

                uusPositio2.x = j.x;
                uusPositio2.y = j.y;

                uusPositio2.z = 10f;

                p2 = playerCamera.ScreenToWorldPoint(uusPositio2);

                Rigidbody instance2 = Instantiate(droidi, p2, transform.rotation) as Rigidbody;

                instance2.transform.Rotate(-90, -180, 0);
                Vector3 fwd2 = transform.TransformDirection(Vector3.forward);
                instance2.AddForce(fwd2 * power);
                GetComponent<AudioSource>().Play();

                Destroy(instance2.gameObject, bulletLifeSpan);
            }

            #endregion

            #region Sormi3
            if (Input.touchCount >= 3 && canShoot3)
            {
                // Sormi kaksi
                Vector2 k = Input.GetTouch(2).position;
                canShoot3 = false;

                uusPositio3.x = k.x;
                uusPositio3.y = k.y;

                uusPositio3.z = 10f;

                p3 = playerCamera.ScreenToWorldPoint(uusPositio3);

                Rigidbody instance3 = Instantiate(droidi, p3, transform.rotation) as Rigidbody;

                instance3.transform.Rotate(-90, -180, 0);
                Vector3 fwd3 = transform.TransformDirection(Vector3.forward);
                instance3.AddForce(fwd3 * power);
                GetComponent<AudioSource>().Play();

                Destroy(instance3.gameObject, bulletLifeSpan);
            }

            #endregion

            #region Sormi4
            if (Input.touchCount >= 4 && canShoot4)
            {
                // Sormi kaksi
                Vector2 l = Input.GetTouch(3).position;
                canShoot4 = false;

                uusPositio4.x = l.x;
                uusPositio4.y = l.y;

                uusPositio4.z = 10f;

                p4 = playerCamera.ScreenToWorldPoint(uusPositio4);

                Rigidbody instance4 = Instantiate(droidi, p4, transform.rotation) as Rigidbody;

                instance4.transform.Rotate(-90, -180, 0);
                Vector3 fwd4 = transform.TransformDirection(Vector3.forward);
                instance4.AddForce(fwd4 * power);
                GetComponent<AudioSource>().Play();

                Destroy(instance4.gameObject, bulletLifeSpan);
            }

            #endregion

            #region Sormi1

            if (Input.touchCount >= 1 && canShoot)
            {

                Vector2 i = Input.GetTouch(0).position;

                // Start cool down period
                canShoot = false;

                touchi.x = Input.GetTouch(Input.touchCount - 1).position.x;
                touchi.y = Input.GetTouch(Input.touchCount - 1).position.y;




                // Rigidbody instance = Instantiate(bullet,transform.position,transform.rotation) as Rigidbody;
                // Vector3 rotaatio=new Vector3(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y-180f,transform.rotation.eulerAngles.z);


                uusPositio.x = i.x;
                uusPositio.y = i.y;


                //p = transform.TransformDirection( uusPositio );

                // Touch Z always 0 so it must be defined !! Otherwise you get camera origin all the time
                // Vector originates from main camera

                uusPositio.z = 10f;

                p = playerCamera.ScreenToWorldPoint(uusPositio);

                Rigidbody instance = Instantiate(droidi, p, transform.rotation) as Rigidbody;
                GetComponent<AudioSource>().Play();

                instance.transform.Rotate(-90, -180, 0);
                Vector3 fwd = transform.TransformDirection(Vector3.forward);
                instance.AddForce(fwd * power);

                Destroy(instance.gameObject, bulletLifeSpan);
            }

            #endregion
        }	
		
		
        // Execute once per second
        accumulator += Time.deltaTime;
 
        if (accumulator >= waitTime)
        {
            //accumulator -= waitTime;
            accumulator = 0; //reset
			obj.DoTimedUpdate(translationH,translationV);

        }
		
		// Transform Inherits from Component, IEnumerable
		// They also support enumerators so you can loop through children using: 
		//         foreach (Transform child in transform) 
		//{
        //    child.position += Vector3.up * 10.0F;
        //}  
    }
	
	public void OnGUI()
    {
        /*
		int i = 0;
        int j = 0;
		
		Vector3 positio = transform.position;
		
		Rect cursorPos = new Rect(Screen.width/2-150,Screen.height/2-150, 300, 300);
     	GUI.DrawTexture(cursorPos, crossHair);
     	*/
		
		
		
		if(Input.touchCount>0)
		{
    		for(int i=0; i<Input.touchCount; i++)
    		{
                // Finger two
                if(Input.touchCount>=2)
                {
                    Rect cursorPos2 = new Rect(Input.GetTouch(1).position.x - 150, Screen.height - Input.GetTouch(1).position.y - 150, 300, 300);
				    GUI.DrawTexture(cursorPos2,crossHair);
                }

                // Finger three
                if (Input.touchCount >= 3)
                {
                    Rect cursorPos3 = new Rect(Input.GetTouch(2).position.x - 150, Screen.height - Input.GetTouch(2).position.y - 150, 300, 300);
                    GUI.DrawTexture(cursorPos3, crossHair);
                }

                // Finger four
                if (Input.touchCount >= 4)
                {
                    Rect cursorPos4 = new Rect(Input.GetTouch(3).position.x - 150, Screen.height - Input.GetTouch(3).position.y - 150, 300, 300);
                    GUI.DrawTexture(cursorPos4, crossHair);
                }

                // Finger one
                if (Input.touchCount >= 1)
                {
                    Rect cursorPos = new Rect(Input.GetTouch(0).position.x - 150, Screen.height - Input.GetTouch(0).position.y - 150, 300, 300);
                    GUI.DrawTexture(cursorPos, crossHair);
                }
    		}
		}
		
		
		// Make GUI box
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.blue;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 30 ;
        }

        // Register the window (window ID must be unique)
        startRect = GUI.Window(1, startRect, DoMyWindow, "");
	}

    void DoMyWindow(int windowID)
    {
        // Debug box content ->
        GUI.Label(new Rect(0, 0, startRect.width, startRect.height), "Orkkis1 : " + uusPositio + "\nKonvertoitu1 : " + p + "\nOrkkis2 : " + uusPositio2 + "\nKonvertoitu2 : " + p2 + "\nOrkkis3 : " + uusPositio3 + "\nKonvertoitu3 : " + p3 +"\nOrkkis4 : " + uusPositio4 + "\nKonvertoitu4 : " + p4 +"\nKosketusten LKM : " + kosketuksia, style);
        if (allowDrag)
        {
            //GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
            // Drag from upper "bar"
            //GUI.DragWindow(new Rect(0, 0, 10000, 20));


            GUI.Button(new Rect(10, 8, 120, 20), "Arvoja");
            // Insert a huge dragging area at the end.
            // This gets clipped to the window (like all other controls) so you can never
            //  drag the window from outside it.
            GUI.DragWindow();
        }
    }

    #region TransformSetters

    void SetTransformY(float n)
	{
		transform.position = new Vector3(transform.position.x, n, transform.position.z);
	}
	
	void SetTransformX(float n)
	{
		transform.position = new Vector3(n, transform.position.y, transform.position.z);
	}

    void SetTransformZ(float n)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, n);
    }

    #endregion
}
























		
		/*
		
		while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
            {
					Rect cursorPos = new Rect(Input.GetTouch(i).position.x - 150, Screen.height - Input.GetTouch(i).position.y - 150, 300, 300);
					GUI.DrawTexture(cursorPos,crossHair);
            }
            ++i;
        }
        */