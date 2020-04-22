using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//============================== Terminology ==============================
//     Overview Item = Playerpref that the user added to the overview
//=========================================================================

public class PlayerPrefsViewer : EditorWindow
{
    string[] prefOverviewType = { "String", "Integer", "Float" };   //Overview Edit Panel: PlayerPref Type (Names of the PlayerPref types)
    int prefOverviewTypeIndex = 0;                                  //Overview Edit Panel: PlayerPref Type Index (Index of the selected option)
    string prefsOverviewName = "";                                  //Overview Edit Panel: PlayerPref Name

    bool oeActive = true;                                           //Overview Edit Panel toggle state
    Texture2D logo;                                                 //The Logo Texture

    List<string> overviewItems = new List<string>();                //All loaded Overview Items

    [MenuItem("Window/PlayerPrefs Viewer")]
    static void Init()
    {
        GetWindow<PlayerPrefsViewer>("Prefs Viewer");
    }

    private void OnEnable()
    {
        MonoScript script = MonoScript.FromScriptableObject(this);
        string path = AssetDatabase.GetAssetPath(script);                           //Getting the path of the script (to load the logo)
        path = path.Substring(0, path.Length - 20) + "PPV_Logo.png";                //Adding the logo file to the path
        logo = (Texture2D)AssetDatabase.LoadAssetAtPath(path, typeof(Texture));     //Setting the logo texture
    }

