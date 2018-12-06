using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{

    public GameObject[] objects;
    public ButtonsManager buttons;

    public Transform waterParent;

    private void Start()
    {
        waterParent = GameObject.Find("Water").transform;
    }

    private void Update()
    {
        if (buttons.getActiveButton() && Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 pos = new Vector3(Mathf.RoundToInt(objectPos.x), Mathf.RoundToInt(objectPos.y));
            Debug.Log("Hi");
            for (int i = 0; i < objects.Length; i++)
            {
                if (buttons.activeButton == buttons.buttons[i]) Instantiate(objects[i], pos, Quaternion.identity, waterParent);
            }



        }
    }

}
