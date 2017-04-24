using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class ThirdPersonUserControl : Photon.MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        protected PlayerControl home;
        
        private void Start()
        {
            home = GetComponent<PlayerControl>();
            // get the transform of the main camera
            if (home.cam != null)
            {
                m_Cam = home.cam.transform;
            }
            else if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();

        }


        private void Update()
        {
            if (home.MenuActif)
            {
                return;
            }

            //Gestion Network
            if (photonView.isMine == false && PhotonNetwork.connected == true)
            {
                return;
            }

            if (!m_Jump)
            {
                if (home.useController)
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("2-Jump");
                }
                else
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
                }
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (home.MenuActif)
            {
                m_Move = Vector3.zero;
                return;
            }
            //Gestion Network
            if (photonView.isMine == false && PhotonNetwork.connected == true)
            {
                return;
            }

            // read inputs
            float h;
            float v;
            bool crouch = false;
            if (home.useController)
            {
                h = CrossPlatformInputManager.GetAxis("2-Horizontal");
                v = CrossPlatformInputManager.GetAxis("2-Vertical");
            }
            else
            {
                h = CrossPlatformInputManager.GetAxis("Horizontal");
                v = CrossPlatformInputManager.GetAxis("Vertical");
                crouch = Input.GetKey(KeyCode.C);
            }
            // calculate move direction to pass to character
            if (home.cam.transform != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(home.cam.transform.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v*m_CamForward + h* home.cam.transform.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v*Vector3.forward + h*Vector3.right;
            }
#if !MOBILE_INPUT
			// walk speed multiplier
	        if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
