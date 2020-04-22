using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager_end : MonoBehaviour
{
    public GameObject Player;
    public Vector2 currentPlayerPosition;
    // Start is called before the first frame update

    public Text displayX;
    public Text displayY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Show current Player Position
        displayX.text = "X: " + Player.transform.position.x.ToString();
        displayY.text = "Y: " + Player.transform.position.y.ToString();

        // Save Player Position
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetFloat("savedPositionX", Player.transform.position.x);
            PlayerPrefs.SetFloat("savedPositionY", Player.transform.position.y);
            PlayerPrefs.SetInt("playerGold", 100);

            Debug.Log("Saved Player Position as :" + Player.transform.position.x + ", " + Player.transform.position.y);
        }

        // Load Player Position
        if (Input.GetKeyDown(KeyCode.L))
        {
            float load_x = PlayerPrefs.GetFloat("savedPositionX");
            float load_y = PlayerPrefs.GetFloat("savedPositionY");
            int loadGold = PlayerPrefs.GetInt("playerGold");
            Vector2 loadPlayer = new Vector2(load_x, load_y);
            Player.transform.position = loadPlayer;

            Debug.Log("Loaded Player Position as: " + load_x + ", " + load_y);
        }
    }
}
