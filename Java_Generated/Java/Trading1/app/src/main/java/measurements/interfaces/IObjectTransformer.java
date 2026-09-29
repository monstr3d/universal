package measurements.interfaces;

public interface IObjectTransformer {

    String[] getInput();

    String[] getOutput();

    Object getInputType(int i);

    Object getOutputType(int i);

    void calculate(Object[] input, Object[] output);
}
