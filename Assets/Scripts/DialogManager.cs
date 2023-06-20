using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public Canvas canvas;

Message[] currentMessages;
Actor[] currentActors;
int activeMessage = 0;
public static bool isActive = false;

public void OpenDialog(Message[] messages, Actor[] actors){
    currentMessages = messages;
    currentActors = actors;
    activeMessage = 0;
    isActive = true;

    Debug.Log("Started Convo. Number of message: " + messages.Length); 
    DisplayMessage();
    canvas.enabled = true;
    
}
void DisplayMessage(){
    Message messageToDisplay = currentMessages [activeMessage];
    messageText.text= messageToDisplay.message;

    Actor actorToDisplay = currentActors[messageToDisplay.actorId];
    actorName.text = actorToDisplay.name;
    actorImage.sprite = actorToDisplay.sprite;
}

public void NextMessage() {
    activeMessage++;
    if (activeMessage <currentMessages.Length){
        DisplayMessage();
    } else {
        Debug.Log("Conversation end");
        canvas.enabled = false;
        isActive = false;
    }
}



    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true){
            NextMessage();
        }
    }
}
