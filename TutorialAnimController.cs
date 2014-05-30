using UnityEngine;
using System.Collections;
using System;

using Vectrosity; // Drawing


#region drawClasses



public class Drawing2
{
    public static Texture2D lineTex;

    public static void DrawLine(Camera cam, Vector3 pointA, Vector3 pointB) { DrawLine(cam, pointA, pointB, GUI.contentColor, 1.0f); }
    public static void DrawLine(Camera cam, Vector3 pointA, Vector3 pointB, Color color) { DrawLine(cam, pointA, pointB, color, 1.0f); }
    public static void DrawLine(Camera cam, Vector3 pointA, Vector3 pointB, float width) { DrawLine(cam, pointA, pointB, GUI.contentColor, width); }
    public static void DrawLine(Camera cam, Vector3 pointA, Vector3 pointB, Color color, float width)
    {
        Vector2 p1 = Vector2.zero;
        p1.x = cam.WorldToScreenPoint(pointA).x;
        p1.y = cam.WorldToScreenPoint(pointA).y;
        Vector2 p2 = Vector2.zero;
        p2.x = cam.WorldToScreenPoint(pointB).x;
        p2.y = cam.WorldToScreenPoint(pointB).y;
        DrawLine(p1, p2, color, width);
    }

    public static void DrawLine(Rect rect) { DrawLine(rect, GUI.contentColor, 1.0f); }
    public static void DrawLine(Rect rect, Color color) { DrawLine(rect, color, 1.0f); }
    public static void DrawLine(Rect rect, float width) { DrawLine(rect, GUI.contentColor, width); }
    public static void DrawLine(Rect rect, Color color, float width) { DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB) { DrawLine(pointA, pointB, GUI.contentColor, 1.0f); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color) { DrawLine(pointA, pointB, color, 1.0f); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, float width) { DrawLine(pointA, pointB, GUI.contentColor, width); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
    {
        pointA.x = (int)pointA.x; pointA.y = (int)pointA.y;
        pointB.x = (int)pointB.x; pointB.y = (int)pointB.y;

        if (!lineTex) { lineTex = new Texture2D(1, 1); }
        Color savedColor = GUI.color;
        GUI.color = color;

        Matrix4x4 matrixBackup = GUI.matrix;

        float angle = Mathf.Atan2(pointB.y - pointA.y, pointB.x - pointA.x) * 180f / Mathf.PI;
        float length = (pointA - pointB).magnitude;
        GUIUtility.RotateAroundPivot(angle, pointA);
        GUI.DrawTexture(new Rect(pointA.x, pointA.y, length, width), lineTex);

        GUI.matrix = matrixBackup;
        GUI.color = savedColor;
    }
}



public class Drawing
{
    //****************************************************************************************************
    //  static function DrawLine(rect : Rect) : void
    //  static function DrawLine(rect : Rect, color : Color) : void
    //  static function DrawLine(rect : Rect, width : float) : void
    //  static function DrawLine(rect : Rect, color : Color, width : float) : void
    //  static function DrawLine(Vector2 pointA, Vector2 pointB) : void
    //  static function DrawLine(Vector2 pointA, Vector2 pointB, color : Color) : void
    //  static function DrawLine(Vector2 pointA, Vector2 pointB, width : float) : void
    //  static function DrawLine(Vector2 pointA, Vector2 pointB, color : Color, width : float) : void
    //  
    //  Draws a GUI line on the screen.
    //  
    //  DrawLine makes up for the severe lack of 2D line rendering in the Unity runtime GUI system.
    //  This function works by drawing a 1x1 texture filled with a color, which is then scaled
    //   and rotated by altering the GUI matrix.  The matrix is restored afterwards.
    //****************************************************************************************************

    public static Texture2D lineTex;

