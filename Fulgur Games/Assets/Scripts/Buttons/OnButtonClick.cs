using CustomEventBus;
using CustomEventBus.Signals;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{
    public TypeOfResource TypeResource;
    private Button _button;
    private EventBus _eventbus;

    void Start()
    {
        _eventbus = ServiceLocator.Current.Get<EventBus>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        switch(TypeResource)
        {
            case TypeOfResource.gold:
                _eventbus?.Invoke(new PressGoldenButtonSignal());
                break;
            case TypeOfResource.silver:
                _eventbus?.Invoke(new PressSilverButtonSignal());
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
