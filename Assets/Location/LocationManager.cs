using System;
using Core;
using UnityEngine;

namespace Location
{
    public class LocationManager : Singleton<LocationManager>
    {
        [SerializeField] private string defaultLocation;
        
        public event Action OnLocationChanged;

        private string _location;
        public string Location {
            get => _location;
            set {
                _location = value;
                OnLocationChanged?.Invoke();
            }
        }

        public void ResetLocation() {
            Location = defaultLocation;
        }

        protected override void Awake() {
            base.Awake();

            ResetLocation();
        }
    }
}