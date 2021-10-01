using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public int ID;
    public int quantity;
    public TextMeshProUGUI quantityText;
    public bool clicked = false;
    private LevelEditorManager levelEditorManager;

    void Start()
    {
        quantityText.text = quantity.ToString();
        levelEditorManager = GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
    }

    public void ButtonClicked()
    {
        if (quantity > 0)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            clicked = true;
            Instantiate(levelEditorManager.ItemImage[ID], new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);

            quantity--;
            quantityText.text = quantity.ToString();
            levelEditorManager.CurrentButtonPressed = ID;
        }
    }
}
