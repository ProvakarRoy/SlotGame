using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotGame
{
    public class LeftWheelRotation : Singleton<LeftWheelRotation>
    {
        public List<GameObject> Images = new List<GameObject>();
        public List<LeftBackGroundMovement> leftbackGroundMovements = new List<LeftBackGroundMovement>();
        public float speed = 0;
        public bool Spin = true;
        public Animator Animator;
        private LeftBackGroundMovement leftbackGroundMovement;
        public float OffSet;
        public int number;
        float time;
        public IEnumerator SetNumber(int number)
        {
            yield return new WaitForSeconds(0f);
            Animator.SetBool("IsPlay", false);
            Spin = true;
            foreach (LeftBackGroundMovement allbackGroundMovement in leftbackGroundMovements)
            {
                allbackGroundMovement.StartSpin();
            }
            this.number = number;
            leftbackGroundMovement = leftbackGroundMovements[number];
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
            leftbackGroundMovement.IsSpin = true;
            if (leftbackGroundMovements[number].GetComponent<RectTransform>().localPosition != new Vector3(0f, 0f, 0f))
            { speed = 200; }

            foreach (LeftBackGroundMovement allbackGroundMovement in leftbackGroundMovements)
            {
                allbackGroundMovement.StopSpin();
            }
            speed = 0;

            switch (number)
            {
                case 0:

                    leftbackGroundMovements[0].GetComponent<RectTransform>().localPosition = new Vector3(0, 0f, 0);
                    leftbackGroundMovements[1].GetComponent<RectTransform>().localPosition = new Vector3(0, -200f, 0);
                    leftbackGroundMovements[2].GetComponent<RectTransform>().localPosition = new Vector3(0, 200f, 0);

                    break;
                default:
                    break;
            }

            yield return null;

        }
    }
}
