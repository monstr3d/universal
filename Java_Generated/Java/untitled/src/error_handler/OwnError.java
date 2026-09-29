package error_handler;

public class OwnError extends   java.lang.Throwable{

    public  OwnError() {
init();
    }

    public  OwnError(String  messsage)
    {
        super(messsage);
        init();
    }

    protected void init()
    {

    }
}
