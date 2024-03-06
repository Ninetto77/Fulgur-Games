using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Action OnGoldCountChange;
    public static Action OnSilverCountChange;

    public const string GOLD_STRING = "Gold: ";   
    public const string SILVER_STRING = "Silver: ";   
    public const string GENERAL_STRING = "General score: ";   

    [SerializeField] private Text _goldenText;
    [SerializeField] private Text _silverText;
    [SerializeField] private Text _generalText;

    private int _goldCount;
    private int _silverCount;
    private int _generalCount;
    void Start()
    {
        Initialization();
    }

    /// <summary>
    /// Update count of resources and UI
    /// </summary>
    private void Initialization()
    {
        _goldCount = _silverCount = _generalCount = 0;

        OnGoldCountChange += UpdateGoldCount;
        OnSilverCountChange += UpdateSilverCount;

        UpdateAllUI();
    }

    /// <summary>
    /// Update all UI
    /// </summary>
    private void UpdateAllUI()
    {
        _goldenText.text = GOLD_STRING + _goldCount.ToString();
        _silverText.text = SILVER_STRING + _silverCount.ToString();
        _generalText.text = GENERAL_STRING + _generalCount.ToString();
    }

    /// <summary>
    /// Update Gold Count including UI
    /// </summary>
    private void UpdateGoldCount()
    {
        _goldCount++;
        _goldenText.text = GOLD_STRING + _goldCount.ToString();

        UpdateGeneralCount();
    }

    /// <summary>
    /// Update Silver Count including UI
    /// </summary>
    private void UpdateSilverCount()
    {
        _silverCount++;
        _silverText.text = SILVER_STRING + _silverCount.ToString();
        UpdateGeneralCount();
    }

    /// <summary>
    /// Update General Count including UI
    /// </summary>
    private void UpdateGeneralCount()
    {
        _generalCount++;
        _generalText.text = GENERAL_STRING + _generalCount.ToString();
    }

    private void OnDisable()
    {
        OnGoldCountChange -= UpdateGoldCount;
        OnSilverCountChange -= UpdateSilverCount;
    }

}