    public static void DrawLine(Rect rect) { DrawLine(rect, GUI.contentColor, 1.0f); }
    public static void DrawLine(Rect rect, Color color) { DrawLine(rect, color, 1.0f); }
    public static void DrawLine(Rect rect, float width) { DrawLine(rect, GUI.contentColor, width); }
    public static void DrawLine(Rect rect, Color color, float width) { DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB) { DrawLine(pointA, pointB, GUI.contentColor, 1.0f); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color) { DrawLine(pointA, pointB, color, 1.0f); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, float width) { DrawLine(pointA, pointB, GUI.contentColor, width); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
    {
        // Save the current GUI matrix, since we're going to make changes to it.
        Matrix4x4 matrix = GUI.matrix;

        // Generate a single pixel texture if it doesn't exist
        if (!lineTex) { lineTex = new Texture2D(1, 1); }

        // Store current GUI color, so we can switch it back later,
        // and set the GUI color to the color parameter
        Color savedColor = GUI.color;
        GUI.color = color;

        // Determine the angle of the line.
        float angle = Vector3.Angle(pointB - pointA, Vector2.right);

        // Vector3.Angle always returns a positive number.
        // If pointB is above pointA, then angle needs to be negative.
        if (pointA.y > pointB.y) { angle = -angle; }

        // Use ScaleAroundPivot to adjust the size of the line.
        // We could do this when we draw the texture, but by scaling it here we can use
        //  non-integer values for the width and length (such as sub 1 pixel widths).
        // Note that the pivot point is at +.5 from pointA.y, this is so that the width of the line
        //  is centered on the origin at pointA.
        GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));

        // Set the rotation for the line.
        //  The angle was calculated with pointA as the origin.
        GUIUtility.RotateAroundPivot(angle, pointA);

        // Finally, draw the actual line.
        // We're really only drawing a 1x1 texture from pointA.
        // The matrix operations done with ScaleAroundPivot and RotateAroundPivot will make this
        //  render with the proper width, length, and angle.
        GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1, 1), lineTex);

        // We're done.  Restore the GUI matrix and GUI color to whatever they were before.
        GUI.matrix = matrix;
        GUI.color = savedColor;
    }
}

#endregion



public class TutorialAnimController : MonoBehaviour
{

    #region Variables
	
	public GameObject pelaaja;     
 
    public bool isGrounded = true;
    
    public AudioClip hyppy;

    public AudioClip rayHittedSound;  

    public Texture pushDownIndicator;
	
	//private bool walking = true;
	
	//private GameObject kamera;

	public AudioSource source;
	
	public Singleton sinkku;

    //public tk2dButton eteen;

    //public tk2dButton taakke;
	
	public GameObject back;
	
	public GameObject forward;

    public float verticalMultiplier;

    public float horizontalMultiplier;

    public float negativeHorizontalMultiplier;
	
	public float additionalZoomfactorPlus=0;
	public float additionalZoomfactorMultible=1;
	
	public float torque;

    public GameObject mittari;

    private bool jumpStarted = false;

    //private GameObject palkinto;

    private float timer = 0f;

    //private float timerMax = 3f;

    private float fixedTime=0f;

    private GUIStyle style;

    private bool allowDrag = true;

    private Vector3 uusPositio = Vector3.zero;
    //private Vector3 p = Vector3.zero;

    //private Vector3 uusPositio2 = Vector3.zero;
    //private Vector3 p2 = Vector3.zero;

    //private Vector3 uusPositio3 = Vector3.zero;
    //private Vector3 p3 = Vector3.zero;

    //private Vector3 uusPositio4 = Vector3.zero;
    //private Vector3 p4 = Vector3.zero;

    //private int kosketuksia = 0;

    private Rect startRect;
    private Rect targetRect;

    public Camera playerCamera;

    private float currentWidth;
    private float currentHeight;

    private bool rayHit = false;

    private Vector3 originalGravity;

    //private Vector3 kameranAlkupiste = new Vector3();
    //private Vector3 kameranMuutos = new Vector3();


    //float width = 1.0f;
    //Color color = Color.green;
    //Color color2 = Color.blue;

    // Timer variables

    private float r_shootCooldown = 3f;
    private float shootCooldown = 3f;
    private bool canShoot = true;

    #endregion

    #region Methods

