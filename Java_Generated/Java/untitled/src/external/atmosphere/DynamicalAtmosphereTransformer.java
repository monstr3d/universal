package external.atmosphere;

import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IObjectTransformer;

public class DynamicalAtmosphereTransformer extends DynamicalAtmosphere implements ICategoryObject, IObjectTransformer {

    public  DynamicalAtmosphereTransformer(String name, IDesktop desktop)
    {
        this.name = name;
        this.desktop = desktop;
        desktop.addCategoryObject(this);
    }


    @Override
    public String getCategoryObjectName() {
        return name;
    }

    @Override
    public IDesktop getDesktop() {
        return desktop;
    }

    protected  String name;

    protected IDesktop desktop;

    @Override
    public String[] getInput() {
        return inputs;
    }

    @Override
    public String[] getOutput() {
        return outputs;
    }

    @Override
    public Object getInputType(int i) {
        return type;
    }

    @Override
    public Object getOutputType(int i) {
        return type;
    }

    double[] xx = new double[3];

    @Override
    public void calculate(Object[] input, Object[] output) {
        var t = (double[]) input[0];
        var x = (double[]) input[1];
        var y = (double[]) input[2];
        var z = (double[]) input[3];
        xx[0] = x[0];
        xx[1] = y[0];
        xx[2] = z[0];
        out[0] = atmosphere(t[0], xx);
        output[0] = out;

    }


    protected double[] type = new double[0];

    protected double[] out = new double[]{0};

    /// <summary>
    /// Inputs
    /// </summary>

    protected String[] inputs = new String[] { "t", "x", "y", "z" };
    /// <summary>
    /// Outputs
    /// </summary>

    protected  String[] outputs = new String[]{ "Density" };


}
