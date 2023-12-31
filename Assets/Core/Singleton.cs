﻿using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this);
            }
            else {
                Instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}