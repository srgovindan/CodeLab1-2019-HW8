using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaundryManager : MonoBehaviour
{
    public static LaundryManager LM;


    public Text dialogueBox;
    public Text laundryCountUI;

    private int laundryCounter;
    public string[] laundryDialogue;
    public string[] coffeeDialogue;
    public string[] sushiDialogue;
    public string[] inariDialogue;
    
    void Start()
    {
        // SINGLETON 
        if (LM == null)
        {
            DontDestroyOnLoad(gameObject);
            LM = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //start laundry dialogue to 0
        laundryCounter = 0;
        UpdateLaundryCountUI();

    }

    void UpdateLaundryCountUI()
    {
        laundryCountUI.text = "    Laundry Collected: " + laundryCounter;
    }
    
    void UpdateDialogueUI()
    {
        dialogueBox.text = laundryDialogue[laundryCounter];
    }

    public void UpdateDialogueUI(int objectType)
    {
        if (objectType == 0)//Coffee
        {
            dialogueBox.text = coffeeDialogue[Random.Range(0,coffeeDialogue.Length)];
        }
        else if (objectType == 1)//Sushi
        {
            dialogueBox.text = sushiDialogue[Random.Range(0,sushiDialogue.Length)];
        }
        else if (objectType == 2)//Inari
        {
            dialogueBox.text = inariDialogue[Random.Range(0,inariDialogue.Length)];
        }
    }

    public void GotWasher()
    {
        //TODO:check if all laundry collected
    }

    public void GotDryer()
    {
        //TODO: check if laundry washed 
    }
    
    public void GotLaundry(GameObject laundry)
    {
        Destroy(laundry);
        laundryCounter++;
        UpdateLaundryCountUI();
        UpdateDialogueUI();
        if (transform.childCount < 1)
        {
            //game over
            //TODO: dialogue should send you to the washer
        }
    }

    void DoneWithLaundry()
    {
        //TODO:do game over things here
        Debug.Log("Did the laundry");
    }
    
}
