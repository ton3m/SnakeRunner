using UnityEngine;

namespace Input.Touches {
	public class RelativelyFromTouches : InputHandler {
		public float sensitivity = 14f;
		private Vector2 _screenSize;
		private Vector2 _previousMousePosition = Vector2.zero;  // Added field to store the previous mouse position

		private void Start() {
			_screenSize = new Vector2(Screen.width, Screen.height);
		}

		public override Vector2 GetDirection() {
			// Check for touch input
			if (UnityEngine.Input.touchCount > 0) {
				Debug.Log("RelativelyFromTouches.GetDirection");
				Touch touch = UnityEngine.Input.GetTouch(0);
				var direction = (touch.deltaPosition / _screenSize) * sensitivity;
				return direction;
			}

			// Check for mouse input
			if (UnityEngine.Input.GetMouseButton(0)) {
				Debug.Log("RelativelyFromTouches.GetDirection (Mouse)");
				Vector2 mousePosition = UnityEngine.Input.mousePosition;
				Vector2 mouseDelta = mousePosition - _previousMousePosition;
				_previousMousePosition = mousePosition;  // Update the previous mouse position
				var direction = (mouseDelta / _screenSize) * sensitivity;
				return direction;
			}
		
			return Vector2.zero;
		}

		public override float GetVertical() {
			return GetDirection().y; }

		public override float GetHorizontal() {
			return GetDirection().x;
		}
	}
}