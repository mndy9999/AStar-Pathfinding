using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

    ButtonsManager buttons;

    private void OnMouseDown()
    {
        buttons = Component.FindObjectOfType<ButtonsManager>();
        if (Input.GetMouseButtonDown(0) && buttons.activeButton == buttons.buttons[3])
        {
            Destroy(gameObject);
        }
    }
}
