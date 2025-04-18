﻿using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Converters
{
    public abstract class AbstractMeshConverter : IMeshConverter
    {
        #region Fields

        Dictionary<string, Effect> effects;

        protected CheckFile CheckFile
        {
            get;
            private set;
        }

        protected IMeshConverter Converter
        {
            get;
            private set;
        }

        IMaterialCreator materialCreator;

        protected virtual IMaterialCreator MaterialCreator => materialCreator;

        protected Service s = new();

        protected bool TrianglesOnly
        {
            get;
            set;
        }

        protected bool RequiresAbsolute
        {
            get;
            set;
        }

        private     


        protected virtual string Directory
        {
            get;
            set;
        }


        #endregion

        protected AbstractMeshConverter(IMaterialCreator materialCreator)
        {
            CheckFile = StaticExtensionAbstract3DConverters.CheckFile;
            Converter = this;
            this.materialCreator = materialCreator;
            var ca = s.GetAttribute<ConverterAttribute>(this);
            if (ca != null)
            {
                TrianglesOnly = ca.TrianglesOnly;
                RequiresAbsolute = ca.RequiresAbsolute;
            }
        }

        #region 


        string IMeshConverter.Directory { get => Directory; set => Directory = value; }
        Dictionary<string, Effect> IMeshConverter.Effects { set => Effects = value; }

        IMaterialCreator IMeshConverter.MaterialCreator => MaterialCreator;

        void IMeshConverter.Add(object parent, object child)
        {
            Add(parent, child);
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            return Combine(meshes);
        }

        object IMeshConverter.Create(IMesh mesh)
        {
            return Create(mesh);
        }

        void IMeshConverter.SetEffect(object mesh, object effect)
        {
            SetEffect(mesh, effect);
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            SetTransformation(mesh, transformation);
        }

        string IMeshConverter.Filename { set => Filename = value; }


        #endregion

        #region Protected

        protected virtual string Filename
        {
            get;
            set;
        }
        protected virtual Dictionary<string, Material> Materials
        {
            get;
            set;
        } = new();

        protected virtual Dictionary<string, Image> Images
        {
            get;
            set;
        } = new();

        protected virtual Dictionary<string, Effect> Effects
        {
            get => effects;
            set => effects = s.ChangeImagePath<string>(Directory, value);
        }

        protected abstract void Add(object parent, object child);

        protected abstract object Combine(IEnumerable<object> meshes);

        protected virtual object Create(IMesh mesh)
        {
            if (TrianglesOnly)
            {
                if (mesh is ICreateTriangles ct)
                {
                    ct.CreateTriangles();
                }
            }
            if (RequiresAbsolute)
            {
                mesh.CalculateAbsolute();
            }
            return null;
        }

        protected virtual void SetEffect(object mesh, object effect)
        {

        }

        protected virtual void SetTransformation(object mesh, float[] transformation)
        {

        }

        protected virtual string GetFullPath(Image image)
        {
            return image.FullPath;
        }
  

        #endregion
    }
}
