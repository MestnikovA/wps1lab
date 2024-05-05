using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApp1.Cube3D
{
    public class Dodecahedron : ModelVisual3D
    {
        private static readonly Brush _defaultColor = Brushes.RosyBrown;
        public Dodecahedron()
        {
            DrawDodecahedron();
        }
        public static List<Point3D> DodecahedronVertices(double side_length)
        {
            double s = side_length;
            //double t1 = 2.0 * Math.PI / 5.0;      // Not used.
            double t2 = Math.PI / 10.0;
            double t3 = 3.0 * Math.PI / 10.0;
            double t4 = Math.PI / 5.0;
            double d1 = s / 2.0 / Math.Sin(t4);
            double d2 = d1 * Math.Cos(t4);
            double d3 = d1 * Math.Cos(t2);
            double d4 = d1 * Math.Sin(t2);
            double Fx =
                (s * s - (2.0 * d3) * (2.0 * d3) - (d1 * d1 - d3 * d3 - d4 * d4)) /
                (2.0 * (d4 - d1));
            double d5 = Math.Sqrt(0.5 *
                (s * s + (2.0 * d3) * (2.0 * d3) -
                    (d1 - Fx) * (d1 - Fx) -
                        (d4 - Fx) * (d4 - Fx) - d3 * d3));
            double Fy = (Fx * Fx - d1 * d1 - d5 * d5) / (2.0 * d5);
            double Ay = d5 + Fy;

            Point3D A = new Point3D(d1, Ay, 0);
            Point3D B = new Point3D(d4, Ay, d3);
            Point3D C = new Point3D(-d2, Ay, s / 2);
            Point3D D = new Point3D(-d2, Ay, -s / 2);
            Point3D E = new Point3D(d4, Ay, -d3);
            Point3D F = new Point3D(Fx, Fy, 0);
            Point3D G = new Point3D(Fx * Math.Sin(t2), Fy, Fx * Math.Cos(t2));
            Point3D H = new Point3D(-Fx * Math.Sin(t3), Fy, Fx * Math.Cos(t3));
            Point3D I = new Point3D(-Fx * Math.Sin(t3), Fy, -Fx * Math.Cos(t3));
            Point3D J = new Point3D(Fx * Math.Sin(t2), Fy, -Fx * Math.Cos(t2));
            Point3D K = new Point3D(Fx * Math.Sin(t3), -Fy, Fx * Math.Cos(t3));
            Point3D L = new Point3D(-Fx * Math.Sin(t2), -Fy, Fx * Math.Cos(t2));
            Point3D M = new Point3D(-Fx, -Fy, 0);
            Point3D N = new Point3D(-Fx * Math.Sin(t2), -Fy, -Fx * Math.Cos(t2));
            Point3D O = new Point3D(Fx * Math.Sin(t3), -Fy, -Fx * Math.Cos(t3));
            Point3D P = new Point3D(d2, -Ay, s / 2);
            Point3D Q = new Point3D(-d4, -Ay, d3);
            Point3D R = new Point3D(-d1, -Ay, 0);
            Point3D S = new Point3D(-d4, -Ay, -d3);
            Point3D T = new Point3D(d2, -Ay, -s / 2);

            List<Point3D> points = new List<Point3D>();
            points.Add(A);
            points.Add(B);
            points.Add(C);
            points.Add(D);
            points.Add(E);
            points.Add(F);
            points.Add(G);
            points.Add(H);
            points.Add(I);
            points.Add(J);
            points.Add(K);
            points.Add(L);
            points.Add(M);
            points.Add(N);
            points.Add(O);
            points.Add(P);
            points.Add(Q);
            points.Add(R);
            points.Add(S);
            points.Add(T);

            return points;
        }
        private void DrawDodecahedron()
        {
            Point3D[] points = DodecahedronVertices(0.5).ToArray();

            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Create the solid dodecahedron.
            mesh.AddPolygon("EDCBA", points);
            mesh.AddPolygon("ABGKF", points);
            mesh.AddPolygon("AFOJE", points);
            mesh.AddPolygon("EJNID", points);
            mesh.AddPolygon("DIMHC", points);
            mesh.AddPolygon("CHLGB", points);
            mesh.AddPolygon("KPTOF", points);
            mesh.AddPolygon("OTSNJ", points);
            mesh.AddPolygon("NSRMI", points);
            mesh.AddPolygon("MRQLH", points);
            mesh.AddPolygon("LQPKG", points);
            mesh.AddPolygon("PQRST", points);

            // Create a model from the mesh
            GeometryModel3D model = new GeometryModel3D(mesh, new DiffuseMaterial(_defaultColor));

            // Create a model group and add the model to it
            Model3DGroup group = new Model3DGroup();
            group.Children.Add(model);

            Content = group;
        }
    }
}
