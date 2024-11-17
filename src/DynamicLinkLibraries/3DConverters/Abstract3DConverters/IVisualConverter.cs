using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Abstract3DConverters
{
    public interface IVisualConverter
    {
        Assembly Assembly { get; }

        object GetImage(Image image);

       object GetMaterial(Material material);

        object GetColor(Color color);

        object GetMesh(AbstractMesh mesh);

        IMaterialDictionary MaterialDictionary { get; set; }


    }
}
