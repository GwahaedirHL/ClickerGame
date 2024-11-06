using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class CountdownTimer : ITickable
    {
        float initialTime;
        float timeRemaining;
        public bool IsRunning { get; private set; }
        public event Action OnTimerCompleted;

        public void StartTimer(float time)
        {
            initialTime = time;
            timeRemaining = time;
            IsRunning = true;
        }

        public void Tick()
        {
            if (IsRunning && timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                if (timeRemaining <= 0)
                {
                    IsRunning = false;
                    OnTimerCompleted?.Invoke();
                    RestartTimer();
                }
            }
        }

        private void RestartTimer()
        {
            timeRemaining = initialTime;
            IsRunning = true;
        }
    }
}