using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : MonoBehaviour
{
    public int ID;
    private LevelEditorManager levelEditorManager;

    void Start()
    {
        levelEditorManager = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Destroy(this.gameObject);
            levelEditorManager.ItemButtons[ID].quantity++;
            levelEditorManager.ItemButtons[ID].quantityText.text = levelEditorManager.ItemButtons[ID].quantity.ToString();
        }
    }
}
