using UnityEngine;

namespace PixelPlay.OffScreenIndicator
{
    public class OffScreenIndicatorCore
    {

        public static Vector3 GetScreenPosition(Camera mainCamera, Vector3 targetPosition)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(targetPosition);
            return screenPosition;
        }

        public static bool IsTargetVisible(Vector3 screenPosition)
        {
            bool isTargetVisible = screenPosition.z > 0 && screenPosition.x > 0 && screenPosition.x < Screen.width && screenPosition.y > 0 && screenPosition.y < Screen.height;
            return isTargetVisible;
        }

        public static void GetArrowIndicatorPositionAndAngle(ref Vector3 screenPosition, ref float angle, Vector3 screenCentre, Vector3 screenBounds)
        {
            screenPosition -= screenCentre;

            if(screenPosition.z < 0)
            {
                screenPosition *= -1;
            }

            angle = Mathf.Atan2(screenPosition.y, screenPosition.x);
            float slope = Mathf.Tan(angle);

            if(screenPosition.x > 0)
            {
                screenPosition = new Vector3(screenBounds.x, screenBounds.x * slope, 0);
            }
            else
            {
                screenPosition = new Vector3(-screenBounds.x, -screenBounds.x * slope, 0);
            }
            if(screenPosition.y > screenBounds.y)
            {
                screenPosition = new Vector3(screenBounds.y / slope, screenBounds.y, 0);
            }
            else if(screenPosition.y < -screenBounds.y)
            {
                screenPosition = new Vector3(-screenBounds.y / slope, -screenBounds.y, 0);
            }
            screenPosition += screenCentre;
        }
    }
}
