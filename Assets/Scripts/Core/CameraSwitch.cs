using Cinemachine;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CameraSwitch : MonoBehaviour
    {
        private CinemachineVirtualCamera _characterCamera;
        [SerializeField] private float  _switchTime;

        private void Start()
        {
            _characterCamera = GetComponent<CinemachineVirtualCamera>(); 
        }

        private void FixedUpdate()
        {
            if(Time.time > _switchTime)
            {
                _characterCamera.Priority = 3;
            }
        }
    }
}