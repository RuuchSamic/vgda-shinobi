using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITools : MonoBehaviour
{

    public GameObject tool1; // the selectors ontop of the associated tools
    public GameObject tool2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") == true) 
        {
            tool2.SetActive(false); // remove the selection on tool2
            tool1.SetActive(true); // select tool 1

        }

        if (Input.GetKeyDown("2") == true)
        {
            tool1.SetActive(false);
            tool2.SetActive(true);
        }

    }
}
