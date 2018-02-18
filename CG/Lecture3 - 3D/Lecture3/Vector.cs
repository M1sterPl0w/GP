namespace Lecture3
{
    public class Vector
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }
        
        public Vector(float x = 0, float y = 0, float z = 0)
        {
            this.x = x;
            this.y = y;
            this.w = 1;
            this.z = z;
        }

        public static Vector operator +(Vector A, Vector B)
        {
            return new Vector((A.x + B.x), (A.y + B.y), (A.z + B.z));
        }
        public override string ToString()
        {
            return $"({x},{y},{z})";
        }
    }
}