    void Start () 
	{
        // "Store" original gravity, altered later in code
        originalGravity = Physics.gravity;
        //kameranAlkupiste = playerCamera.transform.position;
        currentWidth = Screen.width / 3.5F;
        currentHeight = Screen.height / 4F;

        startRect = new Rect(10, 500, currentWidth + 80, currentHeight + 200); 


		sinkku=Singleton.Instance;
		sinkku.addPoints(0); // Reset points


        sinkku.setTotalTime(0f); // Reset time
		
		sinkku.setEtuNapinState(false);
		sinkku.setTakaNapinState(false);

        sinkku.setHypynState(false);

        mittari = GameObject.Find("Mittari");

        //palkinto = GameObject.Find("Palkinto");

        //palkinto.renderer.enabled = false;
		
		//kamera=GameObject.FindGameObjectWithTag("MainCamera");
		isGrounded = false;
       
		back=GameObject.FindGameObjectWithTag("Taakse");
		forward=GameObject.FindGameObjectWithTag("Eteen");

        GameObject.Find("HyppyOnnittelu").SendMessage("hideMe");



        //// Math 'demos'
        //////////////////////////////////////////////////////////
		
        //Debug.Log(Mathf.CeilToInt(10.0F));
        //Debug.Log(Mathf.CeilToInt(10.2F));
        //Debug.Log(Mathf.CeilToInt(10.7F));
        //Debug.Log(Mathf.CeilToInt(-10.0F));
        //Debug.Log(Mathf.CeilToInt(-10.2F));
        //Debug.Log(Mathf.CeilToInt(-10.7F));
		
        //////////////////////////////////////////////////////////
		
        //Debug.Log(Mathf.FloorToInt(10.0F));
        //Debug.Log(Mathf.FloorToInt(10.2F));
        //Debug.Log(Mathf.FloorToInt(10.7F));
        //Debug.Log(Mathf.FloorToInt(-10.0F));
        //Debug.Log(Mathf.FloorToInt(-10.2F));
        //Debug.Log(Mathf.FloorToInt(-10.7F));
		
		
		
        //////////////////////////////////////////////////////////
	
    }

	void Die()
	{
		Application.LoadLevel("End");
	}

	
	bool checkIfFallen()
	{
		
		RaycastHit hit;
		
		int layerMask = 1 << 10; // This mask sets the raycast to ignore all the layers except layer 10 
		
		Ray ray = new Ray();
		ray.origin = pelaaja.transform.position;
		ray.direction = pelaaja.transform.up;
		
		Physics.Raycast(ray, out hit, 4f, layerMask);
		
		//Debug.Log("Etäisyys maahan paallaan : "+hit.distance);
		
		//Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		
        //Debug.DrawRay(ray.origin, forward, Color.red,1f);
		
		
		
		//Debug.DrawRay(ray.origin,ray.direction*100,Color.red,1f);

        // Sivuille extrana !!

        //Debug.DrawRay(ray.origin, pelaaja.transform.right * 100, Color.green, 1f);
        //Debug.DrawRay(ray.origin, pelaaja.transform.right * -100, Color.magenta, 1f);
		
		
		// Kokeiltava vaan !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		// 0.3 ei
		if(hit.distance<=0.6f && hit.distance!=0 )	// Grounded / zero when not reached
        {
			return true;
		}
		else
			return false;
		
	}
		
	void checkIfGrounded()
	{
		
		RaycastHit hit;
		
		int layerMask = 1 << 10; // This mask sets the raycast to ignore all the layers except layer 10 
		
		Ray ray = new Ray();
		ray.origin = pelaaja.transform.position;
		ray.direction = -pelaaja.transform.up;
		
		Physics.Raycast(ray, out hit, 5f, layerMask);
		
		//Debug.Log("Etäisyys maahan : "+hit.distance);
		
		
		//Debug.DrawRay(ray.origin,ray.direction*100,Color.blue,1f);
		//Debug.Log("Eteisyys veteen : "+hit.distance);
		
		
		
		if(hit.distance<=0.5 && hit.distance!=0 )	// Grounded / zero when not reached
        {
			isGrounded=true;
		}
		else
			isGrounded=false;
		
	}
	
	void waterDeath()
	{
		//Debug.Log("Nyt paallaan ja maassa !!!!!!");	
		GameObject.Find("UhkaavaHai2").SendMessage("OnWaterDeath");	// HandMade trigger
		
	}
	
	void tapaPelaaja()
	{
		pelaaja.collider.enabled=false;
	}

    void pauseMusic()
    {
        source.Pause();

        //pelaaja.audio.Pause();
    }

    void resumeMusic()
    {
        source.Play();
    }

    void TestMessage(MessageArgs args)
    {
        if (sinkku.giveMuteState())
            args.answer = true;

        else { /* NOP */ }
            
    }


    public virtual bool getPlayingState()
    {
        return gameObject.audio.isPlaying;
    }
	
