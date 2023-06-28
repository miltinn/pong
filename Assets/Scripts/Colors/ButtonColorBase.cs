using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))] //requer um componente do tipo Image
public class ButtonColorBase : MonoBehaviour
{
    public Color color;

    [Header("References")]
    public Image uiImage;

    public Player myPlayer;

    private void OnValidate() //ao adicionar o script em algum item, a função é executada
    {
        uiImage = GetComponent<Image>();
    }

    void Start()
    {
        uiImage.color = color;

        //GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        myPlayer.ChangeColor(color);
    }

}
