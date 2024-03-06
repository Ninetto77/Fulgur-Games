using System;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{
    public TypeOfResource TypeResource;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        switch(TypeResource)
        {
            case TypeOfResource.gold:
                GameManager.OnGoldCountChange?.Invoke();
                break;
            case TypeOfResource.silver:
                GameManager.OnSilverCountChange?.Invoke();
                break;
        }
    }

    /// <summary>
    /// Selects which resource to increase
    /// </summary>
    public enum TypeOfResource
    {
        gold,
        silver
    }
}
