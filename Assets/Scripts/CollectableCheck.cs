using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectableCheck : MonoBehaviour
{
    private int count;
    public Text countText;
    public Text interactText;
    public Text eventText;

    void Awake()
    {
        count = 0;
        interactText.text = "What is this place?";
        countText.text = "";
        eventText.text = "Objective: Explore the Wasteland";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            if (count < 1)
            {
                print("Collision Occured");
                other.gameObject.SetActive(false);
                setCountText();
                setInteractText("What's this? Wonder if there's anything else...");
                createPathways(count);
            }
        }
        if(other.tag == "Collectable2")
        {
            if (count == 1)
            {
                print("Collision 2 Occured");
                other.gameObject.SetActive(false);
                setCountText();
                setInteractText("Another one? What do they lead to?");
                createPathways(count);
            }
        }
    }

    void createPathways(int c)
    {
        GameObject[] pathwayArray;

        if(c == 1)
        {
            pathwayArray = GameObject.FindGameObjectsWithTag("Spotlight1");
            foreach (GameObject go in pathwayArray)
            {
                go.SetActive(false);
            }
        }
        if (c == 2)
        {
            pathwayArray = GameObject.FindGameObjectsWithTag("Spotlight2");
            foreach (GameObject go in pathwayArray)
            {
                go.SetActive(false);
            }
        }
    }

    void setInteractText(string S)
    {
        interactText.text = S;
    }

    void setCountText()
    {
        count += 1;
        countText.text = "Collected:" + count.ToString() + "/3";
        if(count >= 3)
        {
            eventText.text = "Stronghold has been revealed";
        }
    }
}
