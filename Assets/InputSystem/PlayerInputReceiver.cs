using UnityEngine;
#if ENABLE_INPUT_SYSTEM && NEW_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class PlayerInputReceiver : MonoBehaviour
	{
        [Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;
#if !(ENABLE_INPUT_SYSTEM && NEW_INPUT_SYSTEM)
		[SerializeField] private float mouseScaleFactor = 120f;
#endif

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && NEW_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

#else
		private void Update()
        {
			var moveX = Input.GetAxis("Horizontal");
			var moveY = Input.GetAxis("Vertical");
			
			var mouseX = Input.GetAxis("Mouse X");
			var mouseY = Input.GetAxis("Mouse Y");

			var jumpState = Input.GetButton("Jump");
			var sprintState = Input.GetButton("Sprint");
			
			MoveInput(new Vector2(moveX, moveY));
			LookInput(new Vector2(mouseX, mouseY) * mouseScaleFactor);
			JumpInput(jumpState);
			SprintInput(sprintState);
		}
#endif
        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}