using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public Text storyText; // the story 
    public InputField userInput; // the input field object
    public Text inputText; // part of the input field where user enters response
    public Text placeHolderText; // part of the input field for initial placeholder text

    public delegate void Restart();
    public event Restart onRestart;
    
    private string story; // holds the story to display
    private List<string> commands = new List<string>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
        commands.Add("go");
        commands.Add("get");
        commands.Add("restart"); //added to work with delagate example

        userInput.onEndEdit.AddListener(GetInput);
        story = storyText.text;
        

    }


    

    public void UpdateStory(string msg)
    {
        
            
                story += "\n" + msg;
                storyText.text = story;
         
    }
    void GetInput(string msg)
    {
        if (msg != "")
        {
            char[] splitInfo = { ' ' };
            string[] parts = msg.ToLower().Split(splitInfo); //['go', 'north']

            if (commands.Contains(parts[0])) // if valid command
            {
                if (parts[0] == "go") // wants to switch rooms
                {
                    if (NavigationManager.instance.SwitchRooms(parts[1])) //returns true if direction exists
                    {

                    }
                    else
                    {
                        //added the "is locked element response""
                        UpdateStory("Exit does not exist or is locked. Try again.");
                    }
                }
                else if (parts[0] == "get") // wants to switch rooms
                {
                    if (NavigationManager.instance.TakeItem(parts[1])) //returns true if direction exists
                    {
                        GameManager.instance.inventory.Add(parts[1]);
                        UpdateStory("You added a(n)" + parts[1] + " to your inventory");
                    }
                    else
                    {
                        UpdateStory("Sorry, " + parts[1] + "does not exist in this room");
                    }
                }
                else if (parts[0] =="restart")
                {
                    if (onRestart != null) //if anyone is listening
                    {
                        onRestart(); //invoke the event
                    }
                }
                //UpdateStory(msg);
            }
            
        }

        //reset for next input
        userInput.text = ""; //after input from user used, reset
        userInput.ActivateInputField();
    }
}
