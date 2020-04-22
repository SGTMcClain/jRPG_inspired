using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Instance GameManager as a singleton
    public static GameManager instance = null;

    readonly string PP_xPOSITION_STRING = "savedPositionX";
    readonly string PP_yPOSITION_STRING = "savedPositionY";

    public GameObject player;
    public Text displayX;
    public Text displayY;

    public GameObject TopUI;

    private void Awake()
    {
        // If the GameManager isn't created then create it.
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Update_XY();
        ToggleCanvas();

        // Save to Player Prefs
        if (Input.GetKeyDown(KeyCode.P))
        {
            Save();
        }
    }

    public void Save()
    {
        float xPosition = player.transform.position.x;
        float yPosition = player.transform.position.y;


        PlayerPrefs.SetFloat(PP_xPOSITION_STRING, xPosition);
        PlayerPrefs.SetFloat(PP_yPOSITION_STRING, yPosition);

        Debug.Log("Player Prefs Saved : x = " + xPosition + " y = " + yPosition);
    }

    public void Load()
    {
        float load_x = PlayerPrefs.GetFloat(PP_xPOSITION_STRING);
        float load_y = PlayerPrefs.GetFloat(PP_yPOSITION_STRING);

        Vector2 loadPlayer = new Vector2(load_x, load_y);

        player.transform.position = loadPlayer;
        Debug.Log("Player Prefs Loaded!");
    }
    void ToggleCanvas()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle Top UI
            if (!TopUI.activeSelf) // if the Top UI is not active
            {
                TopUI.SetActive(true); // Show the Canvas
            }
            else
            {
                TopUI.SetActive(false); // Hide the Canvas
            }

        }
    }
    void Update_XY()
    {
        string xText = player.transform.position.x.ToString();
        string yText = player.transform.position.y.ToString();
        displayX.text = "X: " + xText;
        displayY.text = "Y: " + yText;
    }
}
