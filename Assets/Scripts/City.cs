using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace DefaultNamespace
{
    public class City : MonoBehaviour
    {
        [SerializeField] private MeshFilter _meshFilter;
        [SerializeField] private Path _path;
        [SerializeField] private float _buildingWidth;
        [SerializeField] private float _width;
        [SerializeField] private float _streetWidth;
        [SerializeField] private float _maxHeight;
        [SerializeField] private int _seed = 0;
        
        public void Generate()
        {
            _meshFilter.mesh = GenerateMesh(_path.Value, _width, _streetWidth, _buildingWidth, _maxHeight, _seed);;
        }

        private Mesh GenerateMesh(Spline path, float width, float streetWidth, float cellSize, float maxHeight, int seed = 0)
        {
            List<Vector3> vertices = new();
            List<int> triangles = new();

            var v = 0;
            var rand = seed != 0 ? new System.Random(seed) : new System.Random();
            var p = new Vector3[8];
            
            for (float d = 0; d < path.GetLength(); d += cellSize)
            {
                for (float w = -width; w < width; w += cellSize)
                {
                    var noiseRandCoef = rand.Next(10, 50) / 100.0f;
                    var t = SplineUtility.GetNormalizedInterpolation(path, d, PathIndexUnit.Distance);
                    var pos = path.EvaluatePosition(t);
                    var height = Mathf.PerlinNoise(pos.x * noiseRandCoef, pos.z * noiseRandCoef) * maxHeight;

                    if (Mathf.Abs(w) < streetWidth)
                        height = 0;
                    
                    var basePos = new Vector3(pos.x, 0, pos.z + w);

                    p[0] = basePos;
                    p[1] = basePos + new Vector3(cellSize, 0, 0);
                    p[2] = basePos + new Vector3(cellSize, 0, cellSize);
                    p[3] = basePos + new Vector3(0, 0, cellSize);
                    p[4] = p[0] + Vector3.up * height;
                    p[5] = p[1] + Vector3.up * height;
                    p[6] = p[2] + Vector3.up * height;
                    p[7] = p[3] + Vector3.up * height;

                    vertices.AddRange(p);
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

            var mesh = new Mesh();
            mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles,0);
            mesh.RecalculateNormals();

            return mesh;
        }
        
        static void AddQuad(List<int> tris,int a,int b,int c,int d)
        {
            tris.Add(a); tris.Add(c); tris.Add(b);
            tris.Add(a); tris.Add(d); tris.Add(c);
        }
    }
}