    void Update () 
    {

        if (!canShoot)
        {
            r_shootCooldown -= Time.deltaTime;
            if (r_shootCooldown <= 0)
            {
                RestoreAlteredPhysics();
                // Can shoot again, reset cooldown
                canShoot = true;
                r_shootCooldown = shootCooldown;
            }
        }


        Vector3 vektori = new Vector3();

        vektori = playerCamera.transform.position;

        vektori.z=100f;

        //Debug.Log("Debug vektorin origin ja suunta : " + vektori + " , " + playerCamera.transform.forward);
        Debug.DrawRay(vektori, playerCamera.transform.forward * 20f, Color.cyan, 0.01f);

   
        #region Kosketus1

        if (Input.touchCount >= 1)
        {
          
            RaycastHit hit;

            int layerMask = 1 << 20; // This mask sets the raycast to ignore all the layers except layer 20 

            Ray ray = new Ray();

            ray.origin=playerCamera.ScreenToWorldPoint(Input.GetTouch(0).position);
			
			Vector3 temp = Vector3.zero;
			
			temp.x = ray.origin.x - playerCamera.transform.position.x; // Cam moves	
			temp.y = ray.origin.y - playerCamera.transform.position.y;	// Jumps
			temp.z = ray.origin.z; // Zero but seems that the shot ray originates from the main camera 
			
			// Plane is not moving! so convert the moving touch world coordinates to "static" ones
			
			// Not static because camera moves ->
			ray.origin = temp;
			
			// Not static if jumped ->
			//ray.origin.y-= playerCamera.transform.position.y;
            
			
			Vector3 suunta = Vector3.zero;

			
			suunta.x = ray.origin.x;
			suunta.y = ray.origin.y;
			suunta.z = 1f; // Towards positive axis
			
				
				
			ray.direction=suunta;

            //Physics.Raycast(ray, out hit, 50f, layerMask)

            if (Physics.Raycast(ray, out hit, 50f, layerMask) && !sinkku.isPaused() && !isGrounded && pelaaja.collider.enabled) // Prevent casting if paused or grounded !
            {
				rayHit = true;
                Vector2 i = Input.GetTouch(0).position;
                uusPositio.x = i.x;
                uusPositio.y = i.y;

                //p = playerCamera.ScreenToWorldPoint(uusPositio);


                if (!isGrounded && canShoot)
                {
                    canShoot = false;

                    // Increase gravity temporely
                    Physics.gravity = new Vector3(0, -20.0F, 0);
                    audio.PlayOneShot(rayHittedSound);
                }
                

                //instance2.transform.Rotate(-90, -180, 0);
                //Vector3 fwd2 = transform.TransformDirection(Vector3.forward);
                //instance2.AddForce(fwd2 * power);
                //GetComponent<AudioSource>().Play();

                //Destroy(instance2.gameObject, bulletLifeSpan);
            }

            else
                rayHit = false;
        }

        #endregion


        timer += Time.deltaTime;
		
		if(isGrounded)
			GameObject.FindGameObjectWithTag("Splash").SendMessage("startEffect");
		
		else
			GameObject.FindGameObjectWithTag("Splash").SendMessage("stopEffect");
		
        sinkku.setTotalTime(timer);
		

		//Debug.Log("Nappulan elinaika : "+eteen.buttonDown);
        adjustCamera();
		checkIfGrounded();
		bool check = checkIfFallen();
		
		//CheckDeath
		if((pelaaja.transform.eulerAngles.z>90 && pelaaja.transform.eulerAngles.z<270) && check)
		{
			waterDeath();
		}
		
		// Update gauges
		// GameObject.Find("Speed").SendMessage("addSpeed",pelaaja.transform.rigidbody.velocity.x);
		// GameObject.Find("Torque").SendMessage("addTorque",pelaaja.transform.rigidbody.angularVelocity.z);

        // if (Input.GetKey("right") || eteen.buttonDown)  // Jos painetaan nuolinäppäintä oikealle
        if(Input.GetKey("right") || sinkku.getEtuNapinState())
		{ 
			checkIfGrounded();
								
            // float zRotaatio= pelaaja.transform.eulerAngles.z;
			// Debug.Log ("Z-Rotaatio : "+zRotaatio);
			
			
			// Clamp excessive speeding
			if(pelaaja.transform.rigidbody.velocity.x>=-10 && pelaaja.transform.rigidbody.velocity.x <=10 && isGrounded)
			{
				    // if(!(zRotaatio>90 && zRotaatio<270))
					pelaaja.transform.rigidbody.AddForce(new Vector3(1, 0, 0) * horizontalMultiplier);    //Pelaajaan lisätään voimaa oikealle kymmenkertaisena
		            // else if(pelaaja == isGrounded)	// liiku silti ilmassa
		            // pelaaja.transform.rigidbody.AddForce(new Vector3(0, 0, 0));		// Turvallaan
					
				
				    // GameObject.Find("Main Camera").SendMessage("Scoring");			// LOL
				    // kamera.transform.rigidbody.AddForce(new Vector3(1, 0, 0) * 10);    //Pelaajaan lisätään voimaa oikealle kymmenkertaisena		
			}
			
			
			
			//if(!(zRotaatio>90 && zRotaatio<270) && !isGrounded)
			if(!isGrounded)
			{
				pelaaja.transform.rigidbody.AddTorque(new Vector3(0, 0, 1) * -torque);
			}
        }

        //if (Input.GetKey("left") || taakke.buttonDown)  //Jos painetaan nuolinäppäintä vasemmalle
        if(Input.GetKey("left") || sinkku.getTakaNapinState())
		{
				
			checkIfGrounded();
			
            //float zRotaatio= pelaaja.transform.eulerAngles.z;
			
		    // Clamp excessive speeding
		    if(pelaaja.transform.rigidbody.velocity.x>=-10 && pelaaja.transform.rigidbody.velocity.x <=10 && isGrounded)
		    {
				
			    //if(!(zRotaatio>90 && zRotaatio<270))
                pelaaja.transform.rigidbody.AddForce(new Vector3(-1, 0, 0) * negativeHorizontalMultiplier);   //Pelaajaan lisätään voimaa vasemmalle kymmenkertaisena
		        //	else if(pelaaja == isGrounded)	// liiku silti ilmassa
		        //		pelaaja.transform.rigidbody.AddForce(new Vector3(0, 0, 0)); // Turvallaan
		
            }
				
			//else if(pelaaja != isGrounded)	// liiku silti ilmassa
			//		pelaaja.transform.rigidbody.AddForce(new Vector3(1, 0, 0) * 10);
			
			//if(!(zRotaatio>90 && zRotaatio<270) && !isGrounded)
			if(!isGrounded)
			{
				pelaaja.transform.rigidbody.AddTorque(new Vector3(0, 0, 1) * torque);
			}
        }



        //if (Input.GetKeyDown("space") || (taakke.buttonDown && eteen.buttonDown))  //Jos painetaan spacea tai touchi
        if(Input.GetKeyDown("space") || (sinkku.getEtuNapinState() && sinkku.getTakaNapinState()))
		{
        	Hyppaa();   
        }
    }


