using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// NameSpace of Game
namespace SlotGame
{
    public class GameManager : Singleton<GameManager>
    {
        public Action resultCheck;
        /// <summary>
        /// All Food Items Data
        /// </summary>
        [SerializeField] private List<SlotItemData> allFoodItems;
        /// <summary>
        /// All healthy Food Items Data
        /// </summary>
        [SerializeField] private List<SlotItemData> healthyFoodItems;
        /// <summary>
        /// All unhealthy Food Items Data
        /// </summary>
        [SerializeField] private List<SlotItemData> unhealthyFoodItems;
        /// <summary>
        /// None Items Data
        /// </summary>
        [SerializeField] private SlotItemData crossData = new SlotItemData();
        /// <summary>
        /// All images of slot machine
        /// </summary>
        [SerializeField] private List<Image> slotMainImages;
        /// <summary>
        /// Spin rotation time gap
        /// </summary>
        [Range(0, 10)]
        [SerializeField] private float maxTimeGap;
        /// <summary>
        /// spinButton using for spin funtionality
        /// </summary>
        [SerializeField] public Button spinButton;
        /// <summary>
        /// Slotmachine Rotator
        /// </summary>
        [SerializeField] private GameObject wheel;
        /// <summary>
        /// Remaining Spin count Text
        /// </summary>
        [SerializeField] private TMP_Text spinCount_Text;
        /// <summary>
        /// counter of spin
        /// </summary>
        public int SpinCount = 27;
        /// <summary>
        /// Winning data of spiining
        /// </summary>
        private List<SlotItemData> winningData = new List<SlotItemData>();
        [SerializeField] private List<Image> winningImages = new List<Image>();
        [SerializeField] private GameObject winningPopup;
        public GameObject overlay;

        protected override void Awake()
        {
            if (!PlayerPrefs.HasKey(Constants.SpinCount))
            {
                PlayerPrefs.SetInt(Constants.SpinCount, SpinCount);
            }
        }

        private void Start()
        {
            overlay.SetActive(false);
            SpinCount = PlayerPrefs.GetInt(Constants.SpinCount);
            spinCount_Text.text = "Remaining Spin : " + SpinCount.ToString();
            for (int i = 0; i < slotMainImages.Count; i++)
            {
                int randomItems = UnityEngine.Random.Range(0, allFoodItems.Count);
                slotMainImages[i].sprite = allFoodItems[randomItems].slotItemImage;
            }
        }

        public void AddSpinButtonClick()
        {
            SpinCount += 10;
            PlayerPrefs.SetInt(Constants.SpinCount, SpinCount);
            spinCount_Text.text = "Remaining Spin : " + SpinCount.ToString();
        }

        /// <summary>
        /// Using for Spin the slot machine
        /// </summary>
        public void SpinSlotMachine()
        {
            Handheld.Vibrate();
            if (SpinCount > 0)
            {
                overlay.SetActive(true);
                SpinCount -= 1;
                PlayerPrefs.SetInt(Constants.SpinCount, SpinCount);
                spinCount_Text.text = "Remaining Spin : " + SpinCount.ToString();
                wheel.SetActive(true);
                spinButton.interactable = false;
                StartCoroutine(changeBlurImage());
            }
        }

        /// <summary>
        /// Use for Change changing the blur images
        /// </summary>
        /// <returns> time gape for every image change </returns>
        private IEnumerator changeBlurImage()
        {
            yield return new WaitForSeconds(maxTimeGap);
            wheel.SetActive(false);
        }

        /// <summary>
        /// Set the reslut after spinng 
        /// </summary>
        public void setResult()
        {
            int counter = 0;
            for (int i = 0; i < slotMainImages.Count; i++)
            {
                int randomItems = UnityEngine.Random.Range(0, allFoodItems.Count);
                slotMainImages[i].sprite = allFoodItems[randomItems].slotItemImage;

                if (i == 0 || i == 3 || i == 6)
                {
                    slotMainImages[i].sprite = winningData[counter].slotItemImage;
                    counter += 1;
                }
            }
            for (int i = 0; i < winningImages.Count; i++)
            {
                winningImages[i].sprite = winningData[i].slotItemImage;
            }
            Invoke(nameof(Result), 3f);
        }

