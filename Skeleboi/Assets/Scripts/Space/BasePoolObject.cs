using System;
using UnityEngine;

/// <summary>
/// Base class for any pooled object.
/// </summary>
public class BasePoolObject : MonoBehaviour
{
    // Object's current lifetime.
    public float m_currentLifeTime = 0f;
    // Lifetime timer.
    public float m_startLifeTime = 0f;
    // Object's total lifetime.
    public float m_lifeTime = 5f;
    // Pool index.
    public int m_index = 0;

    // Event which is fired when lifetime is reached.
    public delegate void OnLifeTimeHandler(int index);
    public event OnLifeTimeHandler OnLifeTime;
    
    private void Update()
    {
        // If lifetime is reached, fire OnLifeTime event.
        m_currentLifeTime = Time.realtimeSinceStartup - m_startLifeTime;
        if (m_currentLifeTime > m_lifeTime)
        {
            SendOnLifeTimeEvent();
        }
    }

    /// <summary>
    /// Send OnLifeTime event.
    /// </summary>
    public void SendOnLifeTimeEvent()
    {
        // Event may not be initialized. So you need to check it or
        // game may crash.
        if (OnLifeTime != null)
        {
            OnLifeTime(m_index);
        }
    }
}
