package measurements;

import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;
import error_handler.OwnNotImplemented;
import general_service.Performer;
import general_service.interfaces.IPostSetArrow;
import measurements.interfaces.*;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class ObjectTransformer extends CategoryObject implements IObjectTransformerConsumer,
        IDataConsumer, IMeasurements, IPostSetArrow {
    public ObjectTransformer(String name, IDesktop desktop)
    {
        super(name, desktop);
    }

    @Override
    public void postSetArrow() {
        initTransformer();
    }

    @Override
    public IMeasurements[] getAllMeasurements() {
        return measurements;
    }

    @Override
    public void addMeasurements(IMeasurements item) {
        measurements = performer.extend(measurements, item);
    }

    @Override
    public int getMeasurementsCount() {
        return outMea.length;
    }

    @Override
    public IMeasurement getMeasurement(int i) {
        return outMea[i];
    }

    @Override
    public void updateMeasurements()
    {
        mPerformer.updateChildrenData(this);
        for (var i = 0; i < inO.length; i++)
        {
            var m = inMea[i];
            inO[i] = m.getMeasurementValue();
        }
        transformer.calculate(this.inO, this.outO);

    }

    @Override
    public void addMeasurement(IMeasurement measurement) {

    }

    @Override
    public void addTransfotmer(IObjectTransformer transformer) {
        if (this.transformer != null) {
            show("Transformer already exists");
            return;
        }
        this.transformer = transformer;
    }

    /// <summary>
    /// This object as IObjectTransformer
    /// </summary>
    IObjectTransformer transformer;


    /// <summary>
    /// Input
    /// </summary>
    protected Object[]  input;

    /// <summary>
    /// Output measurements
    /// </summary>
    protected TransMeasurement[]  outMea = new TransMeasurement[0];

    /// <summary>
    /// Input measurements
    /// </summary>
    protected  IMeasurement[] inMea = new IMeasurement[0];


    /// <summary>
    /// Input objects
    /// </summary>
    protected  Object[] inO;

    /// <summary>
    /// Output objects
    /// </summary>
    protected Object[] outO;

    /// <summary>
    /// Single output
    /// </summary>
    protected Object[] outS;
    /// <summary>
    /// Single input
    /// </summary>
    protected Object[] inS;

    /// <summary>
    /// The "is updated" sign
    /// </summary>
    protected  boolean isUpdated = false;

    protected ArrayList<int[]> array;

    protected measurements.Performer mPerformer = new measurements.Performer();

    /// <summary>
    /// External measurements
    /// </summary>
    /// <summary>
    /// Providers of measurements
    /// </summary>
    IMeasurements[] measurements  = new IMeasurements[0];

/// <summary>
/// Links to variables
/// </summary>
   Map<String, String> links = new HashMap<>();

    /// <summary>
    /// Providers of measurements
    /// </summary>
    IMeasurements providers;

    IDataConsumer consumer;


    protected void setArray()
    {
        var n = array.size();
        inMea = new IMeasurement[n];
        for (int i = 0; i < n; i++)
        {
            inMea[i] = mPerformer.get(this, array.get(i));
        }
        var outS = this.transformer.getOutput();
        n = outS.length;
        for (var i = 0; i < n; i++)
        {
            var name = outS[i];
            var type = transformer.getOutputType(i);
            outMea = performer.extend(outMea, new TransMeasurement(i, this.outO, name, type));
        }

    }

    protected void  createOutput()
    {
        if (array != null)
        {
            setArray();
            return;
        }
        this.inMea = new IMeasurement[0];
        var outS = this.transformer.getOutput();
        for (var i = 0; i < outS.length; i++)
        {
            var name = outS[i];
            var type = transformer.getOutputType(i);
            outMea = performer.extend(outMea, new TransMeasurement(i, this.outO, name, type));
        }
        var mm = mPerformer.getMeasurementMap(this);
        var ent = links.entrySet();
        for (var item : ent)
        {
            var mt = mm.get(item.getKey());
            if (mt != null)
            {
                inMea = performer.extend(inMea, mt);
            }
        }
    }

   void initTransformer()
   {
       ArrayList<int[]> l = new ArrayList<>();
       l.add(new int[]{1});
        var inp = this.transformer.getInput();
        var out = this.transformer.getOutput();
        inO = new Object[inp.length];
        outO = new Object[out.length];
        createOutput();
    }


    protected void setLinks(Map<String, String> map)
    {
        this.performer.copyMap(map, this.links);
    }




    class  TransMeasurement implements  IMeasurement {
        public TransMeasurement(int n, Object[] outO, String name, Object type) {
            this.n = n;
            this.outO = outO;
            this.name = name;
            this.type = type;
        }

        @Override
        public String getMeasurementName() {
            return name;
        }

        @Override
        public Object getMeasurementType() {
            return type;
        }

        @Override
        public Object getMeasurementValue() {
            return outO[n];
        }
        @Override
        public String toString() {
            var s = super.toString();
            var k = outO[n];
            if (k instanceof double[])
            {
                var d = (double[])k;
                if (d.length == 1)
                {
                    return d[0] + "";
                }
            }
            return s;
        }

        protected void setLinks(Map<String, String> links) {
            performer.copyMap(links, this.links);
        }

        Object type;

        String name;

        int n;

        Object[] outO;

        Map<String, String> links = new HashMap<>();

        measurements.Performer mPerformer = new measurements.Performer();
    }}
