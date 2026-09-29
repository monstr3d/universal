package synchronization;

// Source - https://stackoverflow.com/a
// Posted by Drew Noakes, modified by community. See post 'Timeline' for change history
// Retrieved 2025-11-11, License - CC BY-SA 3.0

public class AutoResetEvent
{
    private final Object _monitor = new Object();
    private volatile boolean _isOpen = false;

    public AutoResetEvent(boolean open)
    {
        _isOpen = open;
    }

    public void waitOne() throws InterruptedException
    {
        synchronized (_monitor) {
            while (!_isOpen) {
                _monitor.wait();
            }
            _isOpen = false;
        }
    }

    public void waitOne(long timeout) throws InterruptedException
    {
        synchronized (_monitor) {
            long t = System.currentTimeMillis();
            while (!_isOpen) {
                _monitor.wait(timeout);
                // Check for timeout
                if (System.currentTimeMillis() - t >= timeout)
                    break;
            }
            _isOpen = false;
        }
    }

    public void set()
    {
        synchronized (_monitor) {
            _isOpen = true;
            _monitor.notify();
        }
    }

    public void reset()
    {
        _isOpen = false;
    }
}
