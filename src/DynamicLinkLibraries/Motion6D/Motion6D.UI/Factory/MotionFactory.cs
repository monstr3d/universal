using System;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

using Motion6D.Aggregates;
using Motion6D.UI.Forms;
using NamedTree;

namespace Motion6D.UI.Factory
{
    /// <summary>
    /// Factory related to 6D Motion and Physical Fields
    /// </summary>
    public class MotionFactory : EmptyUIFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static MotionFactory Object = new MotionFactory();

        private const string Field3D = "3D Field";

        private const string SphericalVectorPotentialGragient = "SphericalVectorPotentialGragient";

        private const string InertialNavigationSystem = "Inertial Navigation System";

        private const string Measurements_of_3D_field = "Measurements of 3D field";

        /// <summary>
        /// Buttons for palette toolbar
        /// </summary>
        public static readonly ButtonWrapper[] ObjectButtons =
                new ButtonWrapper[] 
                {
                            new ButtonWrapper(typeof(Motion6D.RigidReferenceFrame),
                    "", "Rigid frame", ResourceImage.Dimension, MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.ReferenceFrameData),
                    "", "Moved frame", ResourceImage.DataFrame, MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.ReferenceFrameDataPitchRollHunting),
                    "", "Euler frame", ResourceImage.DataFrame, MotionFactory.Object, false, false),
                            new ButtonWrapper(typeof(Motion6D.RelativeMeasurements),
                    "", "Relative measurements", ResourceImage.LinearMeasure, MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.PositionCollectionData),
                    "", "Data points collection", ResourceImage.Indicator3D, MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.PositionCollectionIndicator),
                    "", "Points indicator", ResourceImage.CameraStars, MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    Field3D, "3D Field", ResourceImage.Field3D, MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    SphericalVectorPotentialGragient, "Spherical Magnetic field", ResourceImage.Magnetic,
                    MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    Measurements_of_3D_field, "Measurements of 3D field", ResourceImage.Volt,
                    MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.InertialReferenceFrame),
                    "", "Solid body dynamics", ResourceImage.InertialReferenceFrame,
                    MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    "Inertial Navigation System", "Inertial Navigation System", 
                    ResourceImage.Inertial,
                    MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(Motion6D.AcceleratedPosition),
                    "", "Material point", ResourceImage.Point,
                    MotionFactory.Object, true, false),
                            new ButtonWrapper(typeof(AggregableWrapper),
                    "Motion6D.Aggregates.RigidBody,Motion6DData, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "Rigid body", ResourceImage.RigidBody,
                    MotionFactory.Object, true, false)
                };

        /// <summary>
        /// Buttons for palette toolbar
        /// </summary>
        public static readonly ButtonWrapper[] ArrowButtons =
        new ButtonWrapper[] 
                {
                            new ButtonWrapper(typeof(Motion6D.ReferenceFrameArrow),
                    "", "Geometry link", ResourceImage.DimensionLink, MotionFactory.Object, true, true),
                            new ButtonWrapper(typeof(Motion6D.RelativeMeasurementsLink),
                    "", "Relative measurements link", ResourceImage.LinearMeasureLink, MotionFactory.Object, true, true),
                            new ButtonWrapper(typeof(Motion6D.PositionIndicatorLink),
                    "", "Points indicator link", ResourceImage.Indicator3DLink, MotionFactory.Object, true, true),
                           new ButtonWrapper(typeof(PhysicalField.FieldLink),
                    "", "Field link", ResourceImage.Field_Link, MotionFactory.Object, true, true),
                           new ButtonWrapper(typeof(Motion6D.MechanicalAggregateLink),
                    "", "Mechanilal aggregate link", ResourceImage.MechanicalConnection, MotionFactory.Object, true, true),
               };

        #endregion

        #region Ctor

        private MotionFactory()
        {
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Creates object the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        public override ICategoryObject CreateObject(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            string kind = button.Kind;  // Kind of object
            if (type.Equals(typeof(SerializablePosition)))
            {
                Motion6D.SerializablePosition p = new Motion6D.SerializablePosition();
                if (kind.Equals(SphericalVectorPotentialGragient))
                {
                    PhysicalField.SphericalFieldWrapper ph =
                        new PhysicalField.SphericalFieldWrapper((int)SphericalFields.SphericalType.VectorPotentialGragient);
                    p.Parameters = ph;
                    Interfaces.IPositionObject po = ph;
                    po.Position = p;
                    return p;
                }
                if (kind.Equals(Measurements_of_3D_field))
                {
                    Motion6D.PhysicalFieldMeasurements3D ph = new Motion6D.PhysicalFieldMeasurements3D();
                    p.Parameters = ph;
                    Motion6D.Interfaces.IPositionObject po = ph;
                    po.Position = p;
                    return p;
                }
                if (kind.Equals(InertialNavigationSystem))
                {
                    Motion6D.InertialSensorData sensor = new Motion6D.InertialSensorData();
                    p.Parameters = sensor;
                    Motion6D.Interfaces.IPositionObject po = sensor;
                    po.Position = p;
                    return p;
                }
                if (kind.Equals(Field3D))
                {
                    PhysicalField3D ph =
                        new PhysicalField3D();
                    p.Parameters = ph;
                    Interfaces.IPositionObject po = ph;
                    po.Position = p;
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The result form</returns>
        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is SerializablePosition)
                {
                    Interfaces.IPosition p = obj as Interfaces.IPosition;
                    object o = p.Parameters;
                    if (o != null)

                        switch (o)
                        {
                            case Portable.PhysicalFieldBase pfb:
                                return new Forms.FormField3D(lab, o as PhysicalField3D);
                            case PhysicalField.SphericalFieldWrapper sfw:
                                return new FormSphericalMagnnetic(lab, o as PhysicalField.SphericalFieldWrapper);
                            case InertialSensorData isd:
                             return new FormInertialSystem(lab, o as Motion6D.InertialSensorData);
                            default:
                                break;
                        }
                }
                switch (obj)
                {
                    case InertialReferenceFrame irf:
                        return new FormInertia(lab);
                    case ReferenceFrameData rfd:
                        return new FormFrameData(lab);
                    case RigidReferenceFrame rrf:
                        return new FormRigidFrame(lab);
                    case AcceleratedPosition arf:
                        return new FormAcceleratedPoint(lab);
                    case PositionCollectionData pcd:
                        return new FormPointsCollection(lab);
                    default: break;
                }
                if (obj is IChildren<IAssociatedObject> co)
                {
                    RigidBody rb = co.GetChild<RigidBody>();
                    if (rb != null)
                    {
                        return new FormRigidBody(lab);
                    }
                }
            }

            if (comp is IArrowLabel)
            {
                IArrowLabel l = comp as IArrowLabel;
                ICategoryArrow arrow = l.Arrow;
                if (arrow is MechanicalAggregateLink)
                {
                    return new FormAggregateLink(l);
                }
            }
            return null;
        }

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            object im = button.ButtonImage;
            if (type.Equals(typeof(PositionCollectionIndicator)))
            {
                return (new Labels.PositionsIndicatorLabel()).CreateLabelUI(im, false);
            }
            if (type.Equals(typeof(ReferenceFrameData)))
            {
                return (new Labels.ReferenceFrameDataLabel()).CreateLabelUI(im, true);
            }
            if (type.Equals(typeof(ReferenceFrameDataPitchRollHunting)))
            {
                return (new Labels.ReferenceFrameDataPitchRollHuntingLabel()).CreateLabelUI(im, true);
            }
            return null;
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            Type type = obj.GetType();
            if (type.Equals(typeof(PositionCollectionIndicator)))
            {
                return (new UI.Labels.PositionsIndicatorLabel()).CreateLabelUI(null, true);
            }
            if (type.Equals(typeof(ReferenceFrameData)))
            {
                (new UI.Labels.ReferenceFrameDataLabel()).CreateLabelUI(null, true);
            }
            if (type.Equals(typeof(ReferenceFrameDataPitchRollHunting)))
            {
                (new UI.Labels.ReferenceFrameDataPitchRollHuntingLabel()).CreateLabelUI(null, true);
            }
            if (obj is IChildren<IAssociatedObject> co)
            {
                RigidBody rb = co.GetChild<RigidBody>();
                if (rb != null)
                {
                    //return new ObjectLabel(Tools.FindButton()
                }
            }
            return null;
        }
         

        #endregion

        #region Members


        #endregion

    }
}
