using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MeshGenerator
{
    public static Mesh Generate(int sizeX, int sizeZ, float cellSize, float maxHeight, int seed = 0)
    {
        List<Vector3> vertices = new();
        List<int> triangles = new();

        int v = 0;
        System.Random rand = seed != 0 ? new Random(seed) : new Random();
        float noiseRandCoef = rand.Next(1, 100) / 100.0f;

        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                float height = Mathf.PerlinNoise(x * noiseRandCoef, z * noiseRandCoef) * maxHeight;
                if (x % 5 == 0 || z % 5 == 0)
                    height = 0.01f;

                Vector3 basePos = new Vector3(x * cellSize, 0, z * cellSize);

                Vector3 p0 = basePos;
                Vector3 p1 = basePos + new Vector3(cellSize, 0, 0);
                Vector3 p2 = basePos + new Vector3(cellSize, 0, cellSize);
                Vector3 p3 = basePos + new Vector3(0, 0, cellSize);

                Vector3 p4 = p0 + Vector3.up * height;
                Vector3 p5 = p1 + Vector3.up * height;
                Vector3 p6 = p2 + Vector3.up * height;
                Vector3 p7 = p3 + Vector3.up * height;

                vertices.AddRange(new[]
                {
                    p0,p1,p2,p3, // bottom
                    p4,p5,p6,p7  // top
                });

                // стены
                AddQuad(triangles, v+0,v+1,v+5,v+4);
                AddQuad(triangles, v+1,v+2,v+6,v+5);
                AddQuad(triangles, v+2,v+3,v+7,v+6);
                AddQuad(triangles, v+3,v+0,v+4,v+7);

                // крыша
                AddQuad(triangles, v+4,v+5,v+6,v+7);

                v += 8;
            }
        }

        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles,0);
        mesh.RecalculateNormals();

        return mesh;
    }

    static void AddQuad(List<int> tris,int a,int b,int c,int d)
    {
        tris.Add(a); tris.Add(b); tris.Add(c);
        tris.Add(a); tris.Add(c); tris.Add(d);
    }
}