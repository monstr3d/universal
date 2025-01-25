using Abstract3DConverters.Materials;

namespace Abstract3DConverters
{
    public class Polygon
    {
        public List<Point> Points {  get; private set; }

        public Material Material { get; private set; }

        public Polygon(List<Point> points, Material material)
        {
            if (material == null)
            {

            }
            foreach (var p in points)
            {
                if (p.Vertex < 0)
                {

                }
            }
            Material = material;
            Points = points;
        }

        public string MaterialName => Material.Name;
    }

    public class Point
    {
        public Point(int vertex, int texture, int normal, float[] data)
        {
            Vertex = vertex;
            Textrure = texture;
            Normal = normal;
            Data = data;
        }

        public int Vertex { get; private set; }

        public int Textrure { get; private set; }

        public int Normal { get; private set; }

        public float[] Data { get; private set; }
    }
}
