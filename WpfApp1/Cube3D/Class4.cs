using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp1.Cube3D
{
    public class Icosahedron : ModelVisual3D
    {
        private static readonly Brush _defaultColor = Brushes.Yellow;
        public Icosahedron()
        {
            DrawIcosahedron();
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
        private void DrawIcosahedron()
        {
            double phi = (1 + Math.Sqrt(5)) / 2; // Golden ratio
            double scale = 0.3;
            double S = scale;
            //double t1 = 2.0 * Math.PI / 5;
            double t2 = Math.PI / 10.0;
            double t4 = Math.PI / 5.0;
            //double t3 = -3.0 * Math.PI / 10.0;
            double R = (S / 2.0) / Math.Sin(t4);
            double H = Math.Cos(t4) * R;
            double Cx = R * Math.Sin(t2);
            double Cz = R * Math.Cos(t2);
            double H1 = Math.Sqrt(S * S - R * R);
            double H2 = Math.Sqrt((H + R) * (H + R) - H * H);
            double Y2 = (H2 - H1) / 2.0;
            double Y1 = Y2 + H1;
            // Define the vertices of the icosahedron
            Point3D[] vertices = new Point3D[]
            {
                new Point3D (  0,  Y1,    0),       // Vertex 1
                new Point3D (  R,  Y2,    0),      // Vertex 2
                new Point3D ( Cx,  Y2,   Cz),      // Vertex 3
                new Point3D ( -H,  Y2,  S/2),     // Vertex 4
                new Point3D ( -H,  Y2, -S/2),       // Vertex 5
                new Point3D ( Cx,  Y2,  -Cz),      // Vertex 6
                new Point3D ( -R, -Y2,    0),      // Vertex 7
                new Point3D (-Cx, -Y2,  -Cz),     // Vertex 8
                new Point3D (  H, -Y2, -S/2),       // Vertex 9
                new Point3D (  H, -Y2,  S/2),      // Vertex 10
                new Point3D (-Cx, -Y2,   Cz),      // Vertex 11
                new Point3D (  0, -Y1,    0)      // Vertex 12
            };

            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Add vertices to the mesh
            foreach (var vertex in vertices)
            {
                mesh.Positions.Add(vertex);
            }
            Model3DGroup group = new Model3DGroup();
            // Добавление граней
            // 1 Передняя
            DiffuseMaterial material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront = AddFace(vertices[0], vertices[2], vertices[1], material);
            group.Children.Add(faceFront);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Orange);
            GeometryModel3D faceFront1 = AddFace(vertices[0], vertices[3], vertices[2], material);
            group.Children.Add(faceFront1);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.MistyRose);
            GeometryModel3D faceFront2 = AddFace(vertices[0], vertices[4], vertices[3], material);
            group.Children.Add(faceFront2);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Moccasin);
            GeometryModel3D faceFront3 = AddFace(vertices[0], vertices[5], vertices[4], material);
            group.Children.Add(faceFront3);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Navy);
            GeometryModel3D faceFront4 = AddFace(vertices[0], vertices[1], vertices[5], material);
            group.Children.Add(faceFront4);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.OldLace);
            GeometryModel3D faceFront5 = AddFace(vertices[1], vertices[2], vertices[9], material);
            group.Children.Add(faceFront5);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Peru);
            GeometryModel3D faceFront6 = AddFace(vertices[2], vertices[3], vertices[10], material);
            group.Children.Add(faceFront6);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.RoyalBlue);
            GeometryModel3D faceFront7 = AddFace(vertices[3], vertices[4], vertices[6], material);
            group.Children.Add(faceFront7);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Silver);
            GeometryModel3D faceFront8 = AddFace(vertices[4], vertices[5], vertices[7], material);
            group.Children.Add(faceFront8);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Snow);
            GeometryModel3D faceFront9 = AddFace(vertices[5], vertices[1], vertices[8], material);
            group.Children.Add(faceFront9);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Teal);
            GeometryModel3D faceFront10 = AddFace(vertices[6], vertices[4], vertices[7], material);
            group.Children.Add(faceFront10);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Turquoise);
            GeometryModel3D faceFront11 = AddFace(vertices[7], vertices[5], vertices[8], material);
            group.Children.Add(faceFront11);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Wheat);
            GeometryModel3D faceFront12 = AddFace(vertices[8], vertices[1], vertices[9], material);
            group.Children.Add(faceFront12);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Yellow);
            GeometryModel3D faceFront13 = AddFace(vertices[9], vertices[2], vertices[10], material);
            group.Children.Add(faceFront13);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Violet);
            GeometryModel3D faceFront14 = AddFace(vertices[10], vertices[3], vertices[6], material);
            group.Children.Add(faceFront14);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Lime);
            GeometryModel3D faceFront15 = AddFace(vertices[11], vertices[6], vertices[7], material);
            group.Children.Add(faceFront15);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Khaki);
            GeometryModel3D faceFront16 = AddFace(vertices[11], vertices[7], vertices[8], material);
            group.Children.Add(faceFront16);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Indigo);
            GeometryModel3D faceFront17 = AddFace(vertices[11], vertices[8], vertices[9], material);
            group.Children.Add(faceFront17);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.HotPink);
            GeometryModel3D faceFront18 = AddFace(vertices[11], vertices[9], vertices[10], material);
            group.Children.Add(faceFront18);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Fuchsia);
            GeometryModel3D faceFront19 = AddFace(vertices[11], vertices[10], vertices[6], material);
            group.Children.Add(faceFront19);

            Content = group;

            // Add the 3D scene to the viewport
            //MainViewport.Children.Add(visual);
        }
    }
}