    void RestoreAlteredPhysics()
    {
        Physics.gravity = originalGravity;
    }
	
    void Hyppaa() 
	{
		checkIfGrounded();	
		if(isGrounded)	// Grounded / zero when not reached
        {
            
            audio.PlayOneShot(hyppy);
                                              
            Vector3 nopeus = pelaaja.rigidbody.velocity;     // Alustetaan Vector3 nimeltä nopeus ja tallennetaan siihen pelaajan nopeus 3D-koordinaatistossa (x,y,z)
            nopeus.y = verticalMultiplier;                                   //Y:n suuntaiseen nopeuteen lisätään 5
			
            pelaaja.rigidbody.velocity = nopeus;            //Pelaajaan nopeuteen lisätään uusi nopeus
            jumpStarted = true;
            //timer = 0f;
            fixedTime=timer;
            
        }
		
	}

    void adjustCamera()
    {
        RaycastHit hit;

        int layerMask = 1 << 10; // This mask sets the raycast to ignore all the layers except layer 10 

        Ray ray = new Ray();
        
        //ray.origin=mittari.t
        ray.origin = mittari.transform.position;
        ray.direction = new Vector3(0, -90, 0);  // Points always down

        //ray.direction = -mittari.transform.up;

        Physics.Raycast(ray, out hit, 50f, layerMask);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 0.1f);

        //Debug.Log("Etäisyys maahan on : " + hit.distance);