        private void Result()
        {
            winningPopup.SetActive(true);
            spinButton.interactable = true;
            overlay.SetActive(false);
        }

        public void OnCloseButtonClick()
        {
            winningPopup.SetActive(false);
        }

        /// <summary>
        /// this method used for result combination. Combinations are below
        /// All_H = 0,
        ///All_UH = 1,
        ///All_X = 2,
        ///H2_UH1 = 3,
        ///H1_UH2 = 4,
        ///H2_X = 5,
        ///UH2_X = 6,
        ///H_X2 = 7,
        ///UH_X2 = 8,
        ///RANDOM = 9
        /// </summary>
        /// <param name="resultNo"></param>
        public void GetResultCombination(int resultNo)
        {
            if (winningData.Count > 0)
            {
                winningData.Clear();
            }
            for (int i = 0; i < 3; i++)
            {
                switch (resultNo)
                {
                    case 0:
                        winningData.Add(healthyFoodItems[UnityEngine.Random.Range(0, healthyFoodItems.Count)]);
                        break;
                    case 1:
                        winningData.Add(unhealthyFoodItems[UnityEngine.Random.Range(0, unhealthyFoodItems.Count)]);
                        break;
                    case 2:
                        winningData.Add(crossData);
                        break;
                    case 3:
                        if (i < 2)
                        {
                            winningData.Add(healthyFoodItems[UnityEngine.Random.Range(0, healthyFoodItems.Count)]);
                        }
                        else
                        {
                            winningData.Add(unhealthyFoodItems[UnityEngine.Random.Range(0, unhealthyFoodItems.Count)]);
                        }
                        break;
                    case 4:
                        if (i < 2)
                        {
                            winningData.Add(unhealthyFoodItems[UnityEngine.Random.Range(0, unhealthyFoodItems.Count)]);
                        }
                        else
                        {
                            winningData.Add(healthyFoodItems[UnityEngine.Random.Range(0, healthyFoodItems.Count)]);
                        }
                        break;
                    case 5:
                        if (i < 2)
                        {
                            winningData.Add(healthyFoodItems[UnityEngine.Random.Range(0, healthyFoodItems.Count)]);
                        }
                        else
                        {
                            winningData.Add(crossData);
                        }
                        break;
                    case 6:
                        if (i < 2)
                        {
                            winningData.Add(unhealthyFoodItems[UnityEngine.Random.Range(0, unhealthyFoodItems.Count)]);
                        }
                        else
                        {
                            winningData.Add(crossData);
                        }
                        break;
                    case 7:
                        if (i < 2)
                        {
                            winningData.Add(crossData);
                        }
                        else
                        {
                            winningData.Add(healthyFoodItems[UnityEngine.Random.Range(0, healthyFoodItems.Count)]);
                        }
                        break;
                    case 8:
                        if (i < 2)
                        {
                            winningData.Add(crossData);
                        }
                        else
                        {
                            winningData.Add(unhealthyFoodItems[UnityEngine.Random.Range(0, unhealthyFoodItems.Count)]);
                        }
                        break;
                    case 9:
                        winningData.Add(allFoodItems[UnityEngine.Random.Range(0, allFoodItems.Count)]);
                        break;
                    default:
                        break;
                }
            }
        }

    }

    [System.Serializable]
    public class SlotItemData
    {
        public Sprite slotItemImage;
        public SlotItemType slotItemType;
        public FoodType foodType;
    }

    [System.Serializable]
    public class WinningFoodItem
    {
        public int HealthyItem;
        public int UnhealthyItem;
        public int None;
        public int Point;
        public int Coin;
    }
}

