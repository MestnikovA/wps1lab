using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp1.Cube3D
{
    public class Tetrahedron : ModelVisual3D
    {
        private static readonly Brush _defaultColor = Brushes.Green;
        public Tetrahedron() 
        {
            DrawTetrahedron();    
        }

        private void DrawTetrahedron()
        {
            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();
            double moveX = -1; // Сдвиг по оси X влево
            double moveY = 0.6;  // Сдвиг по оси Y вверх
            // Define the vertices of the tetrahedron
            Point3D[] vertices = new Point3D[]
            {
                new Point3D(0 + moveX, 0 + moveY, 0),       // Base vertex 1
                new Point3D(0.5 + moveX, 0 + moveY, 0),       // Base vertex 2
                new Point3D(0.25 + moveX, Math.Sqrt(3) / 4 + moveY, 0), // Base vertex 3
                new Point3D(0.25 + moveX, Math.Sqrt(3) / 12 + moveY, Math.Sqrt(6) / 6)  // Apex
            };

            // Add vertices to the mesh
            foreach (var vertex in vertices)
            {
                mesh.Positions.Add(vertex);
            }

            // Define the indices of the faces (triangles) of the tetrahedron
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);

            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(1);

            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(2);

            // Create a model from the mesh
            GeometryModel3D model = new GeometryModel3D(mesh, new DiffuseMaterial(_defaultColor));

            // Create a model group and add the model to it
            Model3DGroup group = new Model3DGroup();
            group.Children.Add(model);

            Content = group;

            // Add the 3D scene to the viewport
            //MainViewport.Children.Add(visual);
        }
    }
}
