using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Functions1
{
    public static class PolarUtils
    {
        public static Vector2 CartesianToPolar(this Vector2 vector)
        {
            return new Vector2(
                x:Mathf.Sqrt(vector.x*vector.x + vector.y*vector.y),
                y:Mathf.Atan2(vector.y,vector.x)
                
                );

        }

        public static Vector2 PolarToCartesian(this Vector2 vector)
        {
            return new Vector2(
                x: vector.x*Mathf.Cos(vector.y),
                y: vector.x*Mathf.Sin(vector.y)

                );

        }

    }
}
    
