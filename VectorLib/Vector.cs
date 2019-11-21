using System;

namespace VectorLib
{
    /// <summary>
    /// Класс вектора, с переопределенными операторами
    /// </summary>
    public class Vector
    {
        /// <summary>
        /// поля x, y, z
        /// </summary>
        private double x;
        private double y;
        private double z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Свойство доступа к полю х
        /// </summary>
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Свойство доступа к полю у
        /// </summary>
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Свойство доступа к полю z
        /// </summary>
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        /// <summary>
        /// Свойство для получение нулевого вектора
        /// </summary>
        public static Vector Zero
        {
            get { return new Vector(0, 0, 0); }
        }

        /// <summary>
        /// Переопределение оператора "+" для сложения векторов 
        /// </summary>
        public static Vector operator +(Vector vector1, Vector vector2)
        {
            double x = vector1.X + vector2.X;
            double y = vector1.Y + vector2.Y;
            double z = vector1.Z + vector2.Z;
            Vector vector3 = new Vector(x, y, z);
            return vector3;
        }

        /// <summary>
        /// Переопределение оператора "-" для вычитания векторов 
        /// </summary>
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            double x = vector1.X - vector2.X;
            double y = vector1.Y - vector2.Y;
            double z = vector1.Z - vector2.Z;
            Vector vector3 = new Vector(x, y, z);
            return vector3;
        }

        /// <summary>
        /// Переопределение оператора "*" для умножения векторов 
        /// </summary>
        public static Vector operator *(Vector vector1, Vector vector2)
        {
            double x = vector1.X * vector2.X;
            double y = vector1.Y * vector2.Y;
            double z = vector1.Z * vector2.Z;
            Vector vector3 = new Vector(x, y, z);
            return vector3;
        }

        /// <summary>
        /// Переопределение оператора "/" для деления векторов 
        /// </summary>
        public static Vector operator /(Vector vector1, Vector vector2)
        {
            double x = vector1.X / vector2.X;
            double y = vector1.Y / vector2.Y;
            double z = vector1.Z / vector2.Z;
            Vector vector3 = new Vector(x, y, z);
            return vector3;
        }

        /// <summary>
        /// Переопределение оператора "==" для определения равенства векторов 
        /// </summary>
        public static bool operator ==(Vector vector1, Vector vector2)
        {
            if (vector1.X == vector2.X &&
                vector1.Y == vector2.Y &&
                vector1.Z == vector2.Z)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Переопределение оператора "!=" для определения неравенства векторов 
        /// </summary>
        public static bool operator !=(Vector vector1, Vector vector2)
        {
            if (vector1 == vector2)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Переопределение метода для определения равенства векторов  
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == (Vector)obj)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Переопределение метода для получения хеш-кода вектора 
        /// </summary>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
