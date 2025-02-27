using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Points;

namespace Abstract3DConverters.Meshes
{
    internal abstract class Class1
    {

        #region Abstract and vitrual members

        protected abstract List<float[]> Vertices { get; set; }

        protected abstract List<float[]> Normals { get; set; }

        protected abstract List<float[]> Textures { get; set; }

        protected abstract Effect Effect { get; set; }

        protected abstract List<int[]> Indexes { get; set; }

        protected abstract bool HasPolygons { get; set; }

        protected abstract List<Point> AbsolutePoints { get; set; }

        protected abstract float[] TransformationMatrix { get; set; }

        protected abstract string Name { get; set; }

        protected abstract List<Polygon> Polygons { get; set; }

        protected abstract List<IMesh> Children { get; set; }

        protected abstract Effect GetEffect(IMaterialCreator creator);

        #region

    }
}
