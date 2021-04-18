using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugController : MonoBehaviour
{
	//Styling
    GUIStyle boxStyle = null;
    GUIStyle borderStyle1 = null;
    GUIStyle borderStyle2 = null;
    
	//Control variables
    bool isFocused;
    bool showConsole;
    bool showHelp;

    string input;

	//Static commands variables
    public static DebugCommand<int> INT_COMMAND_HERE;
    public static DebugCommand SIMPLE_COMMAND_HERE;
    public static DebugCommand HELP;

    public List<object> commandList;

	//Initilize DebugCommands and add to "commandList"
    private void Awake()
    {
        INT_COMMAND_HERE = new DebugCommand<int>("int_command_here", "Example command with int parameter.", "int_command_here <value>", (x) =>
        {
            Debug.Log("Command with int parameter called. Int value: " + x);
        });

        SIMPLE_COMMAND_HERE = new DebugCommand("simple_command_here", "Example command with no parameter.", "simple_command_here", () =>
        {
            Debug.Log("Command with no parameter called.");
        });

        HELP = new DebugCommand("help", "Show a list of commands.", "help", () =>
        {
            showHelp = true;
            isFocused = true;
        });

        commandList = new List<object>
        { 
            INT_COMMAND_HERE,
            SIMPLE_COMMAND_HERE,
            HELP
        };

    }

	//Listen for input BackQuote to show the debug console
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            OnToggleDebug();
        }
    }

    public void OnToggleDebug()
    {
        showConsole = !showConsole;
        isFocused = showConsole;
    }

    Vector2 scroll;
    
	//Styles initializator
    private void InitStyles()
    {
        if(boxStyle == null)
        {
            boxStyle = new GUIStyle( GUI.skin.box );
            boxStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 0f, 0f, 1f ) );
        }

        if (borderStyle1 == null)
        {
            borderStyle1 = new GUIStyle(GUI.skin.box);
            borderStyle1.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 1f ) );
        }
        
        if (borderStyle2 == null)
        {
            borderStyle2 = new GUIStyle(GUI.skin.box);
            borderStyle2.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 1f ) );
        }
    }
 
	//Function useful to set color to the console
    private Texture2D MakeTex( int width, int height, Color col )
    {
        Color[] pix = new Color[width * height];
        for( int i = 0; i < pix.Length; ++i )
        {
            pix[ i ] = col;
        }
        Texture2D result = new Texture2D( width, height );
        result.SetPixels( pix );
        result.Apply();
        return result;
    }

    private void OnGUI()
    {
        InitStyles();
		
        if (!showConsole) return;

		//Handle BackQuote input (close the debug console if pressed)
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.BackQuote)
        {
            OnToggleDebug();
        }

        float y = 0f;
        int borderThickness = 1;

        if (showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "", borderStyle1);
            GUI.Box(new Rect(borderThickness, y + borderThickness, Screen.width - (borderThickness * 2), 100 - (borderThickness * 2)), "", boxStyle);

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);
            scroll = GUI.BeginScrollView(new Rect(borderThickness, y+5f+borderThickness, Screen.width - (borderThickness * 2), 90 - (borderThickness * 2)), scroll, viewport);

            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;
                string label = $"{command.commandFormat} - {command.commandDescription}";
                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);
                GUI.Label(labelRect, label);
            }

            GUI.EndScrollView();

            y += 100;
        }

        GUI.Box(new Rect(0, y, Screen.width, 30), "", borderStyle1);
        GUI.Box(new Rect(borderThickness, y + borderThickness, Screen.width - (borderThickness * 2), 30 - (borderThickness * 2)),"", boxStyle);
        
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        GUI.SetNextControlName("InputField");
        input = GUI.TextField(new Rect(borderThickness+2f, y + 5f, Screen.width, 20f), input);

        //Set Focus to Input Field just once
        if (isFocused)
        {
            GUI.FocusControl("InputField");
            isFocused = false;
        }

        //Handle enter/return input
        if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
        {
            HandleInput();
            input = "";
        }
    }

	//Handle command input/parameters
    private void HandleInput()
    {
        string[] properties = input.Split(' ');

        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
            if (input.Contains(commandBase.commandId))
            {
                if(commandList[i] is DebugCommand command)
                {
                    command.Invoke();
                }else if(commandList[i] is DebugCommand<int> commandInt)
                {
                    commandInt.Invoke(int.Parse(properties[1]));
                }
            }
        }
    }
}
