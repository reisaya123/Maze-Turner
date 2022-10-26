using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    public void NotHovering()
    {
        transform.GetComponent<Image>().color = new Color32(80, 40, 40, 255);
    }

    public void Hovering()
    {
        transform.GetComponent<Image>().color = new Color32(171, 73, 73, 255);

    }
}
