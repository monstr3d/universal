using System.ComponentModel.DataAnnotations;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Points
{
    public class Polygon
    {
        #region Fields

        float[] vertexNormal;


        Func<float[]> CaclualateVertexNormal;

        Func<float[]> CalcualateNormal;

        private float[] normal;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="points">Points</param>
        /// <param name="effect">Effect</param>
        public Polygon(PointTexture[] points, Effect effect, float[] normal = null)
        {
            this.normal = normal;
            CalcualateNormal = (normal == null) ? CalculateNormalPre : CalcNormalFull;
            Points = points;
            Effect = effect;
            CalcualateNormal = CalculateNormalPre;
            CaclualateVertexNormal = CaclualateVertexNormalPre;
        }


        #endregion


        /// <summary>
        /// Indexes
        /// </summary>
        public PointTexture[] Points
        { 
            get; protected set; 
        }

  

        public float[] VertexNormal => CaclualateVertexNormal();


        public float[] Normal => CalcualateNormal();
    
        /// <summary>
        /// Vertices
        /// </summary>
        public List<float[]> Vertices
        {
            get;
            private set;
        }

        /// <summary>
        /// Effect
        /// </summary>
        public Effect Effect 
        { 
            get; 
            protected set; 
        }

 
        /// <summary>
        /// Gets Vertices
        /// </summary>
        /// <param name="vertices">Vertices</param>
        /// <param name="dictionary">Dictionary</param>
        /// <returns>Vertices</returns>
        public List<float[]> GetVertices(List<float[]> vertices, Dictionary<float[], Polygon>? dictionary = null)
        {
            Vertices = new List<float[]>();
            foreach (var p in Points)
            {
                if (normal == null)
                {
                    if (p.Normal != null)
                    {
                        normal = p.Normal;
                        CalcualateNormal = CalcNormalFull;
                    }
                }
                var v = vertices[p.Index];
                Vertices.Add(v);
                var b = !dictionary?.ContainsKey(v);
                if (b == true)
                {
                    dictionary[v] = this;
                }
            }
            return Vertices;
        }

        #region Private

        float[] CalcNormalFull()
        {
            return normal;
        }

        float[] CalculateNormalPre()
        {
            throw new Exception("NORMAL");
            CalcualateNormal = CalcNormalFull;
            return normal;
        }

        float[] CaclualateVertexNormalPre()
        {
            CaclualateVertexNormal = CaclualateVertexNormalFin;
            var x = new float[3];
            var y = new float[3];
            for (int i = 0; i < 3; i++)
            {
                var a = Vertices[1][i];
                x[i] = a - Vertices[0][i];
                y[i] = Vertices[2][i] - a;
            }
            vertexNormal = new float[3];
            vertexNormal[0] = x[1] * y[2] - x[2] * y[1];
            vertexNormal[1] = x[2] * y[0] - x[0] * y[2];
            vertexNormal[2] = x[1] * y[0] - x[0] * y[1];
            float m = 0;
            foreach (var v in vertexNormal)
            {
                m += v * v;
            }
            m = 1f / (float)Math.Sqrt(m);
            for (int i = 0; i < 3; i++)
            {
                vertexNormal[i] *= m;
            }
            return vertexNormal;
        }

        float[] CaclualateVertexNormalFin()
        {
            return vertexNormal;
        }


    
        #endregion



    }
}
