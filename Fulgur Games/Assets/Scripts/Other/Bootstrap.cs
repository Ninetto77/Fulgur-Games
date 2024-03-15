using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ServicesLocator_Main services;

    void Awake()
    {
        services.Initialization();
    }

}