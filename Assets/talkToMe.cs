using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkToMe : MonoBehaviour
{
    public GameObject player;
    public GameObject dialogueBox;

    bool playerIsLookingAtMe() {
        // Check if player is looking at this gameobject.
        // If they are, return true.
        // If they are not, return false.

        // Get the player's position.
        Vector3 playerPosition = player.transform.position;

        // Get the direction from the player to this gameobject.
        Vector3 direction = transform.position - playerPosition;

        // Get the angle between the player's forward vector and the direction from the player to this gameobject.
        float angle = Vector3.Angle(player.transform.forward, direction);

        // If the angle is less than 30 degrees, then the player is looking at this gameobject.
        if (angle < 30 && direction.magnitude < 5) {
            return true;
        } else {
            return false;
        }

    }

    private bool notTalking = true;
    private bool callOnce = true;

    // Update is called once per frame
    void Update()
    {

        // When players look at this gameobject, a "Press E to talk" prompt appears.
        // If they press E to talk, a talking dialogue box appears. 

        // Check if player is looking at this gameobject.
        bool isLookingAtMe = playerIsLookingAtMe();

        if (isLookingAtMe && notTalking)
        {
            dialogueBox.SetActive(true);
            dialogueBox.GetComponent<Text>().text = "Press E to talk.";

        } else if(!isLookingAtMe && notTalking) {
            dialogueBox.SetActive(false);
        }

        // If the player is looking at this gameobject, and presses E, then the dialogue box appears.
        if (Input.GetKeyDown(KeyCode.E))
        {
            // If the player is looking at this gameobject, then the dialogue box appears.
            if (isLookingAtMe)
            {
                notTalking = false;

                // Dialogue box appears.
                // accsess the UI element and make it visible.
                dialogueBox.SetActive(true);

                // Set the text of the dialogue box to the text of the gameobject.
                dialogueBox.GetComponent<Text>().text = "hi!";


                // Make a call to https://localhost:5000/chat?q=Pretend you are a traveler guiding adventurers. Give me some advice!
                // and get the response from the API.
                // Set the text of the dialogue box to the response from the API.

                // Make a network request to the API.
                // https://docs.unity3d.com/ScriptReference/WWW.html
                if(callOnce) {
                    StartCoroutine(GetText());
                    callOnce = false;
                }

            }
        }


        
    }

    IEnumerator GetText()
    {
        // This is a coroutine.
        // https://docs.unity3d.com/Manual/Coroutines.html
        Debug.Log("Getting text from API...");
        // Make a network request to the API.
        // https://docs.unity3d.com/ScriptReference/WWW.html
        WWW www = new WWW("https://localhost:5000/chat?q=Pretend you are a traveler guiding adventurers. Give me some advice!");
        yield return www;

        // Debug the network request.
        Debug.Log(www.text);
        

        // Set the text of the dialogue box to the response from the API.
        dialogueBox.GetComponent<Text>().text = www.text;
    }
}
