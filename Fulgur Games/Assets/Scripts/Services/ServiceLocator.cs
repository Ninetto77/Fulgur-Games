using UnityEngine;
using CustomEventBus;
using System;
using System.Collections.Generic;

public class ServiceLocator
{
    public EventBus eventBus;
    private Dictionary<string, IService> _serveices = new Dictionary<string, IService>();

    public static ServiceLocator Current { get; private set; }
    public static void Initialization()
    {
        Current = new ServiceLocator();
    }

    /// <summary>
    /// Get current service
    /// </summary>
    /// <typeparam name="T">name of service</typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public T Get<T>() where T: IService
    {
        string key = typeof(T).Name;
        if (!_serveices.ContainsKey(key))
        {
            Debug.LogError($"{key} not registered with {GetType().Name}");
            throw new InvalidOperationException();
        }
        else return (T)_serveices[key];
    }

    /// <summary>
    /// Add service in current servicelocator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="service"></param>
    public void Register<T>(T service) where T : IService
    {
        string key = typeof(T).Name;
        if (_serveices.ContainsKey(key))
        {
            Debug.LogError(
                           $"Attempted to register " +
                           $"service of type {key} which is already registered" +
                           $" with the {GetType().Name}.");
            return;
        }
        _serveices.Add(key, service);
    }

    /// <summary>
    /// Delete service in current servicelocator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="service"></param>
    public void Unregister<T>() where T : IService
    {
        string key = typeof(T).Name;
        if (!_serveices.ContainsKey(key))
        {
            Debug.LogError(
                           $"Attempted to unregister " +
                           $"service of type {key} which is not registered" +
                           $" with the {GetType().Name}.");
            return;
        }
        _serveices.Remove(key);
    }
}
