using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotGame
{
    public class RightWheelRotation : Singleton<RightWheelRotation>
    {
        public List<RightBackGroundMovement> rightbackGroundMovements = new List<RightBackGroundMovement>();
        public float speed = 0;
        public Animator Animator;
        public bool Spin = true;
        private RightBackGroundMovement rightbackGroundMovement;
        public float OffSet;
        public int number;
        float time;
        public IEnumerator SetNumber(int number)
        {
            yield return new WaitForSeconds(0f);
            Animator.SetBool("IsPlay", false);
            Spin = true;
            foreach (RightBackGroundMovement allbackGroundMovement in rightbackGroundMovements)
            {
                allbackGroundMovement.StartSpin();
            }
            this.number = number;
            rightbackGroundMovement = rightbackGroundMovements[number];
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
            rightbackGroundMovement.IsSpin = true;
            if (rightbackGroundMovements[number].GetComponent<RectTransform>().localPosition != new Vector3(0f, 0f, 0f))
            { speed = 200; }


            foreach (RightBackGroundMovement allbackGroundMovement in rightbackGroundMovements)
            {
                allbackGroundMovement.StopSpin();
            }
            speed = 0;

            switch (number)
            {
                case 0:

                    rightbackGroundMovements[0].GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                    rightbackGroundMovements[1].GetComponent<RectTransform>().localPosition = new Vector3(0, -200, 0);
                    rightbackGroundMovements[2].GetComponent<RectTransform>().localPosition = new Vector3(0, 200, 0);

                    break;
                default:
                    break;
            }

            yield return null;

        }
    }

}
