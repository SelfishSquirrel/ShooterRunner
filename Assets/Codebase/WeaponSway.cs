using System;
using UnityEngine;

namespace Codebase
{
    public class WeaponSway : MonoBehaviour
    {
        [SerializeField] private float _swayClamp = 0.09f;
        [SerializeField] private float _smoothing = 3f;

        private Vector3 _origin;

        private void Start()
        {
            _origin = transform.localPosition;
        }

        private void Update()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            
            input.x = Mathf.Clamp(input.x, -_swayClamp, _swayClamp);
            input.y = Mathf.Clamp(input.y, _swayClamp, _swayClamp);
            
            Vector3 target = new Vector3(-input.x, -input.y, 0f);

            transform.localPosition = Vector3.Lerp(transform.localPosition, target + _origin, Time.deltaTime * _smoothing);
        }
    }
}