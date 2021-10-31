using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;


    public static class MathLib2D
    {
        public static double Twice_PI = 6.2831853071795865;
        public static double convToDeg = 57.2957795130823209;
        public static double bearing(Vector2f from, Vector2f to, bool radian=true)
        {
            if (from.X == to.X && from.Y == to.Y)
                throw new ArgumentException("from and to are the same. Cannot calculate a bearing between the same two points.");
            double theta = Math.Atan2(to.X - from.X, from.Y - to.Y);
            if (theta < 0.0)
                theta += Twice_PI;
            if (radian)
                return theta;
            return theta * convToDeg;

        }

        public static double distance(Vector2f from, Vector2f to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }
    }

