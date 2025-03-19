using System.Collections;
using UnityEngine;
namespace SlotGame
{
    public class MiddleBackGroundMovment : MonoBehaviour
    {
        [HideInInspector] public float speed;

        public float upperY = -20;
        public float defaultPosition;
        private RectTransform _transform;
        public bool IsSpin = false;
        [SerializeField] private MiddleWheelRotation WheelRotation;
        [SerializeField] private Vector3 Vector3;
        public float offset = 0;
        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
            Vector3 = _transform.localPosition;
        }

        public void StartSpin()
        {
            _transform.localPosition = Vector3;
            StartCoroutine(BackGround());
        }

        public void StopSpin()
        {
            StopCoroutine(BackGround());
        }
        IEnumerator BackGround()
        {
            while (true)
            {
                float nextExpectedPosition = _transform.localPosition.y - (WheelRotation.speed * .05f);
                if (WheelRotation.Spin)
                {
                    if (nextExpectedPosition <= upperY)
                    {
                        nextExpectedPosition = -(upperY) - (Mathf.Abs(nextExpectedPosition) - Mathf.Abs(upperY));
                    }
                    _transform.localPosition = new Vector3(_transform.localPosition.x, nextExpectedPosition, _transform.localPosition.z);

                    yield return null;
                }
                if (IsSpin)
                {
                    if (nextExpectedPosition <= 0.01f)
                    {
                        WheelRotation.OffSet = _transform.localPosition.y;
                        WheelRotation.Spin = false;
                        IsSpin = false;
                    }
                }

                yield return null;
            }
        }
    }
}