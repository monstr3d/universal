using Abstract3DConverters;

namespace QuadraticSplitterLibrary
{
    [Init]
    public static class StaticExtensionQuadraticSplitter
    {
        public static void Init(InitAttribute initAttribute)
        {

        }

        static StaticExtensionQuadraticSplitter()
        {
            StaticExtensionAbstract3DConverters.PolygonSplitterFactory = PolygonSpllitterFactory.Instance;
        }

        internal class PolygonSpllitterFactory : IPolygonSplitterFactory
        {
            internal static readonly IPolygonSplitterFactory Instance = new PolygonSpllitterFactory();

            private PolygonSpllitterFactory() { }

            IPolygonSplitter IPolygonSplitterFactory.CreatePolygonSplitter()
            {
                return new PolygonSplitter();
            }
        }

 
        internal partial class PolygonSplitter : IPolygonSplitter
        {
            Polygon[] IPolygonSplitter.this[Polygon polygon] => Get(polygon);

            Polygon[] Get(Polygon polygon)
            {
               // return [polygon];
             //   return [polygon];
                if (polygon.Points.Count <= 3)
                {
                    
                    return [polygon];
                }
                if (polygon.Points.Count == 4)
                {
                    var pt = polygon.Points;
                    var pol1 = new Polygon(new List<Tuple<int, float[]>>() { pt[0], pt[1], pt[2] });
                    var pol2 = new Polygon(new List<Tuple<int, float[]>>() { pt[0], pt[2], pt[3] });
                    return [Invert(pol1), Invert(pol2)];

                }
                throw new NotImplementedException();

            }

            Polygon Invert(Polygon p)
            {
                var l = new List<Tuple<int, float[]>>()
            {
        //        p.Points[0], p.Points[2], p.Points[1]
        p.Points[0], p.Points[1], p.Points[2]
            };
                return p;
            }


        }


    }
}
