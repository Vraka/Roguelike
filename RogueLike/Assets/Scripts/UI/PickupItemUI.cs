using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItemUI : MonoBehaviour {

    public Image panel;
    public Text itemname;
    public Text itemdesc;

	// Use this for initialization
	void Start () {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
        itemname.color = new Color(itemname.color.r, itemname.color.g, itemname.color.b, 0);
        itemdesc.color = new Color(itemdesc.color.r, itemdesc.color.g, itemdesc.color.b, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pickupItem(string name, string desc)
    {
        itemname.text = name;
        itemdesc.text = desc;
        StartCoroutine(ItemPickup());
    }

    private IEnumerator ItemPickup()
    {
        yield return StartCoroutine(Fade(0, 1, .75f));
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(Fade(1, 0, .75f));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        // keep track of when the fading started, when it should finish, and how long it has been running&lt;/p&gt; &lt;p&gt;&a
        var startTime = Time.time;
        var endTime = Time.time + duration;
        var elapsedTime = 0f;

        // set the canvas to the start alpha – this ensures that the canvas is ‘reset’ if you fade it multiple times
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, startAlpha);
        itemname.color = new Color(itemname.color.r, itemname.color.g, itemname.color.b, startAlpha);
        itemdesc.color = new Color(itemdesc.color.r, itemdesc.color.g, itemdesc.color.b, startAlpha);
        // loop repeatedly until the previously calculated end time
        while (Time.time <= endTime)
        {
            elapsedTime = Time.time - startTime; // update the elapsed time
            var percentage = 1 / (duration / elapsedTime); // calculate how far along the timeline we are
            if (startAlpha > endAlpha) // if we are fading out/down 
            {
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, startAlpha - percentage);
                itemname.color = new Color(itemname.color.r, itemname.color.g, itemname.color.b, startAlpha - percentage);
                itemdesc.color = new Color(itemdesc.color.r, itemdesc.color.g, itemdesc.color.b, startAlpha - percentage);
                // calculate the new alpha
            }
            else // if we are fading in/up
            {
                panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, startAlpha + percentage);
                itemname.color = new Color(itemname.color.r, itemname.color.g, itemname.color.b, startAlpha + percentage);
                itemdesc.color = new Color(itemdesc.color.r, itemdesc.color.g, itemdesc.color.b, startAlpha + percentage);
                // calculate the new alpha
            }

            yield return new WaitForEndOfFrame(); // wait for the next frame before continuing the loop
        }
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, endAlpha);
        itemname.color = new Color(itemname.color.r, itemname.color.g, itemname.color.b, endAlpha);
        itemdesc.color = new Color(itemdesc.color.r, itemdesc.color.g, itemdesc.color.b, endAlpha);
        // force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
    }
}
