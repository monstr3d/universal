using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace Assets
{
    public class CameraUpdate : AbstractUpdate
    {

        public bool isActive = true, cursorStartLocked = false, turbulence = true;
        public float pitchFactor = 1, rollFactor = 1, yawFactor = 1, thrust = 1, lift = 1;

        public CameraUpdate()
        {

        }

        #region Overriden Members

  

        public override void Start()
        {
            //Application.targetFrameRate = 60;

        }


        public override void Update()
        {
        }




        #endregion


        void UpdateInternal()
        {
           /*
            //Cursor lock-unlock with Tab key
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (Cursor.lockState != CursorLockMode.Locked) Cursor.lockState = CursorLockMode.Locked; else Cursor.lockState = CursorLockMode.None;
                if (audioSource != null && audioClip != null) audioSource.PlayOneShot(audioClip);
            }
            //

            //Enable or Disable Sound
            if (Input.GetKeyUp(KeyCode.Y) && audioSource != null) { audioSource.mute = !audioSource.mute; if (audioClip != null) audioSource.PlayOneShot(audioClip); }
            //

            //Reset Aircraft Attitude
            if (Input.GetKey(KeyCode.T) || Input.GetMouseButtonDown(2)) transform.localRotation = Quaternion.identity;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(1)) transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
            //

            //Boost or Brake
            if (Input.GetKey(KeyCode.LeftShift)) boost = 2; else boost = 1;
            if (Input.GetKey(KeyCode.LeftControl)) brake = .25f; else brake = 1;
            //

            //Aircraft Thrust
            transform.Translate(Vector3.forward * Time.deltaTime * (thrust * 5) * boost * brake);
            //

            //Lift
            transform.Translate(((Input.GetKey(KeyCode.R) ? 1 : 0) - (Input.GetKey(KeyCode.F) ? 1 : 0)) * Vector3.up * Time.deltaTime * (lift * 5) * boost * brake); //Up and Down (Drones+Helicopters)
                                                                                                                                                                     //

            //Mouse Control (Only if cursor is locked)
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                transform.Rotate(
                    Input.GetAxis("Mouse Y") * Time.deltaTime * (pitchFactor * 100) * boost * brake * 2,
                    0, //Input.GetAxis("Mouse X") * Time.deltaTime * (yawFactor * 100) * boost * brake,
                    -Input.GetAxis("Mouse X") * Time.deltaTime * (rollFactor * 100) * boost * brake / 2,
                    Space.Self);
            }
            //

            //Keyboard Control
            transform.Rotate(
                  ((Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0) + (turbulence ? Random.Range(-0.05f, 0.05f) : 0)) * Time.deltaTime * (pitchFactor * 100) * boost * brake,
                  ((Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0) + (turbulence ? Random.Range(-0.1f, 0.1f) : 0)) * Time.deltaTime * (yawFactor * 100) * boost * brake,
                  ((Input.GetKey(KeyCode.A) ? 1 : 0) - (Input.GetKey(KeyCode.D) ? 1 : 0) + (turbulence ? Random.Range(-0.125f, 0.125f) : 0)) * Time.deltaTime * (rollFactor * 100) * boost * brake,
                  Space.Self);
*/
        }

    }
}
