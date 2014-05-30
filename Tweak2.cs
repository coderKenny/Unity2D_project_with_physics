using UnityEngine;
using System.Collections;

public class Tweak2 : MonoBehaviour
{
    public float speed = 10.0F;
    public Vector2 touchi = Vector2.zero;
    public Texture CursorImage; // image to draw on the screen as the player's crosshair
    public GameObject projectile;
    private bool isVibrating;
    public Texture icon;
    private GUIStyle style;

    private float currentWidth = Screen.width;
    private float currentHeight = Screen.height;

    private float calculatedAspectRatio;


    void Start()
    {
        calculatedAspectRatio = currentWidth / currentHeight;
        isVibrating = false;
        GetComponent<GUIText>().fontStyle = FontStyle.Bold;

        if (Screen.height > 1200)       // iso screna
            GetComponent<GUIText>().fontSize = 30;
        else if (Screen.height > 700)   // keski screna
            GetComponent<GUIText>().fontSize = 20;
        else                            // pieni screna
            GetComponent<GUIText>().fontSize = 10;

        GetComponent<GUIText>().material.color = Color.magenta;

        // Initial text
        GameObject.Find("InfoRuutu2").guiText.text = "Tekstia koodista :)";
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero;
        Vector3 gyro = Vector3.zero;
        
        dir.x = Input.acceleration.x*1;
        dir.y = Input.acceleration.y*1;
        dir.z = Input.acceleration.z*1;

        
        // Check touch
        if (Input.touchCount > 0)
        {
            touchi.x = Input.GetTouch(0).position.x;
            touchi.y = Input.GetTouch(0).position.y;
        }

        // Gyro
        gyro.x = Input.gyro.gravity.x;
        gyro.y = Input.gyro.gravity.y;
        gyro.z = Input.gyro.gravity.z;


        // Print them
        // GameObject.Find("InfoRuutu2").guiText.text = "\n\n\nKiihtyvyysanturin arvot (x,y,z) : \nX : " + dir.x + "\nY : " + dir.y + "\nZ : " + dir.z + "\nGyroscope : " + SystemInfo.supportsGyroscope + "\nMalli : " + SystemInfo.deviceModel + "\nGrafiikkaCORE : " + SystemInfo.graphicsDeviceName + "\nTouch lokaatio : "+touchi.x+" , "+touchi.y+"\n\nGyron kiihtyvyysarvot : \nX : "+ gyro.x + "\nY : " + gyro.y + "\nZ : " + gyro.z+"\n\nProssu : " +SystemInfo.processorType+"\nYtimi‰ : "+SystemInfo.processorCount;

        // if (dir.sqrMagnitude > 1)
        // dir.Normalize();

        // dir *= Time.deltaTime;
        // transform.Translate(dir * speed);

        // int i = 0;

        // while (i < Input.touchCount)
        // {
            
        // if (Input.GetTouch(i).phase == TouchPhase.Began)
  

        // clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

        // ++i;
    }

    private void WriteText(int indeksi)
    {
        switch(indeksi)
        {
            case 0:
                GameObject.Find("InfoRuutu2").guiText.text = "Ekan kosketuksen tyyppi : " + Input.GetTouch(0).phase + "\nSen positio :" + Input.GetTouch(0).position;
                break;

            case 1:
                GameObject.Find("InfoRuutu2").guiText.text = GameObject.Find("InfoRuutu2").guiText.text + "\n\nTokan kosketuksen tyyppi : " + Input.GetTouch(1).phase + "\nSen positio :" + Input.GetTouch(1).position;
                break;

            case 2:
                GameObject.Find("InfoRuutu2").guiText.text = GameObject.Find("InfoRuutu2").guiText.text + "\n\nKolmen kosketuksen tyyppi : " + Input.GetTouch(2).phase + "\nSen positio :" + Input.GetTouch(2).position;
                break;
        }
    }

    private void OnGUI()
    {     
        int i = 0;
        int j = 0;

        if (style == null)
        {
            style = new GUIStyle(GUI.skin.button);
            style.normal.textColor = Color.green;
            style.alignment = TextAnchor.MiddleCenter;         
            style.fontSize = 15;
        }


        //float calculatedAspectRatio = currentHeight / currentWidth;
        GameObject.Find("InfoRuutu2").guiText.text = "\n\n               Height, width, ratio : " + currentHeight + " , " + currentWidth + " , " + calculatedAspectRatio;

        //tyyli.font.material.color = Color.white;

        if (Screen.height > 500) // Galaxy :)
        {
            // if (GUI.Button(new Rect(Screen.width / 2 - 250, 10, 500, 300), "Vibrate!",tyyli))
            // Vibra hanikka oikeeseen yl‰pes‰‰n
            
            if (GUI.Button(new Rect(Screen.width - Screen.width / 5-10, 10, Screen.width / 5, Screen.height / 8), new GUIContent("Vibrate !!!", icon), style))
            {
                if (!isVibrating)
                {
                    isVibrating = true;

                    for (j = 0; j < 5; j++)
                        StartCoroutine(Oota(j));

                    // Enable button again after 5 seconds
                    StartCoroutine(Venaa(5));
                }
            }
                
        }

       // GUI.Button(new Rect(0, 0, 100, 20), new GUIContent("Click me", icon));

        if (Input.touchCount > 0)
        {
            WriteText(0);
        }

        if (Input.touchCount > 1)
        {
            WriteText(1);
        }

        if (Input.touchCount > 2)
        {
            WriteText(2);
        }

        
        // Draw cursor graphic at mouse cursor using gui texture
        // Screen height used to create inverted / correct drawing

        while (i < Input.touchCount)
        {
            // React to all phases expect end & cancelled
            // http://docs.unity3d.com/Documentation/ScriptReference/TouchPhase.html
            if (Input.GetTouch(i).phase == TouchPhase.Began || Input.GetTouch(i).phase == TouchPhase.Stationary || Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                Rect cursorPos = new Rect(Input.GetTouch(i).position.x - 150, Screen.height - Input.GetTouch(i).position.y - 150, 300, 300);
                GUI.DrawTexture(cursorPos, CursorImage);
            }
            ++i;      
        }
      }


    public IEnumerator Oota(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Handheld.Vibrate();
        
        
        //yield return new WaitForSeconds(waitTime);
        //Handheld.Vibrate();
        //yield return new WaitForSeconds(waitTime);
        //Handheld.Vibrate();
        //yield return new WaitForSeconds(waitTime);
        //Handheld.Vibrate();
        //yield return new WaitForSeconds(waitTime);
        //Handheld.Vibrate();
    }


    public IEnumerator Venaa(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isVibrating =! isVibrating; // Turn SW switch
    }
}
