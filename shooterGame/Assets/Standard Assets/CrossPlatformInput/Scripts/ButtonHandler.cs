using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {
        public GameObject[] geschoss = new GameObject[3];
        public string Name;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {
            if (Input.GetButtonDown ("Fire1"))
			for(int i=0; i<3; i++)
				if (!geschoss[i].activeSelf)
				{
					geschoss[i].transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
					geschoss[i].SetActive (true);
					break;
				} 
        }
    }
}
