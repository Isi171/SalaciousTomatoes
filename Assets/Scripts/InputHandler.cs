using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
	private Vector2 touchOrigin = -Vector2.one;
	[SerializeField] private float swipeUndoWindow;
	[SerializeField] private UnityEvent rightSwipeAction;
	[SerializeField] private UnityEvent leftSwipeAction;
	[SerializeField] private UnityEvent upSwipeAction;
	[SerializeField] private UnityEvent downSwipeAction;
	
	
	private void Update ()
	{
#if UNITY_STANDALONE || UNITY_WEBPLAYER            
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			rightSwipeAction.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			leftSwipeAction.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			upSwipeAction.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			downSwipeAction.Invoke();
		}
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
		
		//TODO workaround for testing
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			rightSwipeAction.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			leftSwipeAction.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			upSwipeAction.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			downSwipeAction.Invoke();
		}
		//TODO end workaround
		
		if (Input.touchCount > 0)
		{
			Touch myTouch = Input.touches[0];
			if (myTouch.phase == TouchPhase.Began)
			{
				touchOrigin = myTouch.position;
			}
			else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
			{
				Vector2 touchEnd = myTouch.position;
				float x = touchEnd.x - touchOrigin.x;
				float y = touchEnd.y - touchOrigin.y;

				//Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
				touchOrigin.x = -1;

				if (Mathf.Abs(x) > Mathf.Abs(y))
				{
					if (x > swipeUndoWindow)
					{
						rightSwipeAction.Invoke();
					}
					else if (x < -swipeUndoWindow)
					{
						leftSwipeAction.Invoke();
					}
				}
				else
				{
					if (y > swipeUndoWindow)
					{
						upSwipeAction.Invoke();
					}
					else if (y < -swipeUndoWindow)
					{
						downSwipeAction.Invoke();
					}
				}
			}
		}
#endif
	}
}
