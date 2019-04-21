using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSelector : MonoBehaviour
{

    public Selectable CurrButton;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
           Selectable temp = CurrButton.FindSelectableOnDown();
            if (temp != null)
            {
                CurrButton = temp;
                CurrButton.Select();
                
            }
            
        }

        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            Selectable temp = CurrButton.FindSelectableOnUp();
            if (temp != null)
            {
                CurrButton = temp;
                CurrButton.Select();
            }
        }
    }




}
