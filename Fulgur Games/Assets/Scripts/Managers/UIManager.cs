using UnityEngine;
using UnityEngine.UI;
using CustomEventBus;
using CustomEventBus.Signals;

public class UIManager : MonoBehaviour, IService, IDisposable
{
    public const string GOLD_STRING = "Gold: ";
    public const string SILVER_STRING = "Silver: ";
    public const string GENERAL_STRING = "General score: ";

    [SerializeField] private Text _goldenText;
    [SerializeField] private Text _silverText;
    [SerializeField] private Text _generalText;

    private EventBus _eventbus;

    public void Initialization()
    {
        _eventbus = ServiceLocator.Current.Get<EventBus>();

        _eventbus.Subscribe<UpdateGoldSignal>(UpdateGoldCount);
        _eventbus.Subscribe<UpdateSilverSignal>(UpdateSilverCount);
        _eventbus.Subscribe<UpdateGeneralResourceSignal>(UpdateGeneralCount);
    }

    /// <summary>
    /// Update Gold Count including UI
    /// </summary>
    private void UpdateGoldCount(UpdateGoldSignal signal)
    {
        int goldCount = signal.GoldCount;
        _goldenText.text = GOLD_STRING + goldCount.ToString();
    }

    /// <summary>
    /// Update Silver Count including UI
    /// </summary>
    private void UpdateSilverCount(UpdateSilverSignal signal)
    {
        int silverCount = signal.SilverCount;
        _silverText.text = SILVER_STRING + silverCount.ToString();
    }

    /// <summary>
    /// Update General Count including UI
    /// </summary>
    private void UpdateGeneralCount(UpdateGeneralResourceSignal signal)
    {
        int generalCount = signal.GeneralCount;
        _generalText.text = GENERAL_STRING + generalCount.ToString();
    }

    public void Dispose()
    {
        _eventbus.Unsubscribe<UpdateGoldSignal>(UpdateGoldCount);
        _eventbus.Unsubscribe<UpdateSilverSignal>(UpdateSilverCount);
        _eventbus.Unsubscribe<UpdateGeneralResourceSignal>(UpdateGeneralCount);
    }

}
