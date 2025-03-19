using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SlotGame
{
    public class MiddleWheelRotation : Singleton<MiddleWheelRotation>
    {
        public List<GameObject> Images = new List<GameObject>();
        public List<MiddleBackGroundMovment> middleBackGroundMovements = new List<MiddleBackGroundMovment>();
        public float speed = 0;
        public bool Spin = true;
        public Animator Animator;
        private MiddleBackGroundMovment middlebackGroundMovement;
        public float OffSet;
        public int number;
        float time;
        public IEnumerator SetNumber(int number)
        {
            Animator.SetBool("IsPlay", false);
            yield return new WaitForSeconds(0f);
            Spin = true;
            foreach (MiddleBackGroundMovment allbackGroundMovement in middleBackGroundMovements)
            {
                allbackGroundMovement.StartSpin();
            }
            this.number = number;
            middlebackGroundMovement = middleBackGroundMovements[number];
            StartCoroutine(speedCantroller());
        }

        IEnumerator speedCantroller()
        {
            speed = 200;
            yield return new WaitForSeconds(.1f);
            speed = 500;
            yield return new WaitForSeconds(.1f);
            speed = 800;
            yield return new WaitForSeconds(.1f);
            speed = 1000;
            yield return new WaitForSeconds(.1f);
            speed = 1500;
            yield return new WaitForSeconds(.1f);
            speed = 2000;
            yield return new WaitForSeconds(.1f);
            speed = 2500;
            yield return new WaitForSeconds(.1f);
            speed = 2500;
            yield return new WaitForSeconds(.1f);
            speed = 2000;
            yield return new WaitForSeconds(.1f);
            speed = 1500;
            yield return new WaitForSeconds(.1f);
            speed = 1000;
            yield return new WaitForSeconds(.1f);
            speed = 800;
            yield return new WaitForSeconds(.1f);
            speed = 500;
            yield return new WaitForSeconds(.1f);
            speed = 200;


            Animator.SetBool("IsPlay", true);
            middlebackGroundMovement.IsSpin = true;
            if (middleBackGroundMovements[number].GetComponent<RectTransform>().localPosition != new Vector3(0f, 0f, 0f))
            { speed = 200; }

            foreach (MiddleBackGroundMovment allbackGroundMovement in middleBackGroundMovements)
            {
                allbackGroundMovement.StopSpin();
            }
            speed = 0;
            switch (number)
            {
                case 0:

                    middleBackGroundMovements[0].GetComponent<RectTransform>().localPosition = new Vector3(0, 0f, 0);
                    middleBackGroundMovements[1].GetComponent<RectTransform>().localPosition = new Vector3(0, -200f, 0);
                    middleBackGroundMovements[2].GetComponent<RectTransform>().localPosition = new Vector3(0, 200f, 0);

                    break;
                default:
                    break;
            }

            yield return null;

        }

    }
}