using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SlotGame
{
    public class Wheel : MonoBehaviour
    {
        public class WeightedValue
        {
            public int Value;
            public int Weight;

            public WeightedValue(CombinationType  combinationType, int weight)
            {
                Value = ((int)combinationType);
                Weight = weight;
            }
        }

        public List<WeightedValue> PricesWithWeights = new List<WeightedValue>
{
    new WeightedValue(CombinationType.All_H,        5),
    new WeightedValue(CombinationType.All_UH,        5),
    new WeightedValue(CombinationType.All_X,        5),
    new WeightedValue(CombinationType.H2_UH1,        10),
    new WeightedValue(CombinationType.H1_UH2,        10),
    new WeightedValue(CombinationType.H2_X,        10),
    new WeightedValue(CombinationType.UH2_X,        10),
    new WeightedValue(CombinationType.H_X2,        10),
    new WeightedValue(CombinationType.UH_X2,        10),
    new WeightedValue(CombinationType.RANDOM,        25),
    
};

       
        public float SpinDuration = .5f;

        private readonly List<int> _weightedList = new List<int>();

        private bool _spinning;
        private float _anglePerItem;

        private void OnEnable()
        {
            _spinning = false;
            _anglePerItem = 360f / PricesWithWeights.Count;

            foreach (var kvp in PricesWithWeights)
            {
                for (var i = 0; i < kvp.Weight; i++)
                {
                    _weightedList.Add(kvp.Value);
                }
            }
        }

        public int GetRandomNumber()
        {
            var randomIndex = Random.Range(0, _weightedList.Count);
            return _weightedList[randomIndex];
        }

        private void Update()
        {
            if (_spinning) return;

            var randomTime = 0f;
            var itemNumber = GetRandomNumber();

            var itemIndex = PricesWithWeights.FindIndex(w => w.Value == itemNumber);
            var itemNumberAngle = itemIndex * _anglePerItem;
            var currentAngle = GetComponent<RectTransform>().eulerAngles.z;
            while (currentAngle >= 360)
            {
                currentAngle -= 360;
            }
            while (currentAngle < 0)
            {
                currentAngle += 360;
            }

            
            var targetAngle = -(itemNumberAngle + 360f * randomTime);
           

            StartCoroutine(SpinTheWheel(currentAngle, targetAngle, randomTime * SpinDuration, itemNumber));
        }       
        private IEnumerator SpinTheWheel(float fromAngle, float toAngle, float withinSeconds, int result)
        {
            _spinning = true;

            var passedTime = 0f;
            while (passedTime < withinSeconds)
            {
                
                var lerpFactor = Mathf.SmoothStep(0, 1, (Mathf.SmoothStep(0, 1, passedTime / withinSeconds)));

                GetComponent<RectTransform>().localEulerAngles = new Vector3(0.0f, 0.0f, Mathf.Lerp(fromAngle, toAngle, lerpFactor));
                passedTime += Time.deltaTime;

                yield return null;
            }

            GetComponent<RectTransform>().eulerAngles = new Vector3(0.0f, 0.0f, toAngle);
            

            //Debug.Log("Prize: " + result);
            GameManager.Instance.GetResultCombination(result);
            _spinning = true;
            StartCoroutine(LeftWheelRotation.Instance.SetNumber(0));
            StartCoroutine(RightWheelRotation.Instance.SetNumber(0));
            StartCoroutine(MiddleWheelRotation.Instance.SetNumber(0));
            GameManager.Instance.setResult();
        }
    }
}