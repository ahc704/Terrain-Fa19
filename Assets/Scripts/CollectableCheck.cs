using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectableCheck : MonoBehaviour
{
    private int count;
    public Text countText;
    public Text interactText;
    public Text strongholdText;

    void Awake()
    {
        count = 0;
        interactText.text = "";
        countText.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            setInteractText("Press [E] to Interact");
            if (Input.GetKeyDown("e"))
            {
                other.gameObject.SetActive(false);
                setCountText();
            }
            setInteractText("Wonder if there's anything else");

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
            strongholdText.text = "Stronghold has been revealed";
        }
    }
}
