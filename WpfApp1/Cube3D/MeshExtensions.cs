using System;
using System.Collections.Generic;

using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp1.Cube3D
{
    public static class MeshExtensions
    {
        public static void AddPolygon(this MeshGeometry3D mesh, string point_names, Point3D[] points)
        {
            Point3D[] polygon_points = new Point3D[point_names.Length];
            for (int i = 0; i < point_names.Length; i++)
            {
                polygon_points[i] = points[ToIndex(point_names[i])];
            }
            AddPolygon(mesh, polygon_points);
        }
        public static void AddPolygon(this MeshGeometry3D mesh, params Point3D[] points)
        {
            // Create the points.
            int index1 = mesh.Positions.Count;
            foreach (Point3D point in points)
                mesh.Positions.Add(point);

            // Create the triangles.
            for (int i = 1; i < points.Length - 1; i++)
            {
                mesh.TriangleIndices.Add(index1);
                mesh.TriangleIndices.Add(index1 + i);
                mesh.TriangleIndices.Add(index1 + i + 1);
            }
        }
        private static int ToIndex(char ch)
        {
            return ch - 'A';
        }
    }
}
