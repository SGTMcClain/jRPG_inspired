using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text displayX;
    public Text displayY;
    public GameObject TopUI;

    string playerX = "playerXposition";
    string playerY = "playerYposition";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Update_XY();
        ToggleCanvas();

    }

    public void Save()
    {
        float xPosition = player.transform.position.x;
        float yPosition = player.transform.position.y;

        PlayerPrefs.SetFloat(playerX, xPosition);
        PlayerPrefs.SetFloat(playerY, yPosition);

        Debug.Log("Player Prefs Saved: x = " + xPosition + " y = " + yPosition);
    }

    public void Load()
    {
        float load_x = PlayerPrefs.GetFloat(playerX);
        float load_y = PlayerPrefs.GetFloat(playerY);

        Vector2 loadPlayer = new Vector2(load_x, load_y);

        player.transform.position = loadPlayer;
        Debug.Log("Player Prefs Loaded");
    }

    void ToggleCanvas()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!TopUI.activeSelf)
            {
                TopUI.SetActive(true);
            }
            else
            {
                TopUI.SetActive(false);
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
