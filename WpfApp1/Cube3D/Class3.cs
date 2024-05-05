using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp1.Cube3D
{
    public class Octaedro : ModelVisual3D
    {
        private static readonly Brush _defaultColor = Brushes.Red;
        public Octaedro()
        {
            DrawOctaedro();
        }
        private static GeometryModel3D AddFace(
                        Point3D point1,
                        Point3D point2,
                        Point3D point3,
                        Material material)
        {
            GeometryModel3D geometryModel3D = new()
            {
                Geometry = new MeshGeometry3D()
                {
                    Positions =
                    {
                        point1,
                        point2,
                        point3 //вершины первого треугольника
                    }
                },
                Material = material
            };
            return geometryModel3D;
        }
        private void DrawOctaedro()
        {
            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();
            double moveX = 1; // Сдвиг по оси X влево
            double moveY = 1.5;  // Сдвиг по оси Y вверх

            Point3D p0 = new Point3D(0 + moveX, 0 + moveY, 0.5);
            Point3D p1 = new Point3D(0.5 + moveX, 0 + moveY, 0);
            Point3D p2 = new Point3D(0 + moveX, 0.5 + moveY, 0);
            Point3D p3 = new Point3D(-0.5 + moveX, 0 + moveY, 0);
            Point3D p4 = new Point3D(0 + moveX, -0.5 + moveY, 0);
            Point3D p5 = new Point3D(0 + moveX, 0 + moveY, -0.5);

            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.Positions.Add(p3);
            mesh.Positions.Add(p4);
            mesh.Positions.Add(p5);

            Model3DGroup group = new Model3DGroup();
            // Добавление граней
            // 1 Передняя
            DiffuseMaterial material = new DiffuseMaterial(Brushes.Blue);
            GeometryModel3D faceFront = AddFace(p0, p1, p2, material);
            group.Children.Add(faceFront);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Orange);
            GeometryModel3D faceFront1 = AddFace(p0, p2, p3, material);
            group.Children.Add(faceFront1);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront2 = AddFace(p0, p3, p4, material);
            group.Children.Add(faceFront2);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Green);
            GeometryModel3D faceFront3 = AddFace(p0, p4, p1, material);
            group.Children.Add(faceFront3);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Yellow);
            GeometryModel3D faceFront4 = AddFace(p1, p5, p2, material);
            group.Children.Add(faceFront4);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Aqua);
            GeometryModel3D faceFront5 = AddFace(p2, p5, p3, material);
            group.Children.Add(faceFront5);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Beige);
            GeometryModel3D faceFront6 = AddFace(p3, p5, p4, material);
            group.Children.Add(faceFront6);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.BlueViolet);
            GeometryModel3D faceFront7 = AddFace(p4, p5, p1, material);
            group.Children.Add(faceFront7);

            Content = group;

            // Add the 3D scene to the viewport
            //MainViewport.Children.Add(visual);
        }
    }
}