        float realScale = hit.distance;
        if (Camera.main != null)
        {
            //////else // ilmassa
				Camera.main.orthographicSize = 1.2f+(realScale-(realScale*0.8f)); 
			
        }
 
    }

    void LateUpdate()
    {
        //Debug.Log("Voima alas : " + pelaaja.rigidbody.velocity.y);

        if (jumpStarted == true && isGrounded && (pelaaja.rigidbody.velocity.y>=0 && pelaaja.rigidbody.velocity.y<=0.1))
        {
            jumpStarted = false;
            sinkku.setHypynAika((fixedTime+=Time.deltaTime-timer)*-1);
            StartCoroutine(WaitAndPrint(0.2f));
            GameObject.Find("HyppyOnnittelu").SendMessage("showMe");
			fixedTime=0f;
        }
        //Debug.Log("Hypyn tila : " + jumpStarted);

        if (isGrounded)
        {
            RestoreAlteredPhysics();
            canShoot = true;
        }

    }

    // Idlaa float sekuntimäärän ennen GameOver skenen latausta
    public IEnumerator WaitAndPrint(float waitTime)
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("hideMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("showMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("hideMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("showMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("hideMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("showMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("hideMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("showMe");
            yield return new WaitForSeconds(waitTime);
            GameObject.Find("HyppyOnnittelu").SendMessage("hideMe");
        }
    }


    // Ei vitus !!
    public IEnumerator alterPhysics(float waitTime)
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
        yield return new WaitForSeconds(waitTime);
        RestoreAlteredPhysics();
    }

    #endregion


    

    public void OnGUI()
    {
        Vector2 pointA = new Vector2(Screen.width / 2, Screen.height / 2);   
        Vector3 vektori = pointA;

		vektori.z=50f;

        if (Input.touchCount > 0)
        {     
            Vector3 withDepth = Input.GetTouch(0).position;
			Vector3 withDepth2 = Input.GetTouch(0).position;

            withDepth.z=0f;
			//withDepth.z=-10f;

            //Drawing2.DrawLine(playerCamera.transform.position,withDepth, color2);

                //// Finger two
                //if (Input.touchCount >= 2)
                //{
                //    Rect cursorPos2 = new Rect(Input.GetTouch(1).position.x - 150, Screen.height - Input.GetTouch(1).position.y - 150, 300, 300);
                //    GUI.DrawTexture(cursorPos2, pushDownIndicator);
                //}

                //// Finger three
                //if (Input.touchCount >= 3)
                //{
                //    Rect cursorPos3 = new Rect(Input.GetTouch(2).position.x - 150, Screen.height - Input.GetTouch(2).position.y - 150, 300, 300);
                //    GUI.DrawTexture(cursorPos3, pushDownIndicator);
                //}

                //// Finger four
                //if (Input.touchCount >= 4)
                //{
                //    Rect cursorPos4 = new Rect(Input.GetTouch(3).position.x - 150, Screen.height - Input.GetTouch(3).position.y - 150, 300, 300);
                //    GUI.DrawTexture(cursorPos4, pushDownIndicator);
                //}

            withDepth2 = withDepth;

           withDepth2.z=-20;

            //VectorLine.SetRay(Color.white, 1f, withDepth,withDepth2 );

                // Finger one
                if (rayHit && !sinkku.isPaused())   // Ray hits && game NOT paused (feature disabled if pause is on) 
                {
                    Rect cursorPos = new Rect(Input.GetTouch(0).position.x - 150, Screen.height - Input.GetTouch(0).position.y - 150, 300, 300);
                    GUI.DrawTexture(cursorPos, pushDownIndicator);
                }
            }


        // Make GUI box
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = Color.blue;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 30;
        }

        // Register the window (window ID must be unique)
        startRect = GUI.Window(1, startRect, DoMyWindow, "");
    }


    
    void DoMyWindow(int windowID)
    {
        // Debug box content ->
        if (Singleton.userFloatList.Count > 0)
            GUI.Label(new Rect(0, 0, startRect.width, startRect.height), "isMuted arvo : " + sinkku.giveMuteState() + "\nisPaused arvo : " + sinkku.isPaused() + "\nGravitaatio : " + Physics.gravity.y + "\nAlkuRectangeli : \n" + startRect + "\nAudioListener bool : " + AudioListener.pause+"\nRayCastPlaneen muutettu pystyskaala (Z) : "+Singleton.userFloatList[Singleton.userFloatList.Count-1], style);
        //GUI.Label(new Rect(0, 0, startRect.width, startRect.height), "isMuted arvo (negated) : " + !sinkku.giveMuteState() + "\nisPaused arvo : " + sinkku.isPaused() + "\nGravitaatio : " + Physics.gravity.y, style);
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
}