    private void OnGUI()
    {
        //Topbar
        oeActive = EditorPrefs.GetBool("PPV_oeActive");         //Getting Overview Edit Panel toggle state
        GUILayout.BeginHorizontal(EditorStyles.toolbar);
        EditorPrefs.SetBool("PPV_oeActive", GUILayout.Toggle(oeActive, "Edit Overview", EditorStyles.toolbarButton));   //Saving Overview Edit Panel toggle state & toggeling Overview Edit Panel
        if (GUILayout.Button("Log Prefs", EditorStyles.toolbarButton))  //Logging all Overview Items
        {
            Debug.Log(EditorPrefs.GetString("PPV_OverviewItems"));
        }
        if (GUILayout.Button("Reset Overview", EditorStyles.toolbarButton))
        {
            EditorPrefs.SetString("PPV_OverviewItems", "");
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        //Logo
        GUIStyle centeredStyle = GUI.skin.GetStyle("Label");    //Creating the GUIStyle to center-align the Logo
        centeredStyle.alignment = TextAnchor.UpperCenter;
        centeredStyle.fixedHeight = 100;
        GUILayout.Label(logo, centeredStyle);

        centeredStyle = GUI.skin.GetStyle("Label");             //Going back to left-alignment
        centeredStyle.alignment = TextAnchor.UpperLeft;
        centeredStyle.fixedHeight = 0;

        //Overview Edit Panel
        if (oeActive)
        {

            EditorGUILayout.Space();
            GUILayout.Label("Add To Overview", EditorStyles.boldLabel);
            prefsOverviewName = EditorGUILayout.TextField("PlayerPref Name", prefsOverviewName);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Type");
            prefOverviewTypeIndex = EditorGUILayout.Popup(prefOverviewTypeIndex, prefOverviewType);
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();
            GUILayout.Label("Please make sure that the name doesn't contain ','.");
            GUILayout.BeginHorizontal();
            //Resetting all Fields
            if (GUILayout.Button("Reset Fields"))
            {
                prefOverviewTypeIndex = 0;
                prefsOverviewName = "";
            }
            //Remove from Overview
            if (GUILayout.Button("Remove From Overview"))
            {
                string overviewItems = EditorPrefs.GetString("PPV_OverviewItems");
                if (prefOverviewTypeIndex == 0 && !(prefsOverviewName.Contains(","))) //Item to remove is a string and doesn't contain commas
                {
                    if(overviewItems.IndexOf(",STRING_" + prefsOverviewName) == -1)
                    {
                        if((prefsOverviewName.Length != 0) && (overviewItems.IndexOf("STRING_" + prefsOverviewName) != -1)){
                            overviewItems = overviewItems.Remove(overviewItems.IndexOf("STRING_" + prefsOverviewName), ("STRING_" + prefsOverviewName).Length);
                        }
                    }
                    else
                    {
                        if ((prefsOverviewName.Length != 0) && (overviewItems.IndexOf(",STRING_" + prefsOverviewName) != -1))
                        {
                            overviewItems = overviewItems.Remove(overviewItems.IndexOf(",STRING_" + prefsOverviewName), (",STRING_" + prefsOverviewName).Length);
                        }
                    }
                }
                else if (prefOverviewTypeIndex == 1 && !(prefsOverviewName.Contains(","))) //Item to remove is an integer and doesn't contain commas
                {
                    if (overviewItems.IndexOf(",INT_" + prefsOverviewName) == -1)
                    {
                        if ((prefsOverviewName.Length != 0) && (overviewItems.IndexOf("INT_" + prefsOverviewName) != -1))
                        {
                            overviewItems = overviewItems.Remove(overviewItems.IndexOf("INT_" + prefsOverviewName), ("INT_" + prefsOverviewName).Length);
                        }
                    }
                    else
                    {
                        if ((prefsOverviewName.Length != 0) && (overviewItems.IndexOf(",INT_" + prefsOverviewName) != -1))
                        {
                            overviewItems = overviewItems.Remove(overviewItems.IndexOf(",INT_" + prefsOverviewName), (",INT_" + prefsOverviewName).Length);
                        }
                    }
                }
                else if (prefOverviewTypeIndex == 2 && !(prefsOverviewName.Contains(","))) //Item to remove is a float and doesn't contain commas
                {
                    if (overviewItems.IndexOf(",FLOAT_" + prefsOverviewName) == -1)
                    {
                        if ((prefsOverviewName.Length != 0) && (overviewItems.IndexOf("FLOAT_" + prefsOverviewName) != -1))
                        {
                            overviewItems = overviewItems.Remove(overviewItems.IndexOf("FLOAT_" + prefsOverviewName), ("FLOAT_" + prefsOverviewName).Length);
                        }
                    }
                    else
                    {
                        if ((prefsOverviewName.Length != 0) && (overviewItems.IndexOf(",FLOAT_" + prefsOverviewName) != -1))
                        {
                            overviewItems = overviewItems.Remove(overviewItems.IndexOf(",FLOAT_" + prefsOverviewName), (",FLOAT_" + prefsOverviewName).Length);
                        }
                    }
                }
                EditorPrefs.SetString("PPV_OverviewItems", overviewItems);
                prefOverviewTypeIndex = 0;
                prefsOverviewName = "";
            }
            //Add to Overview
            if (GUILayout.Button("Add To Overview"))
            {
                if (prefOverviewTypeIndex == 0 && !(prefsOverviewName.Contains(","))) //Item to add is a string and doesn't contain commas
                {
                    EditorPrefs.SetString("PPV_OverviewItems", EditorPrefs.GetString("PPV_OverviewItems") + ",STRING_" + prefsOverviewName);
                }
                else if (prefOverviewTypeIndex == 1 && !(prefsOverviewName.Contains(","))) //Item to remove is an integer and doesn't contain commas
                {
                    EditorPrefs.SetString("PPV_OverviewItems", EditorPrefs.GetString("PPV_OverviewItems") + ",INT_" + prefsOverviewName);
                }
                else if (prefOverviewTypeIndex == 2 && !(prefsOverviewName.Contains(","))) //Item to remove is a float and doesn't contain commas
                {
                    EditorPrefs.SetString("PPV_OverviewItems", EditorPrefs.GetString("PPV_OverviewItems") + ",FLOAT_" + prefsOverviewName);
                }
                prefOverviewTypeIndex = 0;
                prefsOverviewName = "";
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        }

        //Overview
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Overview", EditorStyles.boldLabel);
        //Reloading the Overview
        if (GUILayout.Button("Reload"))
        {
            Repaint();
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        EditorGUILayout.Space();
        overviewItems = getOverview(); //Getting all Overview Items

        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));

        //Displaying the Overview
        for (int i = 0; i < overviewItems.Count; i++)
        {
            //Overview Item is a string
            if (overviewItems[i].StartsWith("STRING_"))
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(overviewItems[i].Substring(overviewItems[i].IndexOfAny("_".ToCharArray()) + 1), GUILayout.MinWidth(Screen.width / 2 - 50));
                GUILayout.Label(PlayerPrefs.GetString(overviewItems[i].Substring(overviewItems[i].IndexOfAny("_".ToCharArray()) + 1)), GUILayout.MinWidth(Screen.width / 2 - 50));
                EditorGUILayout.EndHorizontal();
            }
            //Overview Item is an integer
            else if (overviewItems[i].StartsWith("INT_"))
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(overviewItems[i].Substring(overviewItems[i].IndexOfAny("_".ToCharArray()) + 1), GUILayout.MinWidth(Screen.width / 2 - 50));
                GUILayout.Label(PlayerPrefs.GetInt(overviewItems[i].Substring(overviewItems[i].IndexOfAny("_".ToCharArray()) + 1)).ToString(), GUILayout.MinWidth(Screen.width / 2 - 50));
                EditorGUILayout.EndHorizontal();
            }
            //Overview Item is a float
            else if (overviewItems[i].StartsWith("FLOAT_"))
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(overviewItems[i].Substring(overviewItems[i].IndexOfAny("_".ToCharArray()) + 1), GUILayout.MinWidth(Screen.width / 2 - 50));
                GUILayout.Label(PlayerPrefs.GetFloat(overviewItems[i].Substring(overviewItems[i].IndexOfAny("_".ToCharArray()) + 1)).ToString(), GUILayout.MinWidth(Screen.width / 2 - 50));
                EditorGUILayout.EndHorizontal();
            }
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        }
    }

    //Function to get all Overview Items from EditorPrefs
    List<string> getOverview()
    {
        List<string> output = new List<string>();
        string itemsRawString = EditorPrefs.GetString("PPV_OverviewItems");
        if (itemsRawString.StartsWith(","))
        {
            itemsRawString = itemsRawString.Substring(1);
            EditorPrefs.SetString("PPV_OverviewItems", itemsRawString);
        }
        string[] itemsRaw = itemsRawString.Split(new string[] { "," }, StringSplitOptions.None);
        for (int i = 0; i < itemsRaw.Length; i++)
        {
            output.Add(itemsRaw[i]);
        }
        return (output);
    }
}
