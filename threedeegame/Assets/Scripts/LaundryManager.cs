using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaundryManager : MonoBehaviour
{
    public static LaundryManager LM;


    public Text dialogueBox;
    public Text laundryCountUI;

    public bool laundryWashed;
    public bool laundryDryed;
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
        
        //start laundry as unwashed, not dry, dialogue to 0
        laundryWashed = false;
        laundryDryed = false;
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
        if (objectType == 0)//Game Over, laundry finished   
        {
            dialogueBox.text = laundryDialogue[0];
        }
        else if (objectType == 1)//Sushi
        {
            dialogueBox.text = sushiDialogue[Random.Range(0,sushiDialogue.Length)];
        }
        else if (objectType == 2)//Inari
        {
            dialogueBox.text = inariDialogue[Random.Range(0,inariDialogue.Length)];
        }
        else if(objectType == 3)//Coffee           
        {
            dialogueBox.text = coffeeDialogue[Random.Range(0,coffeeDialogue.Length)];
        }
                
            
    }
    
    public void GotLaundry(GameObject laundry)
    {
        Destroy(laundry);
        laundryCounter++;
        UpdateLaundryCountUI();
        UpdateDialogueUI();
        if (transform.childCount < 1)
        {
            laundryCounter++;
            UpdateDialogueUI();
            laundryWashed = true;
        }
    }
    
    public void GotWasher()
    {
        if (transform.childCount < 1)
        {
            laundryWashed = true;
            dialogueBox.text = "Now for the dryer.";
        }
        else
        {
            dialogueBox.text = "I need to grab all my clothes before starting the washer.";
        }
    }
    public void GotDryer()
    {
        if (transform.childCount < 1 && laundryWashed)
        {
            laundryDryed = true;
            DoneWithLaundry();
        }
        else if(transform.childCount<1 && !laundryWashed)
        {
            dialogueBox.text = "I have to put all my clothes in the washer before drying them.";
        }
        else
        {
            dialogueBox.text = "I need to wash all my clothes before starting the dryer.";
        }
    }
    
    void DoneWithLaundry()
    {
        UpdateDialogueUI(0);
        Debug.Log("Did the laundry");
    }
    
}
