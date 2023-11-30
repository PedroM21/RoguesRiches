using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescDisplay : MonoBehaviour
{
    public Item item;

    public Text nameText;
    public Text descriptionText;
    public Image artworkImage;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        nameText.text = item.name;
        descriptionText.text = item.description;
        artworkImage.sprite = item.artwork;

        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}
