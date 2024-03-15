using CustomEventBus;
using CustomEventBus.Signals;


public class ScoreManager : IService, IDisposable
{
    private int _goldCount;
    private int _silverCount;
    private int _generalCount;
    private EventBus _eventbus;

    /// <summary>
    /// Update count of resources and UI
    /// </summary>
    public void Initialization()
    {
        _goldCount = _silverCount = _generalCount = 0;

        _eventbus = ServiceLocator.Current.Get<EventBus>();

        _eventbus.Subscribe<PressGoldenButtonSignal> (ChangeGoldCount);
        _eventbus.Subscribe<PressSilverButtonSignal> (ChangeSilverCount);
       
        UpdateAllUISignal();
    }

    /// <summary>
    /// send event to update all UI
    /// </summary>
    private void UpdateAllUISignal()
    {
        _eventbus?.Invoke(new UpdateGoldSignal(_goldCount));
        _eventbus?.Invoke(new UpdateSilverSignal(_silverCount));
        _eventbus?.Invoke(new UpdateGeneralResourceSignal(_generalCount));
    }    

    public void ChangeGoldCount(PressGoldenButtonSignal signal)
    {
        _eventbus?.Invoke(new UpdateGoldSignal(++_goldCount));
        _eventbus?.Invoke(new UpdateGeneralResourceSignal(++_generalCount));
    }
    public void ChangeSilverCount(PressSilverButtonSignal signal)
    {
        _eventbus?.Invoke(new UpdateSilverSignal(++_silverCount));
        _eventbus?.Invoke(new UpdateGeneralResourceSignal(++_generalCount));
    }

    public void Dispose()
    {
        _eventbus.Unsubscribe<PressGoldenButtonSignal>(ChangeGoldCount);
        _eventbus.Unsubscribe<PressSilverButtonSignal>(ChangeSilverCount);
    }

}
