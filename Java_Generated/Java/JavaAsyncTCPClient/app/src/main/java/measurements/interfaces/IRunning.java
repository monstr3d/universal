package measurements.interfaces;

public interface IRunning {
    /// <summary>
    /// The "is running" sign
    /// </summary>
    boolean isRunning();

    /// <summary>
    /// Running changed event
    /// </summary>
    void addRunningEvent(IRunningChangeEvent event);

    void removeRunningEvent(IRunningChangeEvent event);

}