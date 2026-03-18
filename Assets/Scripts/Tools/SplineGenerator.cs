using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;
using Random = System.Random;

public class SplineGenerator
{
    public static Spline Generate(int pathLength, int pointsCount, int pointRadius, int seed = 0)
    {
        var rand = seed != 0 ? new Random(seed) : new Random();
        var segmentLength = (float)pathLength / pointsCount;

        var result = new Spline();
        
        for (int pointIndex = 0; pointIndex < pointsCount; pointIndex++)
        {
            var offset = pointIndex > 0 || pointIndex == pointsCount - 1
                ? new Vector3(rand.Next(-pointRadius, pointRadius), rand.Next(-pointRadius, pointRadius),
                    rand.Next(-pointRadius, pointRadius))
                : new Vector3();
            
            result.Add(new BezierKnot(new float3(segmentLength * pointIndex + offset.x, offset.y, offset.z)));
            result.SetTangentMode(pointIndex, TangentMode.AutoSmooth);
        }
        return result;
    }
}