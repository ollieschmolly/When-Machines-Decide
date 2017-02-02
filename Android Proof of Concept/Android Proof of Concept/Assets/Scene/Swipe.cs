using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    float startime;
    var couldBeSwipe: boolean;
var comfortZone: float;
var minSwipeDist: float;
var maxSwipeTime: float;
 
 
function Update()
    {
        if (iPhoneInput.touchCount > 0)
        {
            var touch = iPhoneInput.touches[0];

            switch (touch.phase)
            {
                case iPhoneTouchPhase.Began:
                    couldBeSwipe = true;
                    startPos = touch.position;
                    startTime = Time.time;
                    break;

                case iPhoneTouchPhase.Moved:
                    if (Mathf.Abs(touch.position.y - startPos.y) > comfortZone)
                    {
                        couldBeSwipe = false;
                    }
                    break;

                case iPhoneTouchPhase.Stationary:
                    couldBeSwipe = false;
                    break;

                case iPhoneTouchPhase.Ended:
                    var swipeTime = Time.time - startTime;
                    var swipeDist = (touch.position - startPos).magnitude;

                    if (couldBeSwipe(swipeTime < maxSwipeTime)(swipeDist > minSwipeDist))
                    {
                        // It's a swiiiiiiiiiiiipe!
                        var swipeDirection = Mathf.Sign(touch.position.y - startPos.y);

                        // Do something here in reaction to the swipe.
                    }
                    break;
            }
        }
    }